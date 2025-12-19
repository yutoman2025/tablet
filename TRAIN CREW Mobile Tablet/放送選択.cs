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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.DataFormats;


namespace tablet
{
    public partial class 放送選択 : Form
    {
        public delegate void LabelUpdateHandler(object sender, string newText);
        public delegate void LabelUpdateHandler2(object sender, string newText);
        public delegate void LabelUpdateHandler3(object sender, string newText);

        // イベントを宣言する
        public event LabelUpdateHandler LabelUpdateRequest;
        public event LabelUpdateHandler2 LabelUpdateRequest2;
        public event LabelUpdateHandler3 LabelUpdateRequest3;
        public 放送選択()
        {
            InitializeComponent();
        }
        public static string file = null;
        public static string file2 = null;
        public static string name = null;
        public static string type = null;
        public static string de = null;
        public static string color = null;
        public static string sta = null;
        public static string ban = null;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (domainUpDown1 != null)
            {
                type = domainUpDown1.Text;
                switch (type)
                {
                    case "各駅停車":
                        color = "White";
                        break;
                    case "準急行":
                        color = "Cyan";
                        break;
                    case "区間急行":
                        color = "Green";
                        break;
                    case "急行":
                        color = "Orange";
                        break;
                    case "快速急行":
                        color = "MediumOrchid";
                        break;
                    case "館浜特急":
                        color = "Red";
                        break;
                    default:
                        color = "White";
                        break;
                }
                if (LabelUpdateRequest3 != null)
                {
                    // イベントを発火させる
                    // 第一引数はsender (自分自身: this)、第二引数は渡したい新しいテキスト
                    LabelUpdateRequest3(this, type);
                }
                label3.Text = type;
                label3.ForeColor = Color.FromName(color);
            }
            else
            {
                bool originalTopMost = this.TopMost;
                this.TopMost = true;
                MessageBox.Show("種別が選択されていません。");
                this.TopMost = originalTopMost;
                return;
            }
            if(domainUpDown2 != null)
            {
                de = domainUpDown2.Text;
                if (LabelUpdateRequest2 != null)
                {
                    // イベントを発火させる
                    // 第一引数はsender (自分自身: this)、第二引数は渡したい新しいテキスト
                    LabelUpdateRequest2(this, de);
                }
                label2.Text = de;
            }
            else
            {
                bool originalTopMost = this.TopMost;
                this.TopMost = true;
                MessageBox.Show("行き先が選択されていません。");
                this.TopMost = originalTopMost;
                return;
            }
            if (domainUpDown10 != null)
            {
                sta = domainUpDown10.Text;
                label1.Text = sta;
            }
            else
            {
                bool originalTopMost = this.TopMost;
                this.TopMost = true;
                MessageBox.Show("始発駅が選択されていません");
                this.TopMost = originalTopMost;
                return;
            }
            if(domainUpDown5 != null)
            {
                ban = domainUpDown5.Text;
                label4.Text = ban+"番";
            }
            else
            {
                bool originalTopMost = this.TopMost;
                this.TopMost = true;
                MessageBox.Show("到着番線が指定されていません");
                this.TopMost = originalTopMost;
                return;
            }
        }
    }
}
