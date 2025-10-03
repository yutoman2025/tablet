namespace test
{
    partial class C
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            progressBar1 = new ProgressBar();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "最前面切替";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(105, 81);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(559, 24);
            progressBar1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Font = new Font("Yu Gothic UI", 40F);
            button2.Location = new Point(562, 172);
            button2.Name = "button2";
            button2.Size = new Size(193, 183);
            button2.TabIndex = 3;
            button2.Text = "次";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Yu Gothic UI", 27F);
            button3.Location = new Point(311, 172);
            button3.Name = "button3";
            button3.Size = new Size(193, 183);
            button3.TabIndex = 4;
            button3.Text = "再生/停止";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Yu Gothic UI", 40F);
            button4.Location = new Point(58, 172);
            button4.Name = "button4";
            button4.Size = new Size(193, 183);
            button4.TabIndex = 5;
            button4.Text = "前";
            button4.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = tablet.Properties.Resources._11_566;
            pictureBox1.Location = new Point(29, 374);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(149, 51);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // C
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "C";
            Text = "車掌";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private ProgressBar progressBar1;
        private Button button2;
        private Button button3;
        private Button button4;
        private PictureBox pictureBox1;
    }
}