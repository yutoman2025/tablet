using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using tablet;
using tc_staff_draw;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace test
{
    public partial class M : Form
    {
        ControlScaler scaler;
        int time = 0;
        public M()
        {
            InitializeComponent();
            this.AcceptButton = button4;
            scaler = new ControlScaler();
            scaler.CaptureInitialState(this);
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
        private メモ form2Instance;
        private void button3_Click(object sender, EventArgs e)
        {
            if (form2Instance == null || form2Instance.IsDisposed)
            {
                form2Instance = new メモ();
                form2Instance.Show();
                button3.BackColor = Color.LightGreen;
                return;
            }
            else
            {
                form2Instance.Close();
                button3.BackColor = Color.White;
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                bool originalTopMost = this.TopMost;
                this.TopMost = true;
                MessageBox.Show(this, "ダイヤまたは行路を選択してください", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.TopMost = originalTopMost;
                return;
            }
            else if (comboBox1.SelectedItem.ToString() == "ダイヤ不定")
            {
                bool originalTopMost = this.TopMost;
                this.TopMost = true;
                MessageBox.Show(this, "ダイヤを設定してください", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.TopMost = originalTopMost;
                return;
            }
            else if (comboBox1.SelectedItem.ToString() == "11-13")
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                ResourceManager resourceManager = new ResourceManager("tablet.Properties.Resources", assembly);
                string selectedText = comboBox2.Text;
                int last = selectedText.Length - 1;
                string selectedText3 = Regex.Replace(selectedText, @"[^0-9]", "");
                selectedText = Regex.Replace(selectedText, @"[0-Z]", "");
                int num = int.Parse(selectedText3);
                selectedText = selectedText.Replace("平", "");
                selectedText = selectedText.Replace("変-", "2");
                selectedText = selectedText.Replace("準2", "3");
                selectedText = selectedText.Replace("普2", "3");
                selectedText = selectedText.Replace("教2", "9");
                if (num >= 1 && num <= 9 && selectedText == "")
                {
                    selectedText3 = "0" + selectedText3;
                }
                string selectedText2 = "11-" + selectedText + selectedText3;
                if (resourceManager.GetObject(selectedText2) == null)
                {
                    bool originalTopMost = this.TopMost;
                    this.TopMost = true;
                    MessageBox.Show(this, "正しい行路を選択してください", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.TopMost = originalTopMost;
                    return;
                }
                else
                {
                    Image myImage = (Image)resourceManager.GetObject(selectedText2);
                    pictureBox2.Image = myImage;
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "15-17")
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                ResourceManager resourceManager = new ResourceManager("tablet.Properties.Resources", assembly);
                string selectedText = comboBox2.Text;
                int last = selectedText.Length - 1;
                string selectedText3 = Regex.Replace(selectedText, @"[^0-9]", "");
                selectedText = Regex.Replace(selectedText, @"[0-9]", "");
                int num = int.Parse(selectedText3);
                selectedText = selectedText.Replace("平", "");
                selectedText = selectedText.Replace("変-", "2");
                selectedText = selectedText.Replace("準2", "3");
                selectedText = selectedText.Replace("普2", "3");
                selectedText = selectedText.Replace("教2", "9");
                if (num >= 1 && num <= 9 && selectedText == "")
                {
                    selectedText3 = "0" + selectedText3;
                }
                string selectedText2 = "15-" + selectedText + selectedText3;
                if (resourceManager.GetObject(selectedText2) == null)
                {
                    bool originalTopMost = this.TopMost;
                    this.TopMost = true;
                    MessageBox.Show(this, "正しい行路を選択してください", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.TopMost = originalTopMost;
                    return;
                }
                else
                {
                    Image myImage = (Image)resourceManager.GetObject(selectedText2);
                    pictureBox2.Image = myImage;
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "18-20")
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                ResourceManager resourceManager = new ResourceManager("tablet.Properties.Resources", assembly);
                string selectedText = comboBox2.Text;
                int last = selectedText.Length - 1;
                string selectedText3 = Regex.Replace(selectedText, @"[^0-9]", "");
                selectedText = Regex.Replace(selectedText, @"[0-9]", "");
                int num = int.Parse(selectedText3);
                selectedText = selectedText.Replace("平", "");
                selectedText = selectedText.Replace("変-", "2");
                selectedText = selectedText.Replace("準2", "3");
                selectedText = selectedText.Replace("普2", "3");
                selectedText = selectedText.Replace("教2", "9");
                if (num >= 1 && num <= 9 && selectedText == "")
                {
                    selectedText3 = "0" + selectedText3;
                }
                string selectedText2 = "18-" + selectedText + selectedText3;
                if (resourceManager.GetObject(selectedText2) == null)
                {
                    bool originalTopMost = this.TopMost;
                    this.TopMost = true;
                    MessageBox.Show(this, "正しい行路を選択してください", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.TopMost = originalTopMost;
                    return;
                }
                else
                {
                    Image myImage = (Image)resourceManager.GetObject(selectedText2);
                    pictureBox2.Image = myImage;
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "07-09")
            {
                bool originalTopMost = this.TopMost;
                this.TopMost = true;
                MessageBox.Show("0709は未対応です");
                this.TopMost = originalTopMost;
                return;
                /*Assembly assembly = Assembly.GetExecutingAssembly();
                ResourceManager resourceManager = new ResourceManager("tablet.Properties.Resources", assembly);
                string selectedText = comboBox2.Text;
                int last = selectedText.Length - 1;
                string selectedText3 = Regex.Replace(selectedText, @"[^0-9]", "");
                selectedText = Regex.Replace(selectedText, @"[0-9]", "");
                int num = int.Parse(selectedText3);
                selectedText = selectedText.Replace("平", "");
                selectedText = selectedText.Replace("変-", "2");
                selectedText = selectedText.Replace("準2", "3");
                selectedText = selectedText.Replace("普2", "3");
                selectedText = selectedText.Replace("教2", "9");
                selectedText = selectedText.Replace("地2", "4");
                if (num >= 1 && num <= 9 && selectedText == "")
                {
                    selectedText3 = "0" + selectedText3;
                }
                string selectedText2 = "07-" + selectedText + selectedText3;
                MessageBox.Show(selectedText2);
                if (resourceManager.GetObject(selectedText2) == null)
                {
                    bool originalTopMost = this.TopMost;
                    this.TopMost = true;
                    MessageBox.Show(this, "正しい行路を選択してください", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.TopMost = originalTopMost;
                    return;
                }
                else
                {
                    Image myImage = (Image)resourceManager.GetObject(selectedText2);
                    pictureBox2.Image = myImage;
                }*/
            }
            else if (comboBox1.SelectedItem.ToString() == "21-23")
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                ResourceManager resourceManager = new ResourceManager("tablet.Properties.Resources", assembly);
                string selectedText = comboBox2.Text;
                int last = selectedText.Length - 1;
                string selectedText3 = Regex.Replace(selectedText, @"[^0-9]", "");
                selectedText = Regex.Replace(selectedText, @"[0-9]", "");
                int num = int.Parse(selectedText3);
                selectedText = selectedText.Replace("平", "");
                selectedText = selectedText.Replace("変-", "2");
                selectedText = selectedText.Replace("準2", "3");
                selectedText = selectedText.Replace("普2", "3");
                selectedText = selectedText.Replace("教2", "9");
                if (num >= 1 && num <= 9 && selectedText == "")
                {
                    selectedText3 = "0" + selectedText3;
                }
                string selectedText2 = "21-" + selectedText + selectedText3;
                MessageBox.Show(selectedText2);
                if (resourceManager.GetObject(selectedText2) == null)
                {
                    bool originalTopMost = this.TopMost;
                    this.TopMost = true;
                    MessageBox.Show(this, "正しい行路を選択してください", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.TopMost = originalTopMost;
                    return;
                }
                else
                {
                    Image myImage = (Image)resourceManager.GetObject(selectedText2);
                    pictureBox2.Image = myImage;
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "18-24")
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                ResourceManager resourceManager = new ResourceManager("tablet.Properties.Resources", assembly);
                string selectedText = comboBox2.Text;
                int last = selectedText.Length - 1;
                string selectedText3 = Regex.Replace(selectedText, @"[^0-9]", "");
                selectedText = Regex.Replace(selectedText, @"[0-9]", "");
                int num = int.Parse(selectedText3);
                selectedText = selectedText.Replace("平", "");
                selectedText = selectedText.Replace("変-", "2");
                selectedText = selectedText.Replace("準2", "3");
                selectedText = selectedText.Replace("普2", "3");
                selectedText = selectedText.Replace("教2", "9");
                if (num >= 1 && num <= 9 && selectedText == "")
                {
                    selectedText3 = "0" + selectedText3;
                }
                string selectedText2 = "24-" + selectedText + selectedText3;
                if (resourceManager.GetObject(selectedText2) == null)
                {
                    bool originalTopMost = this.TopMost;
                    this.TopMost = true;
                    MessageBox.Show(this, "正しい行路を選択してください", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.TopMost = originalTopMost;
                    return;
                }
                else
                {
                    Image myImage = (Image)resourceManager.GetObject(selectedText2);
                    pictureBox2.Image = myImage;
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "21-24")
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                ResourceManager resourceManager = new ResourceManager("tablet.Properties.Resources", assembly);
                string selectedText = comboBox2.Text;
                int last = selectedText.Length - 1;
                string selectedText3 = Regex.Replace(selectedText, @"[^0-9]", "");
                selectedText = Regex.Replace(selectedText, @"[0-9]", "");
                int num = int.Parse(selectedText3);
                selectedText = selectedText.Replace("平", "");
                selectedText = selectedText.Replace("変-", "2");
                selectedText = selectedText.Replace("準2", "3");
                selectedText = selectedText.Replace("普2", "3");
                selectedText = selectedText.Replace("教2", "9");
                if (num >= 1 && num <= 9 && selectedText == "")
                {
                    selectedText3 = "0" + selectedText3;
                }
                string selectedText2 = "23-" + selectedText + selectedText3;
                if (resourceManager.GetObject(selectedText2) == null)
                {
                    bool originalTopMost = this.TopMost;
                    this.TopMost = true;
                    MessageBox.Show(this, "正しい行路を選択してください", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.TopMost = originalTopMost;
                    return;
                }
                else
                {
                    Image myImage = (Image)resourceManager.GetObject(selectedText2);
                    pictureBox2.Image = myImage;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            ResourceManager resourceManager = new ResourceManager("tablet.Properties.Resources", assembly);
            string selectedText = comboBox3.Text;
            int last = selectedText.Length - 1;
            if (comboBox3.SelectedItem == null)
            {
                bool originalTopMost = this.TopMost;
                this.TopMost = true;
                MessageBox.Show(this, "スターフを選択してください", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.TopMost = originalTopMost;
                return;
            }
            string selectedText3 = Regex.Replace(selectedText, @"[^a-wA-W]", "");
            selectedText = Regex.Replace(selectedText, @"[a-wA-W]", "");
            selectedText = selectedText.Replace("回", "X");
            selectedText = selectedText.Replace("試", "Z");
            if (selectedText3 == "" && selectedText[0] != 'X' && selectedText[0] != 'Z')
            {
                selectedText3 = "L";
            }
            Image myImage = (Image)resourceManager.GetObject(selectedText3 + selectedText);
            pictureBox1.Image = myImage;
        }

        private Picture form3Instance;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1 != null && (form3Instance == null || form3Instance.IsDisposed))
            {
                Picture pictureForm = new Picture(pictureBox1.Image);
                form3Instance = pictureForm;
                form3Instance.Show();
            }
            else
            {
                form3Instance.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (form3Instance != null && !form3Instance.IsDisposed)
            {
                form3Instance.Size = new Size(282, 424);
            }
        }
        public static int f = 0;
        public static int time2 = 0;
        DigitalClock form4Instance;
        private AnalogClock? analogFormInstance;
        private void button6_Click(object sender, EventArgs e)
        {
            // 既存の time 計算ロジック
            if (comboBox1.SelectedItem == "11-13") time = 10;
            else if (comboBox1.SelectedItem == "15-17") time = 14;
            else if (comboBox1.SelectedItem == "18-20") time = 17;
            else if (comboBox1.SelectedItem == "07-09") time = 6;
            else if (comboBox1.SelectedItem == "21-23") time = 20;
            else if (comboBox1.SelectedItem == "18-24") time = 17;
            else if (comboBox1.SelectedItem == "21-24") time = 20;
            else time = 0;

            DigitalClock.time = time;
            DigitalClock.f = f;

            // インスタンスがないか破棄済みなら新規作成して表示
            if (form4Instance == null || form4Instance.IsDisposed)
            {
                form4Instance = new DigitalClock();
                form4Instance.Show();
                button6.BackColor = Color.LightGreen;
                return;
            }

            // 既存インスタンスが存在する場合は表示状態をトグルする
            if (!form4Instance.Visible)
            {
                // Hidden の場合は再表示
                var _ = form4Instance.Handle; // 必要ならハンドルを確保
                form4Instance.Show();
                button6.BackColor = Color.LightGreen;
            }
            else
            {
                // 表示中なら隠す（内部タイマーは継続）
                form4Instance.Hide();
                button6.BackColor = Color.White;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox2.Items.Clear();
            f = 0;
            time2 = 0;

            // コンボの基準は comboBox1 の選択値（comboBox3.SelectedItem を参照してはいけない）
            var selectedCombo1 = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedCombo1))
                return;

            // comboBox3 用のリソース名決定
            string fileName = selectedCombo1 switch
            {
                "07-09" => "07-09list.txt",
                "11-13" => "11-13list.txt",
                "15-17" => "15-17list.txt",
                "18-20" => "18-20list.txt",
                "21-23" => "21-23list.txt",
                "18-24" => "18-24list.txt",
                "21-24" => "21-24list.txt",
                "ダイヤ不定" => "ALL.txt",
                _ => null
            };

            if (string.IsNullOrEmpty(fileName))
                return;

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames()
                                       .FirstOrDefault(n => n.EndsWith(fileName, StringComparison.OrdinalIgnoreCase));

            if (resourceName == null)
            {
                bool originalTopMost = this.TopMost;
                this.TopMost = true;
                MessageBox.Show(this,
                                $"埋め込みリソース '{fileName}' が見つかりません。...",
                                "リソース エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                this.TopMost = originalTopMost;
                return;
            }

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    bool originalTopMost = this.TopMost;
                    this.TopMost = true;
                    MessageBox.Show(this,
                                    $"リソース '{fileName}' のストリームが取得できませんでした。",
                                    "リソース エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    this.TopMost = originalTopMost;
                    return;
                }

                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var content = reader.ReadToEnd();
                    var lines = content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    comboBox3.Items.AddRange(lines);
                    if (comboBox3.Items.Count > 0)
                        comboBox3.SelectedIndex = 0; // 1つ目を選択しておく
                }
            }

            // comboBox2 (ktlist) も comboBox1 の選択値を基に決定する
            string fileName2 = selectedCombo1 switch
            {
                "07-09" => "07-09ktlist.txt",
                "11-13" => "11-13ktlist.txt",
                "15-17" => "15-17ktlist.txt",
                "18-20" => "18-20ktlist.txt",
                "21-23" => "21-23ktlist.txt",
                "18-24" => "18-24ktlist.txt",
                "21-24" => "21-24ktlist.txt",
                "ダイヤ不定" => "ALLkt.txt",
                _ => null
            };

            if (string.IsNullOrEmpty(fileName2))
                return;

            var resourceName2 = assembly.GetManifestResourceNames()
                                        .FirstOrDefault(n => n.EndsWith(fileName2, StringComparison.OrdinalIgnoreCase));

            if (resourceName2 == null)
            {
                bool originalTopMost2 = this.TopMost;
                this.TopMost = true;
                MessageBox.Show(this,
                                $"埋め込みリソース '{fileName2}' が見つかりません。...",
                                "リソース エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                this.TopMost = originalTopMost2;
                return;
            }

            using (var stream2 = assembly.GetManifestResourceStream(resourceName2))
            {
                if (stream2 == null)
                {
                    bool originalTopMost2 = this.TopMost;
                    this.TopMost = true;
                    MessageBox.Show(this,
                                    $"リソース '{fileName2}' のストリームが取得できませんでした。",
                                    "リソース エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    this.TopMost = originalTopMost2;
                    return;
                }

                using (var reader2 = new StreamReader(stream2, Encoding.UTF8))
                {
                    var content2 = reader2.ReadToEnd();
                    var lines2 = content2.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    comboBox2.Items.AddRange(lines2);
                    if (comboBox2.Items.Count > 0)
                        comboBox2.SelectedIndex = 0;
                }
            }
        }

        private DigitalStaff form5Instance;

        int flg = 0;
        private void button8_Click(object sender, EventArgs e)
        {

            // インスタンスがないか破棄済みなら新規作成して表示
            if (form5Instance == null || form5Instance.IsDisposed)
            {
                if (comboBox3.SelectedItem == null)
                {
                    bool originalTopMost = this.TopMost;
                    this.TopMost = true;
                    MessageBox.Show(this, "スターフを選択してください", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.TopMost = originalTopMost;
                    return;
                }

                form5Instance = new DigitalStaff();
                form5Instance.LoadStaff(comboBox3.SelectedItem.ToString());
                form5Instance.Show();
                button8.BackColor = Color.LightGreen;
                return;
            }

            // 既に表示中なら閉じる
            form5Instance.Close();
            button8.BackColor = Color.White;
        }
        private 運転通達受領 form6Instance;
        private void button9_Click(object sender, EventArgs e)
        {
            if(form6Instance == null || form6Instance.IsDisposed)
            {
                form6Instance = new 運転通達受領();
                form6Instance.Show();
                button9.BackColor = Color.LightGreen;
                return;
            }
            else
            {
                form6Instance.Close();
                button9.BackColor = Color.White;
                return;
            }
        }

        private void M_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (form2Instance != null && !form2Instance.IsDisposed)
            {
                form2Instance.Close();
            }
            if (form3Instance != null && !form3Instance.IsDisposed)
            {
                form3Instance.Close();
            }
            if (form4Instance != null && !form4Instance.IsDisposed)
            {
                try
                {
                    // アプリ終了時は明示的に実際に閉じる
                    form4Instance.AllowRealClose = true;
                    form4Instance.Close();
                }
                catch
                {
                    form4Instance.Dispose();
                }
            }
            // 追加：アナログ時計を閉じる
            if (analogFormInstance != null && !analogFormInstance.IsDisposed)
            {
                analogFormInstance.Close();
            }
            if (form5Instance != null && !form5Instance.IsDisposed)
            {
                form5Instance.Close();
            }
            if (form6Instance != null && !form6Instance.IsDisposed)
            {
                form6Instance.Close();
            }
        }

        private void M_Resize(object sender, EventArgs e)
        {
            scaler?.ScaleToCurrentSize(this, controlScalerProvider1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // トグルでアナログ時計を表示／非表示する
            if (analogFormInstance == null || analogFormInstance.IsDisposed)
            {
                analogFormInstance = new AnalogClock(form4Instance);

                analogFormInstance.Show();
                button7.BackColor = Color.LightGreen;
            }
            else
            {
                analogFormInstance.Close();
                button7.BackColor = Color.White;
            }
        }
    }
}