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
using test;
using static System.Windows.Forms.DataFormats;


namespace tablet
{
    public partial class 放送選択 : Form
    {
        public delegate void LabelUpdateHandler(object sender, string newText);

        // イベントを宣言する
        public event LabelUpdateHandler LabelUpdateRequest;
        public 放送選択()
        {
            InitializeComponent();
        }
        public static string file = null;
        public static string file2 = null;
        public static string name = null;
        private void button3_Click(object sender, EventArgs e)
        {
            file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", "m21.wav");
            file2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", "m22.wav");
            name = "携帯電話";
            if (LabelUpdateRequest != null)
            {
                // イベントを発火させる
                // 第一引数はsender (自分自身: this)、第二引数は渡したい新しいテキスト
                LabelUpdateRequest(this, name);
            }
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
            name = "不審な荷物";
            if (LabelUpdateRequest != null)
            {
                // イベントを発火させる
                // 第一引数はsender (自分自身: this)、第二引数は渡したい新しいテキスト
                LabelUpdateRequest(this, name);
            }
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
            name = "優先座席";
            if (LabelUpdateRequest != null)
            {
                // イベントを発火させる
                // 第一引数はsender (自分自身: this)、第二引数は渡したい新しいテキスト
                LabelUpdateRequest(this, name);
            }
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
            name = "迷惑行為";
            if (LabelUpdateRequest != null)
            {
                // イベントを発火させる
                // 第一引数はsender (自分自身: this)、第二引数は渡したい新しいテキスト
                LabelUpdateRequest(this, name);
            }
            if (!File.Exists(file))
            {
                // ログ出力やユーザ向けエラー表示
                MessageBox.Show($"音声ファイルが見つかりません: {file2}");
                return;
            }
        }
    }
}
