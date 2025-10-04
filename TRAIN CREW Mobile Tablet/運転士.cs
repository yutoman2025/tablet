using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using tablet;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace test
{
    public partial class M : Form
    {
        public M()
        {
            InitializeComponent();
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
                MessageBox.Show("ダイヤまたは行路を選択してください");
                return;
            }
            else if (comboBox1.SelectedItem.ToString() == "1113")
            {
                if (comboBox2.SelectedItem.ToString() == "平1")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_01;
                }
                else if (comboBox2.SelectedItem.ToString() == "平2")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_02;
                }
                else if (comboBox2.SelectedItem.ToString() == "平3")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_03;
                }
                else if (comboBox2.SelectedItem.ToString() == "平4")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_04;
                }
                else if (comboBox2.SelectedItem.ToString() == "平5")
                {
                    MessageBox.Show("1113ダイヤには平5はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平6")
                {
                    MessageBox.Show("1113ダイヤには平6はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平7")
                {
                    MessageBox.Show("1113ダイヤには平7はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平8")
                {
                    MessageBox.Show("1113ダイヤには平8はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平9")
                {
                    MessageBox.Show("1113ダイヤには平9はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平10")
                {
                    MessageBox.Show("1113ダイヤには平10はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平11")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_11;
                }
                else if (comboBox2.SelectedItem.ToString() == "平12")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_12;
                }
                else if (comboBox2.SelectedItem.ToString() == "平13")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_13;
                }
                else if (comboBox2.SelectedItem.ToString() == "平14")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_14;
                }
                else if (comboBox2.SelectedItem.ToString() == "平151")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_151;
                }
                else if (comboBox2.SelectedItem.ToString() == "平152")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_152;
                }
                else if (comboBox2.SelectedItem.ToString() == "平153")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_153;
                }
                else if (comboBox2.SelectedItem.ToString() == "平154")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_154;
                }
                else if (comboBox2.SelectedItem.ToString() == "平155")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_155;
                }
                else if (comboBox2.SelectedItem.ToString() == "平156")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_156;
                }
                else if (comboBox2.SelectedItem.ToString() == "平157")
                {
                    MessageBox.Show("1113ダイヤには平157はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平566")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_566;
                    pictureBox1.Image = tablet.Properties.Resources.A11566;
                }
                else if (comboBox2.SelectedItem.ToString() == "変-平5")
                {
                    MessageBox.Show("1113ダイヤには変-平5はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "変-平9")
                {
                    MessageBox.Show("1113ダイヤには変-平9はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "変-平13")
                {
                    MessageBox.Show("1113ダイヤには変-平13はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "変-平151")
                {
                    MessageBox.Show("1113ダイヤには変-平151はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "普変-平1")
                {
                    MessageBox.Show("1113ダイヤには普変-平1はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "普変-平2")
                {
                    MessageBox.Show("1113ダイヤには普変-平2はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "普変-平7")
                {
                    MessageBox.Show("1113ダイヤには普変-平7はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "普変-平8")
                {
                    MessageBox.Show("1113ダイヤには普変-平8はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平3")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_403;
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平4")
                {
                    MessageBox.Show("1113ダイヤには準変-平4はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平5")
                {
                    MessageBox.Show("1113ダイヤには準変-平5はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平6")
                {
                    MessageBox.Show("1113ダイヤには準変-平6はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平11")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_411;
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平12")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_412;
                }
                else if (comboBox2.SelectedItem.ToString() == "特変-平551")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_551;
                }
                else if (comboBox2.SelectedItem.ToString() == "特変-平552")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_552;
                }
                else if (comboBox2.SelectedItem.ToString() == "教変-平151")
                {
                    MessageBox.Show("1113ダイヤには教変-平151はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "教変-平157")
                {
                    MessageBox.Show("1113ダイヤには教変-平157はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "教変-平551")
                {
                    MessageBox.Show("1113ダイヤには教変-平551はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "教変-平552")
                {
                    MessageBox.Show("1113ダイヤには教変-平552はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "臨-平848")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_848;
                }
                else if (comboBox2.SelectedItem.ToString() == "臨-平849")
                {
                    pictureBox2.Image = tablet.Properties.Resources._11_849;
                }
                else
                {
                    MessageBox.Show("行路を選択してください");
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "1517")
            {
                if (comboBox2.SelectedItem.ToString() == "平1")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_01;
                }
                else if (comboBox2.SelectedItem.ToString() == "平2")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_02;
                }
                else if (comboBox2.SelectedItem.ToString() == "平3")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_03;
                }
                else if (comboBox2.SelectedItem.ToString() == "平4")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_04;
                }
                else if (comboBox2.SelectedItem.ToString() == "平5")
                {
                    MessageBox.Show("1517ダイヤには平5はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平6")
                {
                    MessageBox.Show("1517ダイヤには平6はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平7")
                {
                    MessageBox.Show("1517ダイヤには平7はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平8")
                {
                    MessageBox.Show("1517ダイヤには平8はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平9")
                {
                    MessageBox.Show("1517ダイヤには平9はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平10")
                {
                    MessageBox.Show("1517ダイヤには平10はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平11")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_11;
                }
                else if (comboBox2.SelectedItem.ToString() == "平12")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_12;
                }
                else if (comboBox2.SelectedItem.ToString() == "平13")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_13;
                }
                else if (comboBox2.SelectedItem.ToString() == "平14")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_14;
                }
                else if (comboBox2.SelectedItem.ToString() == "平151")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_151;
                }
                else if (comboBox2.SelectedItem.ToString() == "平152")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_152;
                }
                else if (comboBox2.SelectedItem.ToString() == "平153")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_153;
                }
                else if (comboBox2.SelectedItem.ToString() == "平154")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_154;
                }
                else if (comboBox2.SelectedItem.ToString() == "平155")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_155;
                }
                else if (comboBox2.SelectedItem.ToString() == "平156")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_156;
                }
                else if (comboBox2.SelectedItem.ToString() == "平157")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_157;
                }
                else if (comboBox2.SelectedItem.ToString() == "平566")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_566;
                    pictureBox1.Image = tablet.Properties.Resources.A15566;
                }
                else if (comboBox2.SelectedItem.ToString() == "変-平5")
                {
                    MessageBox.Show("1517ダイヤには変-平5はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "変-平9")
                {
                    MessageBox.Show("1517ダイヤには変-平9はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "変-平13")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_413;
                }
                else if (comboBox2.SelectedItem.ToString() == "変-平151")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_4151;
                }
                else if (comboBox2.SelectedItem.ToString() == "普変-平1")
                {
                    MessageBox.Show("1517ダイヤには普変-平1はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "普変-平2")
                {
                    MessageBox.Show("1517ダイヤには普変-平2はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "普変-平7")
                {
                    MessageBox.Show("1517ダイヤには普変-平7はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "普変-平8")
                {
                    MessageBox.Show("1517ダイヤには普変-平8はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平3")
                {
                    MessageBox.Show("1517ダイヤには準変-平3はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平4")
                {
                    MessageBox.Show("1517ダイヤには準変-平4はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平5")
                {
                    MessageBox.Show("1517ダイヤには準変-平5はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平6")
                {
                    MessageBox.Show("1517ダイヤには準変-平6はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平11")
                {
                    MessageBox.Show("1517ダイヤには準変-平11はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平12")
                {
                    MessageBox.Show("1517ダイヤには準変-平12はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "特変-平551")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_9551;
                }
                else if (comboBox2.SelectedItem.ToString() == "特変-平552")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_9552;
                }
                else if (comboBox2.SelectedItem.ToString() == "教変-平151")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_9151;
                }
                else if (comboBox2.SelectedItem.ToString() == "教変-平157")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_9157;
                }
                else if (comboBox2.SelectedItem.ToString() == "教変-平551")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_9551;
                }
                else if (comboBox2.SelectedItem.ToString() == "教変-平552")
                {
                    pictureBox2.Image = tablet.Properties.Resources._15_9552;
                }
                else if (comboBox2.SelectedItem.ToString() == "臨-平848")
                {
                    MessageBox.Show("1517ダイヤには臨-平848はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "臨-平849")
                {
                    MessageBox.Show("1517ダイヤには臨-平849はありません");
                }
                else
                {
                    MessageBox.Show("行路を選択してください");
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "1820")
            {
                if (comboBox2.SelectedItem.ToString() == "平1")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_01;
                }
                else if (comboBox2.SelectedItem.ToString() == "平2")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_02;
                }
                else if (comboBox2.SelectedItem.ToString() == "平3")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_03;
                }
                else if (comboBox2.SelectedItem.ToString() == "平4")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_04;
                }
                else if (comboBox2.SelectedItem.ToString() == "平5")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_05;
                }
                else if (comboBox2.SelectedItem.ToString() == "平6")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_06;
                }
                else if (comboBox2.SelectedItem.ToString() == "平7")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_07;
                }
                else if (comboBox2.SelectedItem.ToString() == "平8")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_08;
                }
                else if (comboBox2.SelectedItem.ToString() == "平9")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_09;
                }
                else if (comboBox2.SelectedItem.ToString() == "平10")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_10;
                }
                else if (comboBox2.SelectedItem.ToString() == "平11")
                {
                    MessageBox.Show("1820ダイヤには平11はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平12")
                {
                    MessageBox.Show("1820ダイヤには平12はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平13")
                {
                    MessageBox.Show("1820ダイヤには平13はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平14")
                {
                    MessageBox.Show("1820ダイヤには平14はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平151")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_151;
                }
                else if (comboBox2.SelectedItem.ToString() == "平152")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_152;
                }
                else if (comboBox2.SelectedItem.ToString() == "平153")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_153;
                }
                else if (comboBox2.SelectedItem.ToString() == "平154")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_154;
                }
                else if (comboBox2.SelectedItem.ToString() == "平155")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_155;
                }
                else if (comboBox2.SelectedItem.ToString() == "平156")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_156;
                }
                else if (comboBox2.SelectedItem.ToString() == "平157")
                {
                    MessageBox.Show("1820ダイヤには平157はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "平566")
                {
                    MessageBox.Show("1820ダイヤには平566はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "変-平5")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_205;
                }
                else if (comboBox2.SelectedItem.ToString() == "変-平9")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_209;
                }
                else if (comboBox2.SelectedItem.ToString() == "変-平13")
                {
                    MessageBox.Show("1820ダイヤには変-平13はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "変-平151")
                {
                    MessageBox.Show("1820ダイヤには変-平151はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "普変-平1")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_3001;
                }
                else if (comboBox2.SelectedItem.ToString() == "普変-平2")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_3002;
                }
                else if (comboBox2.SelectedItem.ToString() == "普変-平7")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_3007;
                }
                else if (comboBox2.SelectedItem.ToString() == "普変-平8")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_3008;
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平3")
                {
                    MessageBox.Show("1820ダイヤには準変-平3はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平4")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_3004;
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平5")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_3005;
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平6")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_3006;
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平11")
                {
                    MessageBox.Show("1820ダイヤには準変-平11はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "準変-平12")
                {
                    MessageBox.Show("1820ダイヤには準変-平12はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "特変-平551")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_3551;
                }
                else if (comboBox2.SelectedItem.ToString() == "特変-平552")
                {
                    pictureBox2.Image = tablet.Properties.Resources._18_3552;
                }
                else if (comboBox2.SelectedItem.ToString() == "教変-平151")
                {
                    MessageBox.Show("1820ダイヤには教変-平151はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "教変-平157")
                {
                    MessageBox.Show("1820ダイヤには教変-平157はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "教変-平551")
                {
                    MessageBox.Show("1820ダイヤには教変-平551はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "教変-平552")
                {
                    MessageBox.Show("1820ダイヤには教変-平552はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "臨-平848")
                {
                    MessageBox.Show("1820ダイヤには臨-平848はありません");
                }
                else if (comboBox2.SelectedItem.ToString() == "臨-平849")
                {
                    MessageBox.Show("1820ダイヤには臨-平849はありません");
                }
                else
                {
                    MessageBox.Show("行路を選択してください");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            ResourceManager resourceManager = new ResourceManager("tablet.Properties.Resources", assembly);
            string selectedText = comboBox3.Text;
            int last = selectedText.Length - 1;
            if (selectedText == null)
            {
                MessageBox.Show("行路を選択してください");
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
    }
}