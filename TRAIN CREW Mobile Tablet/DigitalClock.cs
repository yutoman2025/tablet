using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tablet
{
    public partial class DigitalClock : Form
    {
        private int hourOffset = 0; // 時の調整値
        private int minuteOffset = 0; // 分の調整値
        public static int time;
        public DigitalClock()
        {
            InitializeComponent();
            timer1.Interval = 1000; // タイマーの間隔を1秒に設定
            timer1.Tick += timer1_Tick; // タイマーのTickイベントにイベントハンドラーを追加
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
        int H = 0;
        int HH = 0;
        int flg = 0;
        string timeis = string.Empty;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show(H.ToString());
            DateTime now = DateTime.Now;
            DateTime adjustedTime = now;
            //MessageBox.Show(H.ToString());
            H = (int)adjustedTime.Hour;
            if(HH != time)
            {
                HH++;
            }
                /*if (time == 0)
                {
                    HH = adjustedTime.Hour - 10;
                }
                else if (H >= 20 && H <= 23)
                {
                    HH = (H - 20) + time;
                    //MessageBox.Show((H - 20).ToString());
                }
                else if (H >= 14 && H <= 17)
                {
                    HH = (H - 14) + time;
                    //MessageBox.Show((H - 14).ToString());
                }
                else
                {
                    HH = adjustedTime.Hour - 10;
                }*/
                HH = Math.Max(0, Math.Min(23, HH));
            if(flg == 0)
            {
                adjustedTime = new DateTime(now.Year, now.Month, now.Day, HH, now.Minute, now.Second);
            }
            else
            {
                adjustedTime = now;
            }
                adjustedTime = adjustedTime.AddHours(hourOffset).AddMinutes(minuteOffset);
            //MessageBox.Show(HH.ToString());
            // 現在の時刻を取得して、文字列として整形する
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
    }
}
