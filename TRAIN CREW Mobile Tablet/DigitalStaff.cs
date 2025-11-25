using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace tc_staff_draw
{
    public partial class DigitalStaff : Form
    {

        private StaffSetting staff_setting;
        private StaffDesign staff_design;

        /// <summary>
        /// 描画バッファ
        /// </summary>
        private BufferedGraphics buffer;

        /// <summary>
        /// 画面サイズが変わったことを検知するための古い情報
        /// </summary>
        private Rectangle displayRectangle_old;

        /// <summary>
        /// 描画クラス
        /// </summary>
        private StaffDraw draw;

        /// <summary>
        /// スタフを表示する列車番号
        /// </summary>
        public string TrainNumber;

        /// <summary>
        /// スタフデータ
        /// </summary>
        public StaffData StaffData;

        public DigitalStaff()
        {
            InitializeComponent();

            draw = new StaffDraw();
            staff_setting = new StaffSetting("StaffSetting.xml");
        }

        /// <summary>
        /// 指定した列車番号のスタフを読み込む
        /// </summary>
        public void LoadStaff(string train_number)
        {
            if (staff_setting.init == false) return;

            TrainNumber = train_number;
            string[] csvin = new string[] { "tablet.Resources.11-13-1.csv","tablet.Resources.11-13-2.csv","tablet.Resources.15-17-1.csv","tablet.Resources.15-17-2.csv","tablet.Resources.18-24-1.csv","tablet.Resources.18-24-2.csv" };
            foreach (string csv in csvin)
            {
                // CSV読み込み
                string[][] csv_data = StaffDataConv.LoadResource(csv);
                // CSVから指定した列車番号のスタフを抽出
                if (StaffDataConv.ConvStaffData(csv_data, ref StaffData, TrainNumber) == 0)
                {
                    break;
                }
            }

            // 列車種別に対応する色を設定
            StaffTheme.LocalColor color;
            switch (StaffData.TrainType)
            {
                case "普通": color = staff_setting.Theme.TypeNColors; break;
                case "特急": color = staff_setting.Theme.TypeAColors; break;
                case "急行": color = staff_setting.Theme.TypeBColors; break;
                case "準急": color = staff_setting.Theme.TypeCColors; break;
                case "快急": color = staff_setting.Theme.TypeKColors; break;
                default: color = staff_setting.Theme.TypeZColors; break;
            }
            staff_design = new StaffDesign();
            staff_design = staff_setting.Theme.GlobalColors.Phase(staff_design);
            staff_design = color.Phase(staff_design);

            // 描画クラスに反映
            draw.Data = StaffData;
            draw.Design = staff_design;

            // 再描画
            DrawAll();

        }

        /// <summary>
        /// スタフ画面を再描画する
        /// </summary>
        public void DrawAll()
        {
            if (draw == null) return;

            if (StaffData.IsNull())
            {
                Text = "デジタルスタフ (" + TrainNumber + " - リソースなし)";
                return;
            }
            else
            {
                Text = "デジタルスタフ (" + TrainNumber + ")";
            }

            // ウィンドウサイズが変わったら描画バッファを再生成する
            if (DisplayRectangle != displayRectangle_old)
            {
                displayRectangle_old = DisplayRectangle;
                if (buffer != null)
                {
                    buffer.Dispose();
                }
                buffer = BufferedGraphicsManager.Current.Allocate(CreateGraphics(), DisplayRectangle);
            }

            draw.DrawAll(buffer);
            buffer.Render();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawAll();
        }

        private void DigitalStaff_Resize(object sender, EventArgs e)
        {
            DrawAll();
        }
    }
}
