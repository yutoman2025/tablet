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
        public static string melody = null;
        public static string typemedia = null;
        public static string demedia = null;
        public static int denumber = 0;
        public static int stanumber2 = 0;
        public static string nametype = null;
        public static string filetype = null;
        private void button13_Click(object sender, EventArgs e)
        {
            if (this.TopMost == false)
            {
                this.TopMost = true;
                button13.BackColor = Color.Yellow;
            }
            else
            {
                this.TopMost = false;
                button13.BackColor = Color.White;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (domainUpDown7 != null)
            {
                melody = domainUpDown7.Text;
                switch (melody)
                {
                    case "純正メロディ1": melody = "終点チャイム.wav"; break;
                    case "純正メロディ２": melody = "終点チャイム２.wav"; break;
                    case "鉄道唱歌メロディ": melody = "鉄道唱歌.wav"; break;
                    case "特急チャイム": melody = "車内チャイム.wav"; break;
                    case "あつひか": melody = "あつくてひからびそう.wav"; break;
                }
                string lb = domainUpDown7.ToString();
                label5.Text = lb;
            }
            else
            {
                bool originalTopMost = this.TopMost;
                this.TopMost = true;
                MessageBox.Show("メロディが選択されていません。");
                this.TopMost = originalTopMost;
                return;
            }
            if (domainUpDown6 != null)
            {
                nametype = domainUpDown6.Text;
                switch (nametype)
                {
                    case "純正": nametype = "純正"; filetype = "純正"; break;
                    case "音声1": nametype = "音声1"; filetype = "オリジナル"; break;
                    case "音声2": nametype = "音声2"; filetype = "オリジナル"; break;
                }
                string lb = domainUpDown6.ToString();
                label6.Text = lb;
            }
            else
            {
                bool originalTopMost = this.TopMost;
                this.TopMost = true;
                MessageBox.Show("放送タイプが選択されていません。");
                this.TopMost = originalTopMost;
                return;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (nametype == null)
            {
                bool originalTopMost = this.TopMost;
                this.TopMost = true;
                MessageBox.Show("放送タイプが選択されていません。");
                this.TopMost = originalTopMost;
                return;
            }
            else
            {
                file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", nametype, "m21.wav");
                file2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", nametype, "m22.wav");
            }
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
            if (nametype == null)
            {
                bool originalTopMost = this.TopMost;
                this.TopMost = true;
                MessageBox.Show("放送タイプが選択されていません。");
                this.TopMost = originalTopMost;
                return;
            }
            else
            {
                file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", nametype, "m23.wav");
                file2 = null;
            }
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
            if (nametype == null)
            {
                bool originalTopMost = this.TopMost;
                this.TopMost = true;
                MessageBox.Show("放送タイプが選択されていません。");
                this.TopMost = originalTopMost;
                return;
            }
            else
            {
                file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", nametype, "m21.wav");
                file2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", nametype, "m24.wav");
            }
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
            if (nametype == null)
            {
                bool originalTopMost = this.TopMost;
                this.TopMost = true;
                MessageBox.Show("放送タイプが選択されていません。");
                this.TopMost = originalTopMost;
                return;
            }
            else
            {
                file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", nametype, "m21.wav");
                file2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", nametype, "m25.wav");
            }
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
            if (domainUpDown2 != null)
            {
                de = domainUpDown2.Text;
                switch (de)
                {
                    case "大手橋": demedia = "s01.wav"; denumber = 1; break;
                    case "三番街": demedia = "s02.wav"; denumber = 2; break;
                    case "新町": demedia = "s03.wav"; break;
                    case "青木町": demedia = "s04.wav"; break;
                    case "宮松町": demedia = "s05.wav"; break;
                    case "神宮橋": demedia = "s06.wav"; break;
                    case "宮の前": demedia = "s07.wav"; break;
                    case "南吉岡": demedia = "s08.wav"; break;
                    case "小手川": demedia = "s09.wav"; break;
                    case "佐野": demedia = "s10.wav"; break;
                    case "中道": demedia = "s11.wav"; break;
                    case "学院前": demedia = "s12.wav"; break;
                    case "南八幡": demedia = "s13.wav"; break;
                    case "高井戸八幡": demedia = "s14.wav"; break;
                    case "南五日市": demedia = "s15.wav"; break;
                    case "五日市": demedia = "s16.wav"; break;
                    case "夕陽が丘": demedia = "s17.wav"; break;
                    case "佐川": demedia = "s18.wav"; break;
                    case "出屋敷前": demedia = "s19.wav"; break;
                    case "五十川": demedia = "s20.wav"; break;
                    case "本郷": demedia = "s21.wav"; break;
                    case "大原": demedia = "s22.wav"; break;
                    case "町沢": demedia = "s23.wav"; break;
                    case "緑ヶ丘": demedia = "s24.wav"; break;
                    case "北美": demedia = "s25.wav"; break;
                    case "矢木": demedia = "s26.wav"; break;
                    case "千里が丘": demedia = "s27.wav"; break;
                    case "東福": demedia = "s28.wav"; break;
                    case "高砂町": demedia = "s29.wav"; break;
                    case "長野本町": demedia = "s30.wav"; break;
                    case "新長野公園": demedia = "s31.wav"; break;
                    case "木之本": demedia = "s32.wav"; break;
                    case "大和田町": demedia = "s33.wav"; break;
                    case "江西": demedia = "s34.wav"; break;
                    case "箕田": demedia = "s35.wav"; break;
                    case "沢井": demedia = "s36.wav"; break;
                    case "大野宮": demedia = "s37.wav"; break;
                    case "朝日ヶ丘": demedia = "s38.wav"; break;
                    case "六日市町": demedia = "s39.wav"; break;
                    case "小沼": demedia = "s40.wav"; break;
                    case "二ツ山": demedia = "s41.wav"; break;
                    case "田村": demedia = "s42.wav"; break;
                    case "広小路": demedia = "s43.wav"; break;
                    case "常磐通": demedia = "s44.wav"; break;
                    case "大路": demedia = "s45.wav"; break;
                    case "新大路": demedia = "s46.wav"; break;
                    case "桜坂": demedia = "s47.wav"; break;
                    case "東井": demedia = "s48.wav"; break;
                    case "白石町": demedia = "s49.wav"; break;
                    case "二木戸": demedia = "s50.wav"; break;
                    case "三石": demedia = "s51.wav"; break;
                    case "名田": demedia = "s52.wav"; break;
                    case "下吉沢": demedia = "s53.wav"; break;
                    case "上吉沢": demedia = "s54.wav"; break;
                    case "珠川温泉": demedia = "s55.wav"; break;
                    case "明神川": demedia = "s56.wav"; break;
                    case "三郷": demedia = "s57.wav"; break;
                    case "赤山町": demedia = "s58.wav"; break;
                    case "西赤山": demedia = "s59.wav"; break;
                    case "奥峯口": demedia = "s60.wav"; break;
                    case "日野森": demedia = "s61.wav"; break;
                    case "高見沢": demedia = "s62.wav"; break;
                    case "水越": demedia = "s63.wav"; break;
                    case "藤江": demedia = "s64.wav"; break;
                    case "大道寺": demedia = "s65.wav"; break;
                    case "江ノ原": demedia = "s66.wav"; break;
                    case "新野崎": demedia = "s67.wav"; break;
                    case "新井川": demedia = "s68.wav"; break;
                    case "羽衣橋": demedia = "s69.wav"; break;
                    case "浜園": demedia = "s70.wav"; break;
                    case "津崎": demedia = "s71.wav"; break;
                    case "虹ケ浜": demedia = "s72.wav"; break;
                    case "海岸公園": demedia = "s73.wav"; break;
                    case "河原崎": demedia = "s74.wav"; break;
                    case "駒野": demedia = "s75.wav"; break;
                    case "館浜": demedia = "s76.wav"; break;
                }
                if (nametype == null)
                {
                    bool originalTopMost = this.TopMost;
                    this.TopMost = true;
                    MessageBox.Show("放送タイプが選択されていません。");
                    this.TopMost = originalTopMost;
                    return;
                }
                else
                {
                    demedia = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", nametype, demedia);
                }
                if (LabelUpdateRequest2 != null)
                {
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
                switch (sta)
                {
                    case "大手橋": stanumber2 = 1; break;
                    case "三番街": stanumber2 = 2; break;
                    case "新町": stanumber2 = 3; break;
                    case "青木町": stanumber2 = 4; break;
                    case "宮松町": stanumber2 = 5; break;
                    case "神宮橋": stanumber2 = 6; break;
                    case "宮の前": stanumber2 = 7; break;
                    case "南吉岡": stanumber2 = 8; break;
                    case "小手川": stanumber2 = 9; break;
                    case "佐野": stanumber2 = 10; break;
                    case "中道": stanumber2 = 11; break;
                    case "学院前": stanumber2 = 12; break;
                    case "南八幡": stanumber2 = 13; break;
                    case "高井戸八幡": stanumber2 = 14; break;
                    case "南五日市": stanumber2 = 15; break;
                    case "五日市": stanumber2 = 16; break;
                    case "夕陽が丘": stanumber2 = 17; break;
                    case "佐川": stanumber2 = 18; break;
                    case "出屋敷前": stanumber2 = 19; break;
                    case "五十川": stanumber2 = 20; break;
                    case "本郷": stanumber2 = 21; break;
                    case "大原": stanumber2 = 22; break;
                    case "町沢": stanumber2 = 23; break;
                    case "緑ヶ丘": stanumber2 = 24; break;
                    case "北美": stanumber2 = 25; break;
                    case "矢木": stanumber2 = 26; break;
                    case "千里が丘": stanumber2 = 27; break;
                    case "東福": stanumber2 = 28; break;
                    case "高砂町": stanumber2 = 29; break;
                    case "長野本町": stanumber2 = 30; break;
                    case "新長野公園": stanumber2 = 31; break;
                    case "木之本": stanumber2 = 32; break;
                    case "大和田町": stanumber2 = 33; break;
                    case "江西": stanumber2 = 34; break;
                    case "箕田": stanumber2 = 35; break;
                    case "沢井": stanumber2 = 36; break;
                    case "大野宮": stanumber2 = 37; break;
                    case "朝日ヶ丘": stanumber2 = 38; break;
                    case "六日市町": stanumber2 = 39; break;
                    case "小沼": stanumber2 = 40; break;
                    case "二ツ山": stanumber2 = 41; break;
                    case "田村": stanumber2 = 42; break;
                    case "広小路": stanumber2 = 43; break;
                    case "常磐通": stanumber2 = 44; break;
                    case "大路": stanumber2 = 45; break;
                    case "新大路": stanumber2 = 46; break;
                    case "桜坂": stanumber2 = 47; break;
                    case "東井": stanumber2 = 48; break;
                    case "白石町": stanumber2 = 49; break;
                    case "二木戸": stanumber2 = 50; break;
                    case "三石": stanumber2 = 51; break;
                    case "名田": stanumber2 = 52; break;
                    case "下吉沢": stanumber2 = 53; break;
                    case "上吉沢": stanumber2 = 54; break;
                    case "珠川温泉": stanumber2 = 55; break;
                    case "明神川": stanumber2 = 56; break;
                    case "三郷": stanumber2 = 57; break;
                    case "赤山町": stanumber2 = 58; break;
                    case "西赤山": stanumber2 = 59; break;
                    case "奥峯口": stanumber2 = 60; break;
                    case "日野森": stanumber2 = 61; break;
                    case "高見沢": stanumber2 = 62; break;
                    case "水越": stanumber2 = 63; break;
                    case "藤江": stanumber2 = 64; break;
                    case "大道寺": stanumber2 = 65; break;
                    case "江ノ原": stanumber2 = 66; break;
                    case "新野崎": stanumber2 = 67; break;
                    case "新井川": stanumber2 = 68; break;
                    case "羽衣橋": stanumber2 = 69; break;
                    case "浜園": stanumber2 = 70; break;
                    case "津崎": stanumber2 = 71; break;
                    case "虹ケ浜": stanumber2 = 72; break;
                    case "海岸公園": stanumber2 = 73; break;
                    case "河原崎": stanumber2 = 74; break;
                    case "駒野": stanumber2 = 75; break;
                    case "館浜": stanumber2 = 76; break;
                }
            }
            else
            {
                bool originalTopMost = this.TopMost;
                this.TopMost = true;
                MessageBox.Show("始発駅が選択されていません");
                this.TopMost = originalTopMost;
                return;
            }
            if (domainUpDown1 != null && denumber != null && stanumber2 != null)
            {
                type = domainUpDown1.Text;
                switch (type)
                {
                    case "各駅停車":
                        color = "White";
                        typemedia = "t1.wav";
                        for (int i = stanumber2; i < denumber; i++)
                        {
                            if (i == 76)
                            {
                                break;
                            }
                        }
                        break;
                    case "準急行":
                        color = "Cyan";
                        typemedia = "t2.wav";
                        break;
                    case "区間急行":
                        color = "Green";
                        typemedia = "t3.wav";
                        break;
                    case "急行":
                        color = "Orange";
                        typemedia = "t4.wav";
                        break;
                    case "快速急行":
                        color = "MediumOrchid";
                        typemedia = "t5.wav";
                        break;
                    case "館浜特急":
                        color = "Red";
                        typemedia = "t6.wav";
                        break;
                    case "回送":
                        color = "Gray";
                        typemedia = "t7.wav";
                        break;
                    default:
                        color = "White";
                        break;
                }
                if (nametype == null)
                {
                    bool originalTopMost = this.TopMost;
                    this.TopMost = true;
                    MessageBox.Show("放送タイプが選択されていません。");
                    this.TopMost = originalTopMost;
                    return;
                }
                else
                {
                    typemedia = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "放送", nametype, typemedia);
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
            if (domainUpDown5 != null)
            {
                ban = domainUpDown5.Text;
                label4.Text = ban + "番";
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
