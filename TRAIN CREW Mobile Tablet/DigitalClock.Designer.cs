namespace tablet
{
    partial class DigitalClock
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
            components = new System.ComponentModel.Container();
            Hlabel = new Label();
            Mlabel = new Label();
            Slabel = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            SuspendLayout();
            // 
            // Hlabel
            // 
            Hlabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Hlabel.BackColor = SystemColors.ActiveCaption;
            Hlabel.Font = new Font("游明朝 Demibold", 50F);
            Hlabel.Location = new Point(12, 53);
            Hlabel.Name = "Hlabel";
            Hlabel.RightToLeft = RightToLeft.Yes;
            Hlabel.Size = new Size(115, 107);
            Hlabel.TabIndex = 0;
            Hlabel.Text = "\r\n";
            Hlabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Mlabel
            // 
            Mlabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Mlabel.BackColor = SystemColors.ActiveCaption;
            Mlabel.Font = new Font("游明朝 Demibold", 50F);
            Mlabel.Location = new Point(134, 53);
            Mlabel.Name = "Mlabel";
            Mlabel.Size = new Size(115, 107);
            Mlabel.TabIndex = 1;
            Mlabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Slabel
            // 
            Slabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Slabel.BackColor = SystemColors.ActiveCaption;
            Slabel.Font = new Font("游明朝 Demibold", 50F);
            Slabel.Location = new Point(255, 53);
            Slabel.Name = "Slabel";
            Slabel.Size = new Size(115, 107);
            Slabel.TabIndex = 2;
            Slabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(109, 145);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(70, 23);
            button1.TabIndex = 4;
            button1.Text = "H+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(84, 12);
            button2.Name = "button2";
            button2.Size = new Size(70, 23);
            button2.TabIndex = 5;
            button2.Text = "H-";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(304, 0);
            button3.Name = "button3";
            button3.Size = new Size(70, 23);
            button3.TabIndex = 6;
            button3.Text = "TST";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(156, 12);
            button4.Name = "button4";
            button4.Size = new Size(70, 23);
            button4.TabIndex = 7;
            button4.Text = "M+";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(228, 12);
            button5.Name = "button5";
            button5.Size = new Size(70, 23);
            button5.TabIndex = 8;
            button5.Text = "M-";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(304, 29);
            button6.Name = "button6";
            button6.Size = new Size(70, 23);
            button6.TabIndex = 9;
            button6.Text = "JST";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // DigitalClock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 171);
            ControlBox = false;
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(Slabel);
            Controls.Add(Mlabel);
            Controls.Add(Hlabel);
            Name = "DigitalClock";
            Text = "DigitalClock";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Hlabel;
        private Label Mlabel;
        private Label Slabel;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}