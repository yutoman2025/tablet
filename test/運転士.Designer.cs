namespace test
{
    partial class M
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
            pictureBox2 = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            comboBox3 = new ComboBox();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
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
            button1.TabIndex = 0;
            button1.Text = "最前面切替";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(0, 192, 192);
            pictureBox2.Location = new Point(12, 106);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(471, 333);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "1113", "1517", "1820", "2123" });
            comboBox1.Location = new Point(139, 77);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "ダイヤを選択";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "平1", "平2", "平3", "平4", "平5", "平6", "平7", "平8", "平9", "平10", "平11", "平12", "平13", "平14", "平151", "平152", "平153", "平154", "平155", "平156", "平157", "平566", "変-平5", "変-平9", "変-平13", "変-平151", "普変-平1", "普変-平2", "普変-平7", "普変-平8", "準変-平3", "準変-平4", "準変-平5", "準変-平6", "準変-平11", "準変-平12", "特変-平551", "特変-平552", "教変-平151", "教変-平157", "教変-平551", "教変-平552", "臨-平848", "臨-平849" });
            comboBox2.Location = new Point(12, 77);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 6;
            comboBox2.Text = "行路を選択";
            // 
            // button2
            // 
            button2.Location = new Point(266, 76);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "決定";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 192, 192);
            pictureBox1.Location = new Point(506, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(282, 401);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "回1005A", "回1409A", "1019A", "1021A", "1103A", "1118A", "1206A", "1212A", "1215A", "1320A", "1407A", "1419A", "1508A", "1513A", "1518A", "1603A", "1604A", "1612A", "1706A", "1709A", "1711A", "1810A", "1814A", "1817A", "1819A", "1908A", "1913A", "1918A", "2016A", "1787B", "1869B", "1882B", "1883B", "1977B", "4757B", "1182C", "1183C", "1184C", "1185C", "1198C", "1199C", "1282C", "1283C", "1284C", "1285C", "1298C", "1299C", "1582C", "1583C", "1584C", "1585C", "1598C", "1599C", "1682C", "1683C", "1684C", "1685C", "1698C", "1699C", "1791C", "1884C", "1885C", "1886C", "1887C", "1890C", "1898C", "1899C", "1984C", "1985C", "1986C", "1987C", "1990C", "1991C", "1997C", "1998C", "1999C", "2098C", "1041", "1049", "1050X", "1060", "1075", "1140", "1143", "1145", "1148", "1150", "1151", "1161", "1164", "1165", "1166", "1167", "1174", "1242", "1249", "1251", "1260", "1261", "1264", "1267", "1274", "1275", "1441", "1449", "1450", "1460", "1475", "1540", "1543", "1545", "1548", "1550", "1551", "1561", "1564", "1565", "1566", "1567", "1574", "1642", "1649", "1651", "1660", "1661", "1664", "1674", "1675", "1679", "1690", "1743", "1750", "1764", "1779", "1850", "1860", "1861", "1865", "1871", "1874", "1875", "1876", "1878", "1879", "1940", "1951", "1960", "1961", "1964", "1965", "1970", "1974", "1975", "1978", "1979", "回1666", "試9091", "試9093", "試9190", "試9191", "試9192", "試9193", "試9290", "試9292" });
            comboBox3.Location = new Point(506, 11);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 9;
            comboBox3.Text = "スターフを選択";
            // 
            // button3
            // 
            button3.Location = new Point(256, 10);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 10;
            button3.Text = "メモ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(713, 12);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 11;
            button4.Text = "決定";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // M
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(comboBox3);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox2);
            Controls.Add(button1);
            MaximizeBox = false;
            Name = "M";
            Text = "運転士";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox2;
        private OpenFileDialog openFileDialog1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button2;
        private PictureBox pictureBox1;
        private ComboBox comboBox3;
        private Button button3;
        private Button button4;
    }
}