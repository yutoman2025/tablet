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
            bool resume = resumeIndex > 0 || resumePosition > TimeSpan.Zero;

            StartPlay(files, resume);
        }



        private void StartPlay(List<string> files, bool resume)
        {
            StopNAudio();

            // ★ 必ずここでリセット
            isStoppingByUser = false;


            playList = files;

            if (resume)
            {
                currentIndex = resumeIndex;
                playedDuration = TimeSpan.Zero;

                // それまでの音声分を足す
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

            // 合計時間
            totalDuration = TimeSpan.Zero;
            foreach (var f in playList)
            {
                using var r = new AudioFileReader(f);
                totalDuration += r.TotalTime;
            }

            progressBar1.Maximum = (int)totalDuration.TotalMilliseconds;

            PlayCurrent(resume);

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

                if (isStoppingByUser && audioFile.CurrentTime < audioFile.TotalTime)
                {
                    isStoppingByUser = false;
                    return;
                }

                playedDuration += audioFile.TotalTime;

                audioFile.Dispose();
                outputDevice.Dispose();

                currentIndex++;

                if (currentIndex < playList.Count)
                {
                    PlayCurrent(false);
                }
                else
                {
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
    }
}
