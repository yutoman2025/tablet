using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Permissions;
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
        public static string file = null;
        public static string file2 = null;
        private void button3_Click(object sender, EventArgs e)
        {
            file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", "m21.wav");
            file2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", "m22.wav");
            if (!File.Exists(file))
            {
                // ログ出力やユーザ向けエラー表示
                MessageBox.Show($"音声ファイルが見つかりません: {file2}");
                return;
            }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", "m23.wav");
            file2 = null;
            if (!File.Exists(file))
            {
                // ログ出力やユーザ向けエラー表示
                MessageBox.Show($"音声ファイルが見つかりません: {file}");
                return;
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", "m21.wav");
            file2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", "m24.wav");
            if (!File.Exists(file))
            {
                // ログ出力やユーザ向けエラー表示
                MessageBox.Show($"音声ファイルが見つかりません: {file2}");
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", "m21.wav");
            file2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", "m25.wav");
            if (!File.Exists(file))
            {
                // ログ出力やユーザ向けエラー表示
                MessageBox.Show($"音声ファイルが見つかりません: {file2}");
                return;
            }
        }
    }
}
