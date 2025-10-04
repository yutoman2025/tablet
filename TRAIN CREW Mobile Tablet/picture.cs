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

        private bool isDragging = false;
        private Point mousePosition;
        public Picture()
        {
            InitializeComponent();
        }

        public Picture(Image image)
        {
            InitializeComponent();
            pictureBox1.Image = image; // 画像をPictureBoxに設定
        }
    }
}
