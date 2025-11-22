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
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
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
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "0709", "1113", "1517", "1820", "2123", "1824", "ダイヤ不定" });
            comboBox1.Location = new Point(139, 77);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "ダイヤを選択";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "平1", "平2", "平3", "平4", "平5", "平6", "平7", "平8", "平9", "平10", "平11", "平12", "平13", "平14", "平15", "平16", "平17", "平18", "平19", "平20", "平21", "平22", "平23", "平24", "平25", "平26", "平27", "平28", "平29", "平30", "平31", "平32", "平33", "平35", "平36", "平37", "平38", "平39", "平40", "平151", "平152", "平153", "平154", "平155", "平156", "平157", "平158", "平159", "平160", "平161", "平162", "平551", "平552", "平553", "平554", "平555", "平556", "平557", "平558", "平559", "平560", "平566", "変-平5", "変-平9", "変-平13", "変-平151", "普変-平1", "普変-平2", "普変-平7", "普変-平8", "準変-平3", "準変-平4", "準変-平5", "準変-平6", "準変-平11", "準変-平12", "地変-平1", "地変-平2", "地変-平4", "地変-平5", "地変-平7", "地変-平8", "地変-平10", "地変-平21", "地変-平22", "地変-平23", "地変-平24", "地変-平15", "地変-平26", "地変-平27", "特変-平551", "特変-平552", "教変-平151", "教変-平157", "教変-平551", "教変-平552", "臨-平848", "臨-平849" });
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
            pictureBox1.Click += pictureBox1_Click;
            // 
            // comboBox3
            // 
            comboBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox3.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "回802A", "回803A", "回914A", "603A", "607A", "624A", "706A", "713A", "715A", "718A", "721A", "809A", "812A", "820A", "902A", "796K", "3643K", "3758K", "681B", "797B", "799B", "3545B", "3744B", "3842B", "684CX", "691C", "782C", "783C", "784C", "785C", "786C", "787C", "790C", "791C", "880C", "881C", "882C", "883C", "884C", "885C", "890C", "898C", "899C", "983C", "671", "672", "676", "693", "752", "760", "761", "762", "763", "766", "770", "773", "777", "786", "844", "848", "849", "850", "860", "861", "863", "864", "865", "866", "867", "872", "873", "876", "879", "3841", "回771", "回782", "回862", "回1005A", "回1409A", "1019A", "1021A", "1103A", "1118A", "1206A", "1212A", "1215A", "1320A", "1182C", "1183C", "1184C", "1185C", "1198C", "1199C", "1282C", "1283C", "1284C", "1285C", "1298C", "1299C", "1041", "1049", "1050X", "1060", "1075", "1140", "1143", "1145", "1148", "1150", "1151", "1161", "1164", "1165", "1166", "1167", "1174", "1242", "1244", "1249", "1251", "1260", "1261", "1264", "1267", "1274", "1275", "試9091", "試9093", "試9190", "試9191", "試9192", "試9193", "試9290", "試9292", "1407A", "1419A", "1508A", "1513A", "1518A", "1603A", "1604A", "1612A", "1706A", "1582C", "1583C", "1584C", "1585C", "1598C", "1599C", "1682C", "1683C", "1684C", "1685C", "1698C", "1699C", "回1666", "1441", "1449", "1450", "1460", "1475", "1540", "1543", "1545", "1548", "1550", "1551", "1561", "1564", "1565", "1566", "1567", "1574", "1642", "1649", "1651", "1660", "1661", "1664", "1674", "1675", "1679", "1690", "1709A", "1711A", "1810A", "1814A", "1817A", "1819A", "1908A", "1913A", "1918A", "2016A", "1787B", "1869B", "1882B", "1883B", "1977B", "4757B", "1791C", "1884C", "1885C", "1886C", "1887C", "1890C", "1898C", "1899C", "1984C", "1985C", "1986C", "1987C", "1990C", "1991C", "1997C", "1998C", "1999C", "2098C", "1743", "1750", "1764", "1779", "1850", "1860", "1861", "1865", "1871", "1874", "1875", "1876", "1878", "1879", "1940", "1951", "1960", "1961", "1964", "1965", "1970", "1974", "1975", "1978", "1979", "回2208A", "回2218A", "2015A", "2021A", "2106A", "2109A", "2119A", "2120A", "2214A", "2223A", "2071B", "2183B", "2190B", "5140B", "2087C", "2076C", "2091C", "2165C", "2184C", "2185C", "2186C", "2187C", "2196C", "2196CX", "2197C", "2284C", "2285C", "2286C", "回2170", "回2287", "回2297", "2041", "2050", "2060", "2075", "2153", "2161", "2174", "2177", "2178", "2179", "2198", "2251", "2252", "2260", "2261", "2276", "2279", "2298", "2299" });
            comboBox3.Location = new Point(506, 11);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 9;
            comboBox3.Text = "スターフを選択";
            // 
            // button3
            // 
            button3.Location = new Point(139, 10);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 10;
            button3.Text = "メモ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(633, 12);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 11;
            button4.Text = "決定";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(713, 12);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 12;
            button5.Text = "リセット";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Yu Gothic UI", 8F);
            button6.Location = new Point(266, 11);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 13;
            button6.Text = "DigitalClock";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Font = new Font("Yu Gothic UI", 8F);
            button7.Location = new Point(347, 12);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 14;
            button7.Text = "AnalogClock";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Font = new Font("Yu Gothic UI", 8F);
            button8.Location = new Point(425, 12);
            button8.Name = "button8";
            button8.Size = new Size(75, 23);
            button8.TabIndex = 15;
            button8.Text = "デジタルスタフ";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // M
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(128, 255, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
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
            FormClosing += M_FormClosing;
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
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
    }
}