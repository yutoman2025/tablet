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
            button5 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
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
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Yu Gothic UI", 40F);
            button4.Location = new Point(63, 172);
            button4.Name = "button4";
            button4.Size = new Size(193, 183);
            button4.TabIndex = 5;
            button4.Text = "前";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(680, 12);
            button5.Name = "button5";
            button5.Size = new Size(108, 42);
            button5.TabIndex = 6;
            button5.Text = "放送設定";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(255, 192, 192);
            label1.Font = new Font("Yu Gothic UI", 20F);
            label1.Location = new Point(311, 12);
            label1.Name = "label1";
            label1.Size = new Size(193, 37);
            label1.TabIndex = 7;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(0, 0, 64);
            label2.Font = new Font("Yu Gothic UI", 20F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(595, 404);
            label2.Name = "label2";
            label2.Size = new Size(193, 37);
            label2.TabIndex = 8;
            label2.Text = "行き先";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(0, 0, 64);
            label3.Font = new Font("Yu Gothic UI", 20F);
            label3.ForeColor = Color.MediumOrchid;
            label3.Location = new Point(396, 404);
            label3.Name = "label3";
            label3.Size = new Size(193, 37);
            label3.TabIndex = 9;
            label3.Text = "種別";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 192);
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "C";
            Text = "車掌";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private ProgressBar progressBar1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        public Label label1;
        public Label label2;
        public Label label3;
    }
}