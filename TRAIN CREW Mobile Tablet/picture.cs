using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test;

namespace tablet
{
    public partial class Picture : Form
    {
        private double originalAspectRatio;
        private bool isResizing = false;
        private bool isDragging = false;
        private Point mousePosition;
        public Picture()
        {
            InitializeComponent();
            this.Load += (s, e) => originalAspectRatio = (double)this.Width / this.Height;
            this.ResizeEnd += Picture_ResizeEnd;
        }

        public Picture(Image image)
        {
            InitializeComponent();
            pictureBox1.Image = image; // 画像をPictureBoxに設定
        }

        private void Picture_Load(object sender, EventArgs e)
        {
            originalAspectRatio = (double)this.Width / this.Height;
            // 設定からウィンドウの位置とサイズを復元
            if (Properties.Settings.Default.WindowSize != Size.Empty)
            {
                this.Size = Properties.Settings.Default.WindowSize;
            }
            if (Properties.Settings.Default.WindowLocation != Point.Empty)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Properties.Settings.Default.WindowLocation;
            }
            
        }

        private void Picture_ResizeEnd(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.SuspendLayout();

                double currentAspectRatio = (double)this.Width / this.Height;

                if (currentAspectRatio > originalAspectRatio)
                {
                    // 幅が基準
                    this.Height = (int)(this.Width / originalAspectRatio);
                }
                else
                {
                    // 高さが基準
                    this.Width = (int)(this.Height * originalAspectRatio);
                }

                this.ResumeLayout();
            }
        }

        private void Picture_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.WindowSize = this.Size;
                Properties.Settings.Default.WindowLocation = this.Location;
            }
            Properties.Settings.Default.WindowState = this.WindowState;
            Properties.Settings.Default.Save();
        }
        private bool IsOnScreen(System.Drawing.Point location, System.Drawing.Size size)
        {
            Rectangle screenBounds = Screen.GetBounds(location);
            Rectangle windowBounds = new Rectangle(location, size);
            return screenBounds.Contains(windowBounds);
        }
    }
}
