using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace tc_staff_draw
{
    public class StaffDraw
    {

        /// <summary>
        /// スタフのデザインに関する設定
        /// </summary>
        public StaffDesign Design { get; set; }

        /// <summary>
        /// スタフの情報
        /// </summary>
        public StaffData Data { get; set; }


        /// <summary>
        /// グラフィックスバッファーにスタフを描画する
        /// </summary>
        /// <param name="buffer">描画先のグラフィックスバッファー</param>
        public void DrawAll(BufferedGraphics buffer)
        {
            if(Design == null) return;

            float dpi = (buffer.Graphics.DpiX < buffer.Graphics.DpiY)? buffer.Graphics.DpiY : buffer.Graphics.DpiX;
            Design.Resize(buffer.Graphics.VisibleClipBounds.Size, dpi);

            DrawBackGround(buffer);
            DrawTitle(buffer);
            DrawTrainType(buffer);
            DrawTimeTable(buffer);
        }

        /// <summary>
        /// 背景色と枠の描画
        /// </summary>
        private void DrawBackGround(BufferedGraphics buffer)
        {
            buffer.Graphics.Clear(Design.Globals.BackColor);
            buffer.Graphics.DrawRectangle(
                new Pen(Design.Globals.LineColor,2),
                new Rectangle(
                    Design.Globals.Margin.Width,
                    Design.Globals.Margin.Height,
                    Design.Globals.Size.Width,
                    Design.Globals.Size.Height
                    )
                );
        }

        /// <summary>
        /// 左上の列車情報の描画
        /// </summary>
        private void DrawTitle(BufferedGraphics buffer)
        {
            // 枠線
            Rectangle rect = new Rectangle(
                    Design.Globals.Margin.Width,
                    Design.Globals.Margin.Height,
                    Design.Titles.Size.Width,
                    Design.Titles.Size.Height);

            buffer.Graphics.DrawRectangle(new Pen(Design.Globals.LineColor,2), rect);

            // 一番小さいフォントサイズに合わせる
            float min_font_size = CalcFitFontSize(Data.Titles[0], Design.Globals.Font, rect);
            for (int i = 1; i < Data.Titles.Length; i++)
            {
                float font_size = CalcFitFontSize(Data.Titles[i], Design.Globals.Font, rect);
                if(font_size < min_font_size)
                {
                    min_font_size = font_size;
                }
            }
            Font font = new Font(Design.Globals.Font.FontFamily, (int)min_font_size);

            // 文字列
            float height = (float)Design.Titles.Size.Height / Data.Titles.Length;
            for (int i = 0; i < Data.Titles.Length; i++)
            {
                rect = new Rectangle(
                    Design.Globals.Margin.Width,
                    Design.Globals.Margin.Height + (int)(i * height),
                    Design.Titles.Size.Width,
                    (int)height);

                DrawString(buffer, Data.Titles[i], font, new SolidBrush(Design.Globals.FontColor), rect, TextFormatFlags.VerticalCenter);
                rect.Y += rect.Height;
            }
        }

        /// <summary>
        /// 右上の列車種別の描画
        /// </summary>
        private void DrawTrainType(BufferedGraphics buffer)
        {
            Rectangle rect = new Rectangle(
                    Design.Globals.Margin.Width + Design.Titles.Size.Width,
                    Design.Globals.Margin.Height,
                    Design.TrainTypes.Size.Width,
                    Design.TrainTypes.Size.Height);

            buffer.Graphics.FillRectangle(new SolidBrush(Design.TrainTypes.BackColor), rect);
            buffer.Graphics.DrawRectangle(new Pen(Design.Globals.LineColor,2), rect);
            DrawString(buffer, Data.TrainType, Design.TrainTypes.Font,
                new SolidBrush(Design.TrainTypes.FontColor), rect, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        /// <summary>
        /// タイムテーブルの描画
        /// </summary>
        private void DrawTimeTable(BufferedGraphics buffer)
        {
            RectangleF rect;
            SolidBrush brush_fill, brush_text;
            Font font;
            Pen pen_line = new Pen(Design.Globals.LineColor);

            float pos_x = Design.Globals.Margin.Width;
            float pos_y = Design.Globals.Margin.Height + Design.Titles.Size.Height;
            float height;

            if(Data.TimeTables == null)
            {
                return;
            }

            for (int i = 0; i < Data.TimeTables.Count; i++)
            {
                pos_x = Design.Globals.Margin.Width;
                height = CalcTimeTableHeight(Data.TimeTables[i], Design.TimeTables);

                // 駅名（左から1番目）
                rect = new RectangleF(pos_x, pos_y, Design.TimeTables.WidthStation, height);
                if (Data.TimeTables[i].Stop)
                {
                    brush_fill = new SolidBrush(Design.TimeTables.BackColorStopStation);
                    brush_text = new SolidBrush(Design.TimeTables.FontColorStopStation);
                    font = Design.TimeTables.FontStopStation;
                }
                else
                {
                    brush_fill = new SolidBrush(Design.TimeTables.BackColorTransitStation);
                    brush_text = new SolidBrush(Design.TimeTables.FontColorTransitStation);
                    font = Design.TimeTables.FontTransitStation;
                }
                buffer.Graphics.FillRectangle(brush_fill, rect);
                buffer.Graphics.DrawRectangle(pen_line, rect);

                // 到着・出発の2行表示のときは高さ1行で中央に配置
                RectangleF rect_text = new RectangleF(
                    pos_x,
                    pos_y + (height - Design.TimeTables.Height) / 2,
                    Design.TimeTables.WidthStation,
                    Design.TimeTables.Height);
                DrawString(buffer, Data.TimeTables[i].Station, font, brush_text, rect_text, TextFormatFlags.VerticalCenter);
                pos_x += rect.Width;

                font = Design.Globals.Font;
                brush_text = new SolidBrush(Design.Globals.FontColor);

                // 時間（左から2,3,4番目）
                for (int j = 0; j < 3; j++)
                {
                    rect = new RectangleF(pos_x, pos_y, Design.TimeTables.WidthTime, height);
                    buffer.Graphics.DrawRectangle(pen_line, rect);

                    float ofs_y = 0;
                    for (int k = 0; k < 2; k++)
                    {
                        string[] hms;

                        if (k == 0)
                        {
                            hms = Data.TimeTables[i].ArrivalTime;
                        }
                        else
                        {
                            hms = Data.TimeTables[i].DepatureTime;
                        }

                        if (hms[0] != "" || hms[1] != "" || hms[2] != "")
                        {
                            rect = new RectangleF(pos_x, pos_y + ofs_y, Design.TimeTables.WidthTime, Design.TimeTables.Height);
                            DrawString(buffer, hms[j], font, brush_text, InnerRectangleF(rect, -1), TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                            ofs_y += Design.TimeTables.Height;
                        }
                    }
                    pos_x += rect.Width;
                }

                // 着発番線等（左から5番目）
                rect = new RectangleF(pos_x, pos_y, Design.TimeTables.WidthSup1, height);
                buffer.Graphics.DrawRectangle(pen_line, rect);

                rect = new RectangleF(pos_x, pos_y, Design.TimeTables.WidthSup1, Design.TimeTables.Height);
                DrawString(buffer, Data.TimeTables[i].Supplement1, font, brush_text, rect, TextFormatFlags.VerticalCenter);
                pos_x += rect.Width;

                // 入替時刻等（左から6番目）
                rect = new RectangleF(pos_x, pos_y, Design.TimeTables.WidthSup2, Design.TimeTables.Height);
                DrawString(buffer, Data.TimeTables[i].Supplement2, font, brush_text, rect, TextFormatFlags.VerticalCenter);
                rect = new RectangleF(pos_x, pos_y + Design.TimeTables.Height, Design.TimeTables.WidthSup2, Design.TimeTables.Height);
                DrawString(buffer, Data.TimeTables[i].Supplement2_2, font, brush_text, rect, TextFormatFlags.VerticalCenter);
                pos_x += rect.Width;

                pos_y += height;
            }

        }

        /// <summary>
        /// 枠の内側の領域を返す
        /// </summary>
        private RectangleF InnerRectangleF(RectangleF rect, float space)
        {
            return new RectangleF(rect.X + space + 1, rect.Y + space + 1, rect.Width - 2 * space - 1, rect.Height - 2 * space - 1);
        }

        /// <summary>
        /// タイムテーブルの各要素の高さを決定する
        /// </summary>
        private float CalcTimeTableHeight(StaffData.TimeTable table, StaffDesign.Timetable rule)
        {
            float height = rule.Height;

            if (table.Station == "")
            {
                height /= 2;
            }
            else if ((table.ArrivalTime[0] != "" || table.ArrivalTime[1] != "" || table.ArrivalTime[2] != "")
                     && (table.DepatureTime[0] != "" || table.DepatureTime[1] != "" || table.DepatureTime[2] != ""))
            {
                height *= 2;
            }

            return height;
        }

        /// <summary>
        /// 領域に収まるようにフォントサイズを縮小して文字を描画する
        /// </summary>
        private void DrawString(BufferedGraphics bg, string s, Font font, Brush brush, RectangleF rect, TextFormatFlags flags = TextFormatFlags.Default)
        {

            font = new Font(font.FontFamily, CalcFitFontSize(s, font, rect));

            TextRenderer.DrawText(bg.Graphics, s, font, Rectangle.Round(rect), Color.White, flags);

        }

        /// <summary>
        /// 領域に収まるフォントサイズを返す
        /// </summary>
        private float CalcFitFontSize(string s, Font font, RectangleF rect)
        {

            // 横幅縮小
            for (int i = 0; i < 2; i++)
            {
                // (1回の乗算では修正しきれない時があるので2回まわす)
                int len = TextRenderer.MeasureText(s, font).Width;
                if (rect.Width < len)
                {
                    int size = (int)(font.Size * rect.Width / len);
                    if(size <= 0) size = 1;
                    font = new Font(font.FontFamily, size);
                }
            }

            // 縦幅縮小
            for (int i = 0; i < 2; i++)
            {
                // (1回の乗算では修正しきれない時があるので2回まわす)
                if (rect.Height < font.Height)
                {
                    int size = (int)(font.Size * rect.Height / font.Height);
                    if (size <= 0) size = 1;
                    font = new Font(font.FontFamily, size);
                }
            }
            
            return font.Size;
        }

    }
}