using System;
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
            /// 背景色(初期値)
            /// </summary>
            public static readonly Color BackColor_Def = Color.FromArgb(255, 255, 255);

            /// <summary>
            /// 線の色(初期値)
            /// </summary>
            public static readonly Color LineColor_Def = Color.FromArgb(0, 0, 0);

            /// <summary>
            /// 文字色(初期値)
            /// </summary>
            public static readonly Color FontColor_Def = Color.FromArgb(0, 0, 0);

            /// <summary>
            /// フォント(初期値)
            /// </summary>
            public static readonly Font Font_Def = new Font("HGSｺﾞｼｯｸE", 12);

            /// <summary>
            /// 描画領域のサイズ(初期値)
            /// </summary>
            public static readonly Size DisplayRectangle_Def = new Size(420, 620);

            /// <summary>
            /// 外枠のサイズ(初期値)
            /// </summary>
            public static readonly Size Size_Def = new Size(400, 600);

            /// <summary>
            /// 外枠の余白(初期値)
            /// </summary>
            public static readonly Size Margin_Def = new Size(10, 10);



            /// <summary>
            /// 背景色
            /// </summary>
            public Color BackColor { get; set; } = BackColor_Def;

            /// <summary>
            /// 線の色
            /// </summary>
            public Color LineColor { get; set; } = LineColor_Def;

            /// <summary>
            /// 文字色
            /// </summary>
            public Color FontColor { get; set; } = FontColor_Def;

            /// <summary>
            /// フォント
            /// </summary>
            public Font Font { get; set; } = Font_Def;

            /// <summary>
            /// 描画領域のサイズ
            /// </summary>
            public Size DisplayRectangle { get; set; } = DisplayRectangle_Def;

            /// <summary>
            /// 外枠のサイズ
            /// </summary>
            public Size Size { get; set; } = Size_Def;

            /// <summary>
            /// 外枠の余白
            /// </summary>
            public Size Margin { get; set; } = Margin_Def;

        }

        /// <summary>
        /// （左上）タイトル欄に関する設定の構造体
        /// </summary>
        public class Title
        {
            /// <summary>
            /// 枠のサイズ(初期値)
            /// </summary>
            public static readonly Size Size_Def = new Size(200, 125);



            /// <summary>
            /// 枠のサイズ
            /// </summary>
            public Size Size { get; set; } = Size_Def;

        }

        /// <summary>
        /// （右上）種別欄に関する設定の構造体
        /// </summary>
        public class TrainType
        {
            /// <summary>
            /// 背景色(初期値)
            /// </summary>
            public static readonly Color BackColor_Def = Color.FromArgb(255, 255, 255);

            /// <summary>
            /// 文字色(初期値)
            /// </summary>
            public static readonly Color FontColor_Def = Color.FromArgb(0, 0, 0);

            /// <summary>
            /// フォント(初期値)
            /// </summary>
            public static readonly Font Font_Def = new Font("HG丸ｺﾞｼｯｸM-PRO", 62);

            /// <summary>
            /// 枠のサイズ(初期値)
            /// </summary>
            public static readonly Size Size_Def = new Size(200, 125);



            /// <summary>
            /// 背景色
            /// </summary>
            public Color BackColor { get; set; } = BackColor_Def;

            /// <summary>
            /// 文字色
            /// </summary>
            public Color FontColor { get; set; } = FontColor_Def;

            /// <summary>
            /// フォント
            /// </summary>
            public Font Font { get; set; } = Font_Def;

            /// <summary>
            /// 枠のサイズ
            /// </summary>
            public Size Size { get; set; } = Size_Def;

        }

        /// <summary>
        /// タイムテーブル欄に関する設定の構造体
        /// </summary>
        public class Timetable
        {
            /// <summary>
            /// 停車駅の背景色(初期値)
            /// </summary>
            public static readonly Color BackColorStopStation_Def = Color.FromArgb(255, 255, 255);

            /// <summary>
            /// 停車駅の文字色(初期値)
            /// </summary>
            public static readonly Color FontColorStopStation_Def = Color.FromArgb(0, 0, 0);

            /// <summary>
            /// 停車駅のフォント(初期値)
            /// </summary>
            public static readonly Font FontStopStation_Def = new Font("EPSON 太丸ゴシック体Ｂ", 11);

            /// <summary>
            /// 通過駅の背景色(初期値)
            /// </summary>
            public static readonly Color BackColorTransitStation_Def = Color.FromArgb(255, 255, 255);

            /// <summary>
            /// 通過駅の文字色(初期値)
            /// </summary>
            public static readonly Color FontColorTransitStation_Def = Color.FromArgb(0, 0, 0);

            /// <summary>
            /// 通過駅のフォント(初期値)
            /// </summary>
            public static readonly Font FontTransitStation_Def = new Font("EPSON 太丸ゴシック体Ｂ", 11);

            /// <summary>
            /// 1行あたりの高さ(初期値)
            /// </summary>
            public static readonly float Height_Def = 20;

            /// <summary>
            /// （左から1番目）駅名欄の横幅(初期値)
            /// </summary>
            public static readonly float WidthStation_Def = 80;

            /// <summary>
            /// （左から2,3,4番目）時分秒欄のそれぞれの横幅(初期値)
            /// </summary>
            public static readonly float WidthTime_Def = 25;

            /// <summary>
            /// （左から5番目）番線等を書く欄の横幅(初期値)
            /// </summary>
            public static readonly float WidthSup1_Def = 80;

            /// <summary>
            /// （一番右）入替時間等を書く欄の横幅(初期値)
            /// </summary>
            public static readonly float WidthSup2_Def = 165;



            /// <summary>
            /// 停車駅の背景色
            /// </summary>
            public Color BackColorStopStation { get; set; } = BackColorStopStation_Def;

            /// <summary>
            /// 停車駅の文字色
            /// </summary>
            public Color FontColorStopStation { get; set; } = FontColorStopStation_Def;

            /// <summary>
            /// 停車駅のフォント
            /// </summary>
            public Font FontStopStation { get; set; } = FontStopStation_Def;

            /// <summary>
            /// 通過駅の背景色
            /// </summary>
            public Color BackColorTransitStation { get; set; } = BackColorTransitStation_Def;

            /// <summary>
            /// 通過駅の文字色
            /// </summary>
            public Color FontColorTransitStation { get; set; } = FontColorTransitStation_Def;

            /// <summary>
            /// 通過駅のフォント
            /// </summary>
            public Font FontTransitStation { get; set; } = FontTransitStation_Def;

            /// <summary>
            /// 1行あたりの高さ
            /// </summary>
            public float Height { get; set; } = Height_Def;

            /// <summary>
            /// （左から1番目）駅名欄の横幅
            /// </summary>
            public float WidthStation { get; set; } = WidthStation_Def;

            /// <summary>
            /// （左から2,3,4番目）時分秒欄のそれぞれの横幅
            /// </summary>
            public float WidthTime { get; set; } = WidthTime_Def;

            /// <summary>
            /// （左から5番目）番線等を書く欄の横幅
            /// </summary>
            public float WidthSup1 { get; set; } = WidthSup1_Def;

            /// <summary>
            /// （一番右）入替時間等を書く欄の横幅
            /// </summary>
            public float WidthSup2 { get; set; } = WidthSup2_Def;

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



        /// <summary>
        /// 描画領域を元に、位置とサイズを再計算する
        /// </summary>
        public void Resize(SizeF display_rectangle, float dpi) 
        {
            float mx = (display_rectangle.Width - 2 * Global.Margin_Def.Height)
                / (Global.DisplayRectangle_Def.Width - 2 * Global.Margin_Def.Height);
            float my = (display_rectangle.Height - 2 * Global.Margin_Def.Height)
                / (Global.DisplayRectangle_Def.Height - 2 * Global.Margin_Def.Height);
            float m = (mx < my) ? mx : my;

            float fm = m * 96 / dpi;
            if (fm < 0.2f) fm = 0.2f;
            if (fm > 2.0f) fm = 2.0f;

            Globals.Size = (Global.Size_Def * m).ToSize();
            Globals.Margin = ((display_rectangle - Globals.Size) / 2).ToSize();
            Globals.Font = new Font(Global.Font_Def.FontFamily, Global.Font_Def.Size * fm);
            Titles.Size = (Title.Size_Def * m).ToSize();
            TrainTypes.Size = (TrainType.Size_Def * m).ToSize();
            TrainTypes.Font = new Font(TrainType.Font_Def.FontFamily, TrainType.Font_Def.Size * fm);
            TimeTables.Height = Timetable.Height_Def * m;
            TimeTables.WidthStation = Timetable.WidthStation_Def * m;
            TimeTables.WidthTime = Timetable.WidthTime_Def * m;
            TimeTables.WidthSup1 = Timetable.WidthSup1_Def * m;
            TimeTables.WidthSup2 = Timetable.WidthSup2_Def * m;
            TimeTables.FontStopStation = new Font(Timetable.FontStopStation_Def.FontFamily, Timetable.FontStopStation_Def.Size * fm);
            TimeTables.FontTransitStation = new Font(Timetable.FontTransitStation_Def.FontFamily, Timetable.FontTransitStation_Def.Size * fm);
        }
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

