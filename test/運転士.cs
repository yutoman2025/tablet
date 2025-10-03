using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tablet;
using static System.Windows.Forms.DataFormats;

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
            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("列車番号を選択してください");
                return;
            }
            else if (comboBox3.SelectedItem == "回1005A")
            {
                pictureBox1.Image = tablet.Properties.Resources.X1005A;
            }
            else if (comboBox3.SelectedItem == "回1409A")
            {
                pictureBox1.Image = tablet.Properties.Resources.X1409A;
            }
            else if (comboBox3.SelectedItem == "1019A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1019;
            }
            else if (comboBox3.SelectedItem == "1021A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1021;
            }
            else if (comboBox3.SelectedItem == "1103A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1103;
            }
            else if (comboBox3.SelectedItem == "1118A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1118;
            }
            else if (comboBox3.SelectedItem == "1206A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1206;
            }
            else if (comboBox3.SelectedItem == "1212A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1212;
            }
            else if (comboBox3.SelectedItem == "1215A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1215;
            }
            else if (comboBox3.SelectedItem == "1320A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1320;
            }
            else if (comboBox3.SelectedItem == "1407A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1407;
            }
            else if (comboBox3.SelectedItem == "1419A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1419;
            }
            else if (comboBox3.SelectedItem == "1508A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1508;
            }
            else if (comboBox3.SelectedItem == "1513A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1513;
            }
            else if (comboBox3.SelectedItem == "1518A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1518;
            }
            else if (comboBox3.SelectedItem == "1603A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1603;
            }
            else if (comboBox3.SelectedItem == "1604A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1604;
            }
            else if (comboBox3.SelectedItem == "1612A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1612;
            }
            else if (comboBox3.SelectedItem == "1706A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1706;
            }
            else if (comboBox3.SelectedItem == "1810A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1810;
            }
            else if (comboBox3.SelectedItem == "1814A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1814;
            }
            else if (comboBox3.SelectedItem == "1817A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1817;
            }
            else if (comboBox3.SelectedItem == "1819A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1819;
            }
            else if (comboBox3.SelectedItem == "1908A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1908;
            }
            else if (comboBox3.SelectedItem == "1913A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1913;
            }
            else if (comboBox3.SelectedItem == "1918A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A1918;
            }
            else if (comboBox3.SelectedItem == "2016A")
            {
                pictureBox1.Image = tablet.Properties.Resources.A2016;
            }
            else if (comboBox3.SelectedItem == "1787B")
            {
                pictureBox1.Image = tablet.Properties.Resources.B1787;
            }
            else if (comboBox3.SelectedItem == "1869B")
            {
                pictureBox1.Image = tablet.Properties.Resources.B1869;
            }
            else if (comboBox3.SelectedItem == "1882B")
            {
                pictureBox1.Image = tablet.Properties.Resources.B1882;
            }
            else if (comboBox3.SelectedItem == "1883B")
            {
                pictureBox1.Image = tablet.Properties.Resources.B1883;
            }
            else if (comboBox3.SelectedItem == "1977B")
            {
                pictureBox1.Image = tablet.Properties.Resources.B1977;
            }
            else if (comboBox3.SelectedItem == "4757B")
            {
                pictureBox1.Image = tablet.Properties.Resources.B4757;
            }
            else if (comboBox3.SelectedItem == "1182C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1182;
            }
            else if (comboBox3.SelectedItem == "1183C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1183;
            }
            else if (comboBox3.SelectedItem == "1184C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1184;
            }
            else if (comboBox3.SelectedItem == "1185C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1185;
            }
            else if (comboBox3.SelectedItem == "1282C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1282;
            }
            else if (comboBox3.SelectedItem == "1283C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1283;
            }
            else if (comboBox3.SelectedItem == "1284C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1284;
            }
            else if (comboBox3.SelectedItem == "1285C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1285;
            }
            else if (comboBox3.SelectedItem == "1298C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1298;
            }
            else if (comboBox3.SelectedItem == "1299C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1299;
            }
            else if (comboBox3.SelectedItem == "1582C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1582;
            }
            else if (comboBox3.SelectedItem == "1583C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1583;
            }
            else if (comboBox3.SelectedItem == "1584C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1584;
            }
            else if (comboBox3.SelectedItem == "1585C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1585;
            }
            else if (comboBox3.SelectedItem == "1598C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1598;
            }
            else if (comboBox3.SelectedItem == "1599C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1599;
            }
            else if (comboBox3.SelectedItem == "1682C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1682;
            }
            else if (comboBox3.SelectedItem == "1683C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1683;
            }
            else if (comboBox3.SelectedItem == "1684C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1684;
            }
            else if (comboBox3.SelectedItem == "1685C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1685;
            }
            else if (comboBox3.SelectedItem == "1698C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1698;
            }
            else if (comboBox3.SelectedItem == "1699C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1699;
            }
            else if (comboBox3.SelectedItem == "1791C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1791;
            }
            else if (comboBox3.SelectedItem == "1884C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1884;
            }
            else if (comboBox3.SelectedItem == "1885C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1885;
            }
            else if (comboBox3.SelectedItem == "1886C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1886;
            }
            else if (comboBox3.SelectedItem == "1887C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1887;
            }
            else if (comboBox3.SelectedItem == "1890C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1890;
            }
            else if (comboBox3.SelectedItem == "1898C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1898;
            }
            else if (comboBox3.SelectedItem == "1899C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1899;
            }
            else if (comboBox3.SelectedItem == "1984C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1984;
            }
            else if (comboBox3.SelectedItem == "1985C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1985;
            }
            else if (comboBox3.SelectedItem == "1986C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1986;
            }
            else if (comboBox3.SelectedItem == "1987C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1987;
            }
            else if (comboBox3.SelectedItem == "1990C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1990;
            }
            else if (comboBox3.SelectedItem == "1998C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1998;
            }
            else if (comboBox3.SelectedItem == "1999C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C1999;
            }
            else if (comboBox3.SelectedItem == "2098C")
            {
                pictureBox1.Image = tablet.Properties.Resources.C2098;
            }
            else if (comboBox3.SelectedItem == "回1666")
            {
                pictureBox1.Image = tablet.Properties.Resources.X1666;
            }
            else if (comboBox3.SelectedItem == "試9091")
            {
                pictureBox1.Image = tablet.Properties.Resources.Z9091;
            }
            else if (comboBox3.SelectedItem == "試9093")
            {
                pictureBox1.Image = tablet.Properties.Resources.Z9093;
            }
            else if (comboBox3.SelectedItem == "試9190")
            {
                pictureBox1.Image = tablet.Properties.Resources.Z9190;
            }
            else if (comboBox3.SelectedItem == "試9191")
            {
                pictureBox1.Image = tablet.Properties.Resources.Z9191;
            }
            else if (comboBox3.SelectedItem == "試9192")
            {
                pictureBox1.Image = tablet.Properties.Resources.Z9192;
            }
            else if (comboBox3.SelectedItem == "試9193")
            {
                pictureBox1.Image = tablet.Properties.Resources.Z9193;
            }
            else if (comboBox3.SelectedItem == "試9290")
            {
                pictureBox1.Image = tablet.Properties.Resources.Z9290;
            }
            else if (comboBox3.SelectedItem == "試9292")
            {
                pictureBox1.Image = tablet.Properties.Resources.Z9292;
            }
        }
    }
}