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
            Button button2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(起動画面));
            M = new Button();
            One = new Button();
            C = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // M
            // 
            resources.ApplyResources(M, "M");
            M.BackColor = Color.FromArgb(255, 255, 128);
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
            C.BackColor = Color.FromArgb(255, 255, 128);
            C.FlatAppearance.BorderColor = Color.Black;
            C.Name = "C";
            C.UseVisualStyleBackColor = false;
            C.Click += this.C_Click;
            // 
            // 起動画面
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 255);
            Controls.Add(C);
            Controls.Add(One);
            Controls.Add(button2);
            Controls.Add(M);
            MaximizeBox = false;
            Name = "起動画面";
            ResumeLayout(false);
        }

        #endregion

        private Button M;
        private Button button2;
        private Button One;
        private Button C;
    }
}
