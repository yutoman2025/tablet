namespace test
{
    partial class 起動画面
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(起動画面));
            M = new Button();
            One = new Button();
            C = new Button();
            button3 = new Button();
            label1 = new Label();
            controlScalerProvider1 = new tablet.ControlScalerProvider();
            SuspendLayout();
            // 
            // M
            // 
            resources.ApplyResources(M, "M");
            controlScalerProvider1.SetAnchor(M, ControlAnchor.TopLeft);
            M.BackColor = Color.Cyan;
            M.FlatAppearance.BorderColor = Color.Black;
            controlScalerProvider1.SetFontResizable(M, ControlExpantion.AllowBoth);
            controlScalerProvider1.SetMovable(M, true);
            M.Name = "M";
            controlScalerProvider1.SetRefLocation(M, new Point(0, 10));
            controlScalerProvider1.SetResizableX(M, ControlExpantion.AllowBoth);
            controlScalerProvider1.SetResizableY(M, ControlExpantion.AllowBoth);
            M.UseVisualStyleBackColor = false;
            M.Click += M_Click;
            // 
            // One
            // 
            resources.ApplyResources(One, "One");
            controlScalerProvider1.SetAnchor(One, ControlAnchor.TopLeft);
            One.BackColor = Color.FromArgb(128, 255, 128);
            One.FlatAppearance.BorderColor = Color.Black;
            controlScalerProvider1.SetFontResizable(One, ControlExpantion.AllowBoth);
            controlScalerProvider1.SetMovable(One, true);
            One.Name = "One";
            controlScalerProvider1.SetRefLocation(One, new Point(0, 10));
            controlScalerProvider1.SetResizableX(One, ControlExpantion.AllowBoth);
            controlScalerProvider1.SetResizableY(One, ControlExpantion.AllowBoth);
            One.UseVisualStyleBackColor = false;
            One.Click += One_Click;
            // 
            // C
            // 
            resources.ApplyResources(C, "C");
            controlScalerProvider1.SetAnchor(C, ControlAnchor.TopLeft);
            C.BackColor = Color.FromArgb(0, 192, 192);
            C.FlatAppearance.BorderColor = Color.Black;
            controlScalerProvider1.SetFontResizable(C, ControlExpantion.AllowBoth);
            controlScalerProvider1.SetMovable(C, true);
            C.Name = "C";
            controlScalerProvider1.SetRefLocation(C, new Point(0, 10));
            controlScalerProvider1.SetResizableX(C, ControlExpantion.AllowBoth);
            controlScalerProvider1.SetResizableY(C, ControlExpantion.AllowBoth);
            C.UseVisualStyleBackColor = false;
            C.Click += C_Click;
            // 
            // button3
            // 
            resources.ApplyResources(button3, "button3");
            controlScalerProvider1.SetAnchor(button3, ControlAnchor.TopLeft);
            button3.BackColor = Color.White;
            controlScalerProvider1.SetFontResizable(button3, ControlExpantion.NotAllow);
            controlScalerProvider1.SetMovable(button3, true);
            button3.Name = "button3";
            controlScalerProvider1.SetRefLocation(button3, new Point(0, 0));
            controlScalerProvider1.SetResizableX(button3, ControlExpantion.NotAllow);
            controlScalerProvider1.SetResizableY(button3, ControlExpantion.NotAllow);
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            controlScalerProvider1.SetAnchor(label1, ControlAnchor.BottomRight);
            controlScalerProvider1.SetFontResizable(label1, ControlExpantion.NotAllow);
            controlScalerProvider1.SetMovable(label1, true);
            label1.Name = "label1";
            controlScalerProvider1.SetRefLocation(label1, new Point(0, 0));
            controlScalerProvider1.SetResizableX(label1, ControlExpantion.NotAllow);
            controlScalerProvider1.SetResizableY(label1, ControlExpantion.NotAllow);
            // 
            // 起動画面
            // 
            resources.ApplyResources(this, "$this");
            controlScalerProvider1.SetAnchor(this, ControlAnchor.TopLeft);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 192);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(C);
            Controls.Add(One);
            Controls.Add(M);
            controlScalerProvider1.SetFontResizable(this, ControlExpantion.NotAllow);
            MaximizeBox = false;
            controlScalerProvider1.SetMovable(this, false);
            Name = "起動画面";
            controlScalerProvider1.SetRefLocation(this, new Point(0, 0));
            controlScalerProvider1.SetResizableX(this, ControlExpantion.NotAllow);
            controlScalerProvider1.SetResizableY(this, ControlExpantion.NotAllow);
            Resize += 起動画面_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button M;
        private Button One;
        private Button C;
        private Button button3;
        private Label label1;
        private tablet.ControlScalerProvider controlScalerProvider1;
    }
}
