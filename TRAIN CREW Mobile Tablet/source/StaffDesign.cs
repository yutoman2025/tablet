using System.Drawing;
using System.Xml.Serialization;

namespace tc_staff_draw
{
    /// <summary>
    /// スタフのデザイン（色、フォント、サイズ）に関する設定の構造体
    /// </summary>
    public class StaffDesign
    {
        /// <summary>
        /// スタフ全体に適用される設定の構造体
        /// </summary>
        public class Global
        {
            /// <summary>
            /// 背景色
            /// </summary>
            public Color BackColor { get; set; } = Color.FromArgb(255, 255, 255);

            /// <summary>
            /// 線の色
            /// </summary>
            public Color LineColor { get; set; } = Color.FromArgb(0 ,0 ,0);

            /// <summary>
            /// 文字色
            /// </summary>
            public Color FontColor { get; set; } = Color.FromArgb(0, 0, 0);

            /// <summary>
            /// フォント
            /// </summary>
            public Font Font { get; set; } = new Font("MS Gothic", 11);

            /// <summary>
            /// 外枠のサイズ
            /// </summary>
            public Size Size { get; set; } = new Size(400, 600);

            /// <summary>
            /// 外枠の余白
            /// </summary>
            public Size Margin { get; set; } = new Size(10, 10);

        }

        /// <summary>
        /// （左上）タイトル欄に関する設定の構造体
        /// </summary>
        public class Title
        {
            /// <summary>
            /// 枠のサイズ
            /// </summary>
            public Size Size { get; set; } = new Size(200, 125);
        }

        /// <summary>
        /// （右上）種別欄に関する設定の構造体
        /// </summary>
        public class TrainType
        {
            /// <summary>
            /// 背景色
            /// </summary>
            public Color BackColor { get; set; } = Color.FromArgb(255, 255, 255);

            /// <summary>
            /// 文字色
            /// </summary>
            public Color FontColor { get; set; } = Color.FromArgb(0, 0, 0);

            /// <summary>
            /// フォント
            /// </summary>
            public Font Font { get; set; } = new Font("HG丸ｺﾞｼｯｸM-PRO", 62);

            /// <summary>
            /// 枠のサイズ
            /// </summary>
            public Size Size { get; set; } = new Size(200, 125);
        }

        /// <summary>
        /// タイムテーブル欄に関する設定の構造体
        /// </summary>
        public class Timetable
        {
            /// <summary>
            /// 停車駅の背景色
            /// </summary>
            public Color BackColorStopStation { get; set; } = Color.FromArgb(255, 255, 255);

            /// <summary>
            /// 停車駅の文字色
            /// </summary>
            public Color FontColorStopStation { get; set; } = Color.FromArgb(0, 0, 0);

            /// <summary>
            /// 停車駅のフォント
            /// </summary>
            public Font FontStopStation { get; set; } = new Font("EPSON 太丸ゴシック体Ｂ", 11);

            /// <summary>
            /// 通過駅の背景色
            /// </summary>
            public Color BackColorTransitStation { get; set; } = Color.FromArgb(255, 255, 255);

            /// <summary>
            /// 通過駅の文字色
            /// </summary>
            public Color FontColorTransitStation { get; set; } = Color.FromArgb(0, 0, 0);

            /// <summary>
            /// 通過駅のフォント
            /// </summary>
            public Font FontTransitStation { get; set; } = new Font("EPSON 太丸ゴシック体Ｂ", 11);

            /// <summary>
            /// 1行あたりの高さ
            /// </summary>
            public int Height { get; set; } = 20;

            /// <summary>
            /// （左から1番目）駅名欄の横幅
            /// </summary>
            public int WidthStation { get; set; } = 80;

            /// <summary>
            /// （左から2,3,4番目）時分秒欄のそれぞれの横幅
            /// </summary>
            public int WidthTime { get; set; } = 25;

            /// <summary>
            /// （左から5番目）番線等を書く欄の横幅
            /// </summary>
            public int WidthSup1 { get; set; } = 80;

            /// <summary>
            /// （一番右）入替時間等を書く欄の横幅
            /// </summary>
            public int WidthSup2 { get; set; } = 200;
        }

        /// <summary>
        /// スタフ全体に適用される設定
        /// </summary>
        public Global Globals { get; set; } = new Global();

        /// <summary>
        /// （左上）タイトル欄に関する設定
        /// </summary>
        public Title Titles { get; set; } = new Title();

        /// <summary>
        /// （右上）種別欄に関する設定の構造体
        /// </summary>
        public TrainType TrainTypes { get; set; } = new TrainType();

        /// <summary>
        /// タイムテーブル欄に関する設定の構造体
        /// </summary>
        public Timetable TimeTables { get; set; } = new Timetable();


    }

    public class StaffTheme
    {
        public GlobalColor GlobalColors = new GlobalColor();
        public LocalColor TypeNColors = new LocalColor();
        public LocalColor TypeAColors = new LocalColor();
        public LocalColor TypeBColors = new LocalColor();
        public LocalColor TypeCColors = new LocalColor();
        public LocalColor TypeKColors = new LocalColor();
        public LocalColor TypeZColors = new LocalColor();

        public class GlobalColor
        {
            [XmlElement("BackColor")]
            public ColorRGB BackColor = new ColorRGB(255, 255, 255);
            [XmlElement("LineColor")]
            public ColorRGB LineColor = new ColorRGB(0, 0, 0);
            [XmlElement("FontColor")]
            public ColorRGB FontColor = new ColorRGB(0, 0, 0);

            public StaffDesign Phase(StaffDesign staffDesign)
            {
                staffDesign.Globals.BackColor = BackColor.ToColor();
                staffDesign.Globals.LineColor = LineColor.ToColor();
                staffDesign.Globals.FontColor = FontColor.ToColor();
                return staffDesign;
            }
        }

        public class LocalColor
        {
            [XmlElement("BackColorTrainType_____")]
            public ColorRGB BackColorTrainType = new ColorRGB(255, 255, 255);
            [XmlElement("FontColorTrainType_____")]
            public ColorRGB FontColorTrainType = new ColorRGB(0, 0, 0);
            [XmlElement("BackColorStopStation___")]
            public ColorRGB BackColorStopStation = new ColorRGB(255, 255, 255);
            [XmlElement("FontColorStopStation___")]
            public ColorRGB FontColorStopStation = new ColorRGB(0, 0, 0);
            [XmlElement("BackColorTransitStation")]
            public ColorRGB BackColorTransitStation = new ColorRGB(255, 255, 255);
            [XmlElement("FontColorTransitStation")]
            public ColorRGB FontColorTransitStation = new ColorRGB(0, 0, 0);

            public StaffDesign Phase(StaffDesign staffDesign)
            {
                staffDesign.TrainTypes.BackColor = BackColorTrainType.ToColor();
                staffDesign.TrainTypes.FontColor = FontColorTrainType.ToColor();
                staffDesign.TimeTables.BackColorStopStation = BackColorStopStation.ToColor();
                staffDesign.TimeTables.FontColorStopStation = FontColorStopStation.ToColor();
                staffDesign.TimeTables.BackColorTransitStation = BackColorTransitStation.ToColor();
                staffDesign.TimeTables.FontColorTransitStation = FontColorTransitStation.ToColor();
                return staffDesign;
            }
        }
    }

    public struct ColorRGB
    {
        [XmlAttribute]
        public byte R;
        [XmlAttribute]
        public byte G;
        [XmlAttribute]
        public byte B;

        public ColorRGB(byte r, byte g, byte b)
        {
            R = r; G = g; B = b;
        }

        public Color ToColor()
        {
            return Color.FromArgb(R, G, B);
        }

        public override string ToString()
        {
            return R + ", " + G + ", " + B;
        }
    }
}

