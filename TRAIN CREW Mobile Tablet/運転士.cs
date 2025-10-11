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
        int time = 0;
        public M()
        {
            InitializeComponent();
            this.AcceptButton = button4;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
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
                    MessageBox.Show("正しい行路を選択してください");
                    return;
                }
                else
                {
                    Image myImage = (Image)resourceManager.GetObject(selectedText2);
                    pictureBox2.Image = myImage;
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "1517")
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
                    MessageBox.Show("正しい行路を選択してください");
                    return;
                }
                else
                {
                    Image myImage = (Image)resourceManager.GetObject(selectedText2);
                    pictureBox2.Image = myImage;
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "1820")
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
                    MessageBox.Show("正しい行路を選択してください");
                    return;
                }
                else
                {
                    Image myImage = (Image)resourceManager.GetObject(selectedText2);
                    pictureBox2.Image = myImage;
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "0709")
            {
                MessageBox.Show("0709ダイヤは現在実装されておりません");
                return;
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
                string selectedText2 = "07-" + selectedText + selectedText3;
                MessageBox.Show(selectedText2);
                if (resourceManager.GetObject(selectedText2) == null)
                {
                    MessageBox.Show("正しい行路を選択してください");
                    return;
                }
                else
                {
                    Image myImage = (Image)resourceManager.GetObject(selectedText2);
                    pictureBox2.Image = myImage;
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "2123")
            {
                MessageBox.Show("2123ダイヤは現在実装されておりません");
                return;
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
                    MessageBox.Show("正しい行路を選択してください");
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
                MessageBox.Show("スターフを選択してください");
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

        DigitalClock form4Instance;
        private void button6_Click(object sender, EventArgs e)
        {
            if (form4Instance == null || form4Instance.IsDisposed)
            {
                if (comboBox1.SelectedItem == "1113")
                {
                    time = 10;
                }
                else if (comboBox1.SelectedItem == "1517")
                {
                    time = 14;
                }
                else if (comboBox1.SelectedItem == "1820")
                {
                    time = 17;
                }
                else if (comboBox1.SelectedItem == "0709")
                {
                    time = 6;
                }
                else if (comboBox1.SelectedItem == "2123")
                {
                    time = 20;
                }
                DigitalClock.time = time;
                form4Instance = new DigitalClock();
                form4Instance.Show();
                button6.BackColor = Color.LightGreen;
                return;
            }
            else
            {
                form4Instance.Close();
                button6.BackColor = Color.White;
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
                form4Instance.Close();
            }
        }
    }
}