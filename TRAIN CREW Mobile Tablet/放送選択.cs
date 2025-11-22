using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace tablet
{
    public partial class 放送選択 : Form
    {
        public 放送選択()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", "m21.wav");
            string file2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", "m22.wav");
            if (!File.Exists(file))
            {
                // ログ出力やユーザ向けエラー表示
                MessageBox.Show($"音声ファイルが見つかりません: {file2}");
                return;
            }

            using var player = new SoundPlayer(file);
            using var player2 = new SoundPlayer(file2);
            player.Play();
            Task.Delay(100).ContinueWith(_ => player2.Play());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", "m23.wav");
            if (!File.Exists(file))
            {
                // ログ出力やユーザ向けエラー表示
                MessageBox.Show($"音声ファイルが見つかりません: {file}");
                return;
            }
            using var player = new SoundPlayer(file);
            player.Play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", "m21.wav");
            string file2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", "m24.wav");
            if (!File.Exists(file))
            {
                // ログ出力やユーザ向けエラー表示
                MessageBox.Show($"音声ファイルが見つかりません: {file2}");
                return;
            }
            using var player = new SoundPlayer(file);
            using var player2 = new SoundPlayer(file2);
            player.Play();
            Task.Delay(100).ContinueWith(_ => player2.Play());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", "m21.wav");
            string file2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", "m25.wav");
            if (!File.Exists(file))
            {
                // ログ出力やユーザ向けエラー表示
                MessageBox.Show($"音声ファイルが見つかりません: {file2}");
                return;
            }
            using var player = new SoundPlayer(file);
            using var player2 = new SoundPlayer(file2);
            player.Play();
            Task.Delay(100).ContinueWith(_ => player2.Play());
        }
    }
}
