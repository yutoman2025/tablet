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
            timer1.Interval = 1000; // タイマーの間隔を1秒に設定
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
        // --- 追加ここまで ---

        // timer1_Tick を以下の実装に置き換えてください（クラス内の既存メソッドと差し替え）。
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime adjustedTime = now;
            H = (int)adjustedTime.Hour;
            if (HH != time && f == 0)
            {
                HH++;
            }
            else if (f == 1)
            {
                HH = time + (H - M.time2);
            }
            else
            {
                M.f = 1;
                M.time2 = H;
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

            // --- 追加：現在の補正時刻を保存し、購読者に通知 ---
            CurrentAdjustedTime = adjustedTime;
            TimeUpdated?.Invoke(adjustedTime);
            // --- 追加ここまで ---

            Hlabel.Text = adjustedTime.ToString("HH");
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
    }
}
