using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test;

namespace tablet
{
    public partial class DigitalClock : Form
    {
        ControlScaler scaler;
        private int hourOffset = 0; // 時の調整値
        private int minuteOffset = 0; // 分の調整値

        // 追加：他クラスから現在の補正値を参照できるようにする
        public int HourOffset => hourOffset;
        public int MinuteOffset => minuteOffset;

        public static int time;
        public static int f;
        public DigitalClock()
        {
            InitializeComponent();
            timer1.Interval = 200; // タイマーの間隔を1秒に設定
            timer1.Tick += timer1_Tick; // タイマーのTickイベントにイベントハンドラーを追加
            scaler = new ControlScaler();
            scaler.CaptureInitialState(this);

            // 重要：インスタンス生成直後に一度更新処理を呼んで CurrentAdjustedTime を初期化・通知する
            // これにより、AnalogClock がすぐに正しい時刻を取得できます
            timer1_Tick(this, EventArgs.Empty);
        }
        int H = 0;
        int HH = 0;
        int flg = 0;
        string timeis = string.Empty;
        // --- 追加：現在の補正済み時刻を外部参照するためのプロパティとイベント ---
        public DateTime CurrentAdjustedTime { get; private set; }
        public event Action<DateTime>? TimeUpdated;
        // 27時間表記を使用するか（表示のみを変換するフラグ）
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(true)]
        public bool Use27HourFormat { get; set; } = true;
        // --- 追加ここまで ---
        // timer1_Tick を以下の実装に置き換えてください（クラス内の既存メソッドと差し替え）。
        private void timer1_Tick(object? sender, EventArgs e)
        {
            f = M.f;
            int time2 = M.time2;
            DateTime now = DateTime.Now;
            DateTime adjustedTime = now;
            H = (int)adjustedTime.Hour;
            if (HH != time && f == 0)
            {
                HH++;
                M.f = 1;
                M.time2 = (int)adjustedTime.Hour;
            }
            if (HH == time || f == 1)
            {
                HH = time + ((int)adjustedTime.Hour - time2);
            }
            HH = Math.Max(0, Math.Min(23, HH));
            if (flg == 0)
            {
                adjustedTime = new DateTime(now.Year, now.Month, now.Day, HH, now.Minute, now.Second);
            }
            else
            {
                adjustedTime = now;
            }
            adjustedTime = adjustedTime.AddHours(hourOffset).AddMinutes(minuteOffset);

            // --- 保存と通知 ---
            CurrentAdjustedTime = adjustedTime;
            TimeUpdated?.Invoke(adjustedTime);
            // --- ここまで ---

            // 表示用の時刻計算（鉄道式 27 時間表記: 午前0〜3時を 24〜27 に変換）
            int displayHour = adjustedTime.Hour;
            if (Use27HourFormat && adjustedTime.Hour >= 0 && adjustedTime.Hour <= 3)
            {
                displayHour = adjustedTime.Hour + 24;
            }

            Hlabel.Text = displayHour.ToString("00");
            Mlabel.Text = adjustedTime.ToString("mm");
            Slabel.Text = adjustedTime.ToString("ss");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            hourOffset++; // 時を1増やす
        }
        private void button2_Click(object sender, EventArgs e)
        {
            hourOffset--; // 時を1減らす
        }
        private void button4_Click(object sender, EventArgs e)
        {
            minuteOffset++; // 分を1増やす
        }
        private void button5_Click(object sender, EventArgs e)
        {
            minuteOffset--; // 分を1減らす
        }
        private void button3_Click(object sender, EventArgs e)
        {
            hourOffset = 0; // 時の調整をリセット
            minuteOffset = 0; // 分の調整をリセット
            flg = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            flg = 1;
        }

        private void DigitalClock_Resize(object sender, EventArgs e)
        {
            scaler?.ScaleToCurrentSize(this, controlScalerProvider1);
        }

        /// <summary>
        /// ウィンドウを隠して内部処理を継続したい場合は false のままにする。
        /// アプリ終了時など本当に閉じたいときは true にして Close() を呼ぶ。
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AllowRealClose { get; set; } = false;

        /// <summary>
        /// アプリ終了などで確実に時計を終了させたいときに呼ぶヘルパー。
        /// </summary>
        public void ShutdownClock()
        {
            AllowRealClose = true;
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // 通常は閉じるイベントをキャンセルして Hide() にし、内部タイマー等を続行する
            if (!AllowRealClose)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
            base.OnFormClosing(e);
        }
    }
}
