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
            controlScalerProvider1 = new ControlScalerProvider();
            SuspendLayout();
            // 
            // Hlabel
            // 
            controlScalerProvider1.SetAnchor(Hlabel, ControlAnchor.TopLeft);
            Hlabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Hlabel.BackColor = SystemColors.ActiveCaption;
            Hlabel.Font = new Font("游明朝 Demibold", 48F);
            controlScalerProvider1.SetFontResizable(Hlabel, ControlExpantion.AllowBoth);
            Hlabel.Location = new Point(12, 53);
            controlScalerProvider1.SetMovable(Hlabel, true);
            Hlabel.Name = "Hlabel";
            controlScalerProvider1.SetRefLocation(Hlabel, new Point(0, 0));
            controlScalerProvider1.SetResizableX(Hlabel, ControlExpantion.AllowBoth);
            controlScalerProvider1.SetResizableY(Hlabel, ControlExpantion.AllowBoth);
            Hlabel.RightToLeft = RightToLeft.Yes;
            Hlabel.Size = new Size(115, 107);
            Hlabel.TabIndex = 0;
            Hlabel.Text = "\r\n";
            Hlabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Mlabel
            // 
            controlScalerProvider1.SetAnchor(Mlabel, ControlAnchor.TopLeft);
            Mlabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Mlabel.BackColor = SystemColors.ActiveCaption;
            Mlabel.Font = new Font("游明朝 Demibold", 48F);
            controlScalerProvider1.SetFontResizable(Mlabel, ControlExpantion.AllowBoth);
            Mlabel.Location = new Point(134, 53);
            controlScalerProvider1.SetMovable(Mlabel, true);
            Mlabel.Name = "Mlabel";
            controlScalerProvider1.SetRefLocation(Mlabel, new Point(0, 0));
            controlScalerProvider1.SetResizableX(Mlabel, ControlExpantion.AllowBoth);
            controlScalerProvider1.SetResizableY(Mlabel, ControlExpantion.AllowBoth);
            Mlabel.Size = new Size(115, 107);
            Mlabel.TabIndex = 1;
            Mlabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Slabel
            // 
            controlScalerProvider1.SetAnchor(Slabel, ControlAnchor.TopLeft);
            Slabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Slabel.BackColor = SystemColors.ActiveCaption;
            Slabel.Font = new Font("游明朝 Demibold", 48F);
            controlScalerProvider1.SetFontResizable(Slabel, ControlExpantion.AllowBoth);
            Slabel.Location = new Point(255, 53);
            controlScalerProvider1.SetMovable(Slabel, true);
            Slabel.Name = "Slabel";
            controlScalerProvider1.SetRefLocation(Slabel, new Point(0, 0));
            controlScalerProvider1.SetResizableX(Slabel, ControlExpantion.AllowBoth);
            controlScalerProvider1.SetResizableY(Slabel, ControlExpantion.AllowBoth);
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
            controlScalerProvider1.SetAnchor(label1, ControlAnchor.TopLeft);
            label1.AutoSize = true;
            controlScalerProvider1.SetFontResizable(label1, ControlExpantion.NotAllow);
            label1.Location = new Point(109, 145);
            controlScalerProvider1.SetMovable(label1, false);
            label1.Name = "label1";
            controlScalerProvider1.SetRefLocation(label1, new Point(0, 0));
            controlScalerProvider1.SetResizableX(label1, ControlExpantion.NotAllow);
            controlScalerProvider1.SetResizableY(label1, ControlExpantion.NotAllow);
            label1.Size = new Size(0, 15);
            label1.TabIndex = 3;
            // 
            // button1
            // 
            controlScalerProvider1.SetAnchor(button1, ControlAnchor.TopLeft);
            controlScalerProvider1.SetFontResizable(button1, ControlExpantion.AllowShrinkingOnly);
            button1.Location = new Point(12, 12);
            controlScalerProvider1.SetMovable(button1, true);
            button1.Name = "button1";
            controlScalerProvider1.SetRefLocation(button1, new Point(0, 0));
            controlScalerProvider1.SetResizableX(button1, ControlExpantion.AllowBoth);
            controlScalerProvider1.SetResizableY(button1, ControlExpantion.AllowBoth);
            button1.Size = new Size(70, 23);
            button1.TabIndex = 4;
            button1.Text = "H+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            controlScalerProvider1.SetAnchor(button2, ControlAnchor.TopLeft);
            controlScalerProvider1.SetFontResizable(button2, ControlExpantion.AllowShrinkingOnly);
            button2.Location = new Point(84, 12);
            controlScalerProvider1.SetMovable(button2, true);
            button2.Name = "button2";
            controlScalerProvider1.SetRefLocation(button2, new Point(0, 0));
            controlScalerProvider1.SetResizableX(button2, ControlExpantion.AllowBoth);
            controlScalerProvider1.SetResizableY(button2, ControlExpantion.AllowBoth);
            button2.Size = new Size(70, 23);
            button2.TabIndex = 5;
            button2.Text = "H-";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            controlScalerProvider1.SetAnchor(button3, ControlAnchor.TopLeft);
            controlScalerProvider1.SetFontResizable(button3, ControlExpantion.AllowShrinkingOnly);
            button3.Location = new Point(301, 2);
            controlScalerProvider1.SetMovable(button3, true);
            button3.Name = "button3";
            controlScalerProvider1.SetRefLocation(button3, new Point(0, 0));
            controlScalerProvider1.SetResizableX(button3, ControlExpantion.AllowBoth);
            controlScalerProvider1.SetResizableY(button3, ControlExpantion.AllowBoth);
            button3.Size = new Size(70, 23);
            button3.TabIndex = 6;
            button3.Text = "TST";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            controlScalerProvider1.SetAnchor(button4, ControlAnchor.TopLeft);
            controlScalerProvider1.SetFontResizable(button4, ControlExpantion.AllowShrinkingOnly);
            button4.Location = new Point(156, 12);
            controlScalerProvider1.SetMovable(button4, true);
            button4.Name = "button4";
            controlScalerProvider1.SetRefLocation(button4, new Point(0, 0));
            controlScalerProvider1.SetResizableX(button4, ControlExpantion.AllowBoth);
            controlScalerProvider1.SetResizableY(button4, ControlExpantion.AllowBoth);
            button4.Size = new Size(70, 23);
            button4.TabIndex = 7;
            button4.Text = "M+";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            controlScalerProvider1.SetAnchor(button5, ControlAnchor.TopLeft);
            controlScalerProvider1.SetFontResizable(button5, ControlExpantion.AllowShrinkingOnly);
            button5.Location = new Point(228, 12);
            controlScalerProvider1.SetMovable(button5, true);
            button5.Name = "button5";
            controlScalerProvider1.SetRefLocation(button5, new Point(0, 0));
            controlScalerProvider1.SetResizableX(button5, ControlExpantion.AllowBoth);
            controlScalerProvider1.SetResizableY(button5, ControlExpantion.AllowBoth);
            button5.Size = new Size(70, 23);
            button5.TabIndex = 8;
            button5.Text = "M-";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            controlScalerProvider1.SetAnchor(button6, ControlAnchor.TopLeft);
            controlScalerProvider1.SetFontResizable(button6, ControlExpantion.AllowShrinkingOnly);
            button6.Location = new Point(301, 27);
            controlScalerProvider1.SetMovable(button6, true);
            button6.Name = "button6";
            controlScalerProvider1.SetRefLocation(button6, new Point(0, 0));
            controlScalerProvider1.SetResizableX(button6, ControlExpantion.AllowBoth);
            controlScalerProvider1.SetResizableY(button6, ControlExpantion.AllowBoth);
            button6.Size = new Size(70, 23);
            button6.TabIndex = 9;
            button6.Text = "JST";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // DigitalClock
            // 
            controlScalerProvider1.SetAnchor(this, ControlAnchor.TopLeft);
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 184);
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
            controlScalerProvider1.SetFontResizable(this, ControlExpantion.NotAllow);
            MinimumSize = new Size(300, 198);
            controlScalerProvider1.SetMovable(this, false);
            Name = "DigitalClock";
            controlScalerProvider1.SetRefLocation(this, new Point(0, 0));
            controlScalerProvider1.SetResizableX(this, ControlExpantion.NotAllow);
            controlScalerProvider1.SetResizableY(this, ControlExpantion.NotAllow);
            Text = "DigitalClock";
            TopMost = true;
            Resize += DigitalClock_Resize;
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
        private ControlScalerProvider controlScalerProvider1;
    }
}