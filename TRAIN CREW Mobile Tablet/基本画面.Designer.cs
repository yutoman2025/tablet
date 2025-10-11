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
            SuspendLayout();
            // 
            // M
            // 
            resources.ApplyResources(M, "M");
            M.BackColor = Color.Cyan;
            M.FlatAppearance.BorderColor = Color.Black;
            M.Name = "M";
            M.UseVisualStyleBackColor = false;
            M.Click += M_Click;
            // 
            // One
            // 
            resources.ApplyResources(One, "One");
            One.BackColor = Color.FromArgb(128, 255, 128);
            One.FlatAppearance.BorderColor = Color.Black;
            One.Name = "One";
            One.UseVisualStyleBackColor = false;
            One.Click += One_Click;
            // 
            // C
            // 
            resources.ApplyResources(C, "C");
            C.BackColor = Color.FromArgb(0, 192, 192);
            C.FlatAppearance.BorderColor = Color.Black;
            C.Name = "C";
            C.UseVisualStyleBackColor = false;
            C.Click += C_Click;
            // 
            // button3
            // 
            resources.ApplyResources(button3, "button3");
            button3.BackColor = Color.White;
            button3.Name = "button3";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // 起動画面
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 192);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(C);
            Controls.Add(One);
            Controls.Add(M);
            MaximizeBox = false;
            Name = "起動画面";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button M;
        private Button One;
        private Button C;
        private Button button3;
        private Label label1;
    }
}
