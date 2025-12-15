using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tablet;

namespace test
{
    public partial class C : Form
    {
        public C()
        {
            InitializeComponent();
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

        private 放送選択 form1Instance;
        private void button5_Click(object sender, EventArgs e)
        {
            /*bool originalTopMost = this.TopMost;
            this.TopMost = true;
            MessageBox.Show("只今対応していません。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.TopMost = originalTopMost;*/
            if (form1Instance == null || form1Instance.IsDisposed)
            {
                form1Instance = new 放送選択();
                form1Instance.Show();
                button5.BackColor = Color.YellowGreen;
                return;
            }
            else
            {
                form1Instance.Close();
                button5.BackColor = Color.White;
                return;
            }
        }
        int flg = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            string file = 放送選択.file;
            string file2 = 放送選択.file2;
            if (file != null)
            {
                using var player = new SoundPlayer(file);
                if (flg == 0)
                {
                    player.Play();
                    if (file2 != null)
                    {
                        using var player2 = new SoundPlayer(file2);
                        Task.Delay(100).ContinueWith(_ => player2.Play());
                    }
                    flg = 1;
                }
                else
                {
                    player.Stop();
                    flg = 0;    
                }
            }
        }
    }
}
