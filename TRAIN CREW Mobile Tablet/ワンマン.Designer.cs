namespace test
{
    partial class One
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
            button2 = new Button();
            comboBox2 = new ComboBox();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "最前面切替";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(680, 12);
            button2.Name = "button2";
            button2.Size = new Size(108, 39);
            button2.TabIndex = 5;
            button2.Text = "放送設定";
            button2.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "平1", "平2", "平3", "平4", "平5", "平6", "平7", "平8", "平9", "平10", "平11", "平12", "平13", "平14", "平15", "平16", "平17", "平18", "平19", "平20", "平21", "平22", "平23", "平24", "平25", "平26", "平27", "平28", "平29", "平30", "平31", "平32", "平33", "平34", "平35", "平36", "平37", "平38", "平39", "平40", "平151", "平152", "平153", "平154", "平155", "平156", "平157", "平158", "平159", "平160", "平161", "平162", "平551", "平552", "平553", "平554", "平555", "平556", "平557", "平558", "平559", "平560", "平566", "変-平5", "変-平9", "変-平13", "変-平151", "普変-平1", "普変-平2", "普変-平7", "普変-平8", "準変-平3", "準変-平4", "準変-平5", "準変-平6", "準変-平11", "準変-平12", "地変-平1", "地変-平2", "地変-平4", "地変-平5", "地変-平7", "地変-平8", "地変-平10", "地変-平21", "地変-平22", "地変-平23", "地変-平24", "地変-平15", "地変-平26", "地変-平27", "特変-平551", "特変-平552", "教変-平151", "教変-平157", "教変-平551", "教変-平552", "臨-平848", "臨-平849" });
            comboBox2.Location = new Point(186, 151);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 9;
            comboBox2.Text = "行路を選択";
            // 
            // button3
            // 
            button3.Location = new Point(566, 12);
            button3.Name = "button3";
            button3.Size = new Size(108, 39);
            button3.TabIndex = 4;
            button3.Text = "自動放送切替";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(452, 12);
            button4.Name = "button4";
            button4.Size = new Size(108, 39);
            button4.TabIndex = 10;
            button4.Text = "ワンマン放送ボタン";
            button4.UseVisualStyleBackColor = true;
            // 
            // One
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 128);
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(comboBox2);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button1);
            Name = "One";
            Text = "ワンマン";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private ComboBox comboBox2;
        private Button button3;
        private Button button4;
    }
}