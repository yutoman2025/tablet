using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using tablet;

namespace test
{
    public partial class C : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private System.Windows.Forms.Timer timer;

        private List<string> playList;
        private int currentIndex = 0;

        private TimeSpan totalDuration;     // 全音声の合計時間
        private TimeSpan playedDuration;    // すでに再生し終えた分
        private bool isPlaying = false;
        private bool isStoppingByUser = false;
        private int resumeIndex = 0;              // 再開する音声の番号
        private TimeSpan resumePosition = TimeSpan.Zero; // その音声内の位置



        public C()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.TopMost == false)
            {
                this.TopMost = true;
                button1.BackColor = Color.Yellow;
            }
            else
            {
                this.TopMost = false;
                button1.BackColor = Color.White;
            }
        }

        private 放送選択 form1Instance;
        private void button5_Click(object sender, EventArgs e)
        {
            if (form1Instance == null || form1Instance.IsDisposed)
            {
                form1Instance = new 放送選択();

                // --- ここでイベントハンドラを購読する ---
                // フォームが「更新要求」イベントを発火したら、OnLabelUpdateRequestメソッドを呼び出す
                form1Instance.LabelUpdateRequest += OnLabelUpdateRequest;
                form1Instance.LabelUpdateRequest2 += OnLabelUpdateRequest2;
                form1Instance.LabelUpdateRequest3 += OnLabelUpdateRequest3;

                form1Instance.Show();
                button5.BackColor = Color.YellowGreen;
                return;
            }
            else
            {
                form1Instance.Close();
                // イベントハンドラの購読解除も忘れずに
                form1Instance.LabelUpdateRequest -= OnLabelUpdateRequest;
                form1Instance.LabelUpdateRequest2 -= OnLabelUpdateRequest2;
                form1Instance.LabelUpdateRequest3 -= OnLabelUpdateRequest3;
                button5.BackColor = Color.White;
                return;
            }
        }

        private void Form1Instance_LabelUpdateRequest3(object sender, string newText)
        {
            throw new NotImplementedException();
        }

        private void OnLabelUpdateRequest(object sender, string newText)
        {
            // ここで親フォームのラベルを更新する
            this.label1.Text = newText;
        }
        private void OnLabelUpdateRequest2(object sender, string newText)
        {
            // ここで親フォームのラベルを更新する
            this.label2.Text = newText;
            string color = 放送選択.color;
        }
        private void OnLabelUpdateRequest3(object sender, string newText)
        {
            // ここで親フォームのラベルを更新する
            this.label3.Text = newText;
            string color = 放送選択.color;
            this.label3.ForeColor = System.Drawing.Color.FromName(color);
        }
        int flg = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (isPlaying && audioFile != null)
            {
                StopNAudio();
                return;
            }

            var files = new List<string>();

            if (!string.IsNullOrEmpty(放送選択.file))
                files.Add(放送選択.file);

            if (!string.IsNullOrEmpty(放送選択.file2))
                files.Add(放送選択.file2);

            if (files.Count == 0) return;

            // ★ 再開 or 新規判定
            // resumeIndex や resumePosition に値が入っている場合は、前回停止した位置から再開する。
            // 例えば resumeIndex == 1 の場合は2つ目のファイルから再開される（0起点のため）。
            bool resume = resumeIndex > 0 || resumePosition > TimeSpan.Zero;

            StartPlay(files, resume);
        }



        private void StartPlay(List<string> files, bool resume)
        {
            StopNAudio();

            isStoppingByUser = false;
            playList = files ?? new List<string>();

            if (playList.Count == 0)
            {
                // 再生するファイルが無ければ何もしない
                isPlaying = false;
                return;
            }

            // resume を使うか判定（保存された index が新しいリスト内かを確認）
            bool hasValidResumeIndex = resumeIndex > 0 && resumeIndex < playList.Count;
            bool hasValidResumePos = resumePosition > TimeSpan.Zero;
            bool useResume = hasValidResumeIndex || hasValidResumePos;

            if (resume && useResume)
            {
                // currentIndex を playList の範囲内に補正
                currentIndex = Math.Clamp(resumeIndex, 0, playList.Count - 1);
                playedDuration = TimeSpan.Zero;

                for (int i = 0; i < currentIndex; i++)
                {
                    using var r = new AudioFileReader(playList[i]);
                    playedDuration += r.TotalTime;
                }
            }
            else
            {
                currentIndex = 0;
                resumeIndex = 0;
                resumePosition = TimeSpan.Zero;
                playedDuration = TimeSpan.Zero;
            }

            // 合計時間（ファイルパスが有効か例外が出る可能性あり）
            totalDuration = TimeSpan.Zero;
            foreach (var f in playList)
            {
                using var r = new AudioFileReader(f);
                totalDuration += r.TotalTime;
            }

            progressBar1.Maximum = Math.Max(1, (int)totalDuration.TotalMilliseconds);

            // currentIndex が範囲内であることを再確認してから再生
            if (currentIndex < 0 || currentIndex >= playList.Count)
            {
                currentIndex = 0;
            }

            PlayCurrent(useResume);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 20;
            timer.Tick += UpdateProgress;
            timer.Start();

            isPlaying = true;
        }

        private void PlayCurrent(bool resume)
        {
            audioFile = new AudioFileReader(playList[currentIndex]);

            // ★ 再開位置をセット
            // resume==true かつ resumePosition が設定されていると、そのファイル内の途中位置から再生する。
            // 例: 前回 StopNAudio() 呼び出しで resumeIndex==1, resumePosition==00:00:12.345 の場合
            //      -> 2つ目のファイルの 12.345 秒から再生される。
            if (resume && resumePosition > TimeSpan.Zero)
            {
                audioFile.CurrentTime = resumePosition;
                resumePosition = TimeSpan.Zero;
            }

            outputDevice = new WaveOutEvent();

            outputDevice.PlaybackStopped += (s, e) =>
            {
                if (audioFile == null)
                    return;

                // ユーザーが停止ボタンを押して停止した場合、現在の再生が途中で止まったのかどうかを判定する。
                if (isStoppingByUser && audioFile.CurrentTime < audioFile.TotalTime)
                {
                    // ユーザーによる停止時はフラグをクリアして何もしない（StopNAudio()側で位置は保存済み）
                    isStoppingByUser = false;
                    return;
                }

                // このファイルを最後まで再生したので、playedDuration にその全長を加える
                playedDuration += audioFile.TotalTime;

                audioFile.Dispose();
                outputDevice.Dispose();

                // 次のファイルへ進める
                currentIndex++;

                if (currentIndex < playList.Count)
                {
                    // 次のファイルがあれば再生を続ける（再開位置は未指定なのでファイルの先頭から）
                    PlayCurrent(false);
                }
                else
                {
                    // 全ファイル再生完了
                    StopNAudio();
                }
            };



            outputDevice.Init(audioFile);
            outputDevice.Play();
        }


        private void UpdateProgress(object sender, EventArgs e)
        {
            if (audioFile == null) return;

            var current =
                playedDuration + audioFile.CurrentTime;

            int value = (int)current.TotalMilliseconds;
            if (value <= progressBar1.Maximum)
                progressBar1.Value = value;
        }


        private void StopNAudio()
        {
            isStoppingByUser = true;

            // ★ 再生位置を保存
            // 再生中のファイルがあれば、そのインデックス(currentIndex)とファイル内の位置(CurrentTime)を
            // resumeIndex / resumePosition に保存する。これにより、次回 StartPlay 時に「2つ目のファイルから再開」
            // のような挙動が可能になる（resumeIndex は 0 起点）。
            if (audioFile != null && currentIndex < playList?.Count)
            {
                resumeIndex = currentIndex;
                resumePosition = audioFile.CurrentTime;
            }


            timer?.Stop();
            timer?.Dispose();
            timer = null;

            outputDevice?.Stop();
            outputDevice?.Dispose();
            outputDevice = null;

            audioFile?.Dispose();
            audioFile = null;

            isPlaying = false;
        }

        private void C_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopNAudio();
            if (form1Instance != null && !form1Instance.IsDisposed)
            {
                form1Instance.Close();
                // イベントハンドラの購読解除も忘れずに
                form1Instance.LabelUpdateRequest -= OnLabelUpdateRequest;
                form1Instance.LabelUpdateRequest2 -= OnLabelUpdateRequest2;
                form1Instance.LabelUpdateRequest3 -= OnLabelUpdateRequest3;
                button5.BackColor = Color.White;
            }
        }
        int cnt = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            cnt++;
            if(cnt == 1)
            {
                // ユーザーの要求: ボタンを1回クリックしたら、再生を先頭に戻す
                if (playList == null || playList.Count == 0)
                {
                    // 再生リストがない場合は何もしない
                    cnt = 0;
                    return;
                }

                // リセットする位置
                resumeIndex = 0;
                resumePosition = TimeSpan.Zero;
                currentIndex = 0;
                playedDuration = TimeSpan.Zero;

                // 再生中であれば、現在の再生を止めずに先頭のファイルの先頭から再生を開始する
                if (isPlaying && audioFile != null)
                {
                    // 既存のタイマーと出力を停止して破棄
                    timer?.Stop();
                    timer?.Dispose();
                    timer = null;

                    outputDevice?.Stop();
                    outputDevice?.Dispose();
                    outputDevice = null;

                    audioFile?.Dispose();
                    audioFile = null;

                    // 先頭から再生を開始
                    PlayCurrent(false);

                    // プログレス更新タイマーを再作成
                    timer = new System.Windows.Forms.Timer();
                    timer.Interval = 20;
                    timer.Tick += UpdateProgress;
                    timer.Start();

                    isPlaying = true;
                }
                else if(resumeIndex == null && resumePosition ==null)
                {
                    // 再生していない場合はプログレスだけリセット
                    if (progressBar1 != null)
                        progressBar1.Value = 0;
                }
            }
            if (cnt == 2)
            {
                cnt = 0;
            }
        }
    }
}
