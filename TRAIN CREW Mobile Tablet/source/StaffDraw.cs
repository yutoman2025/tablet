using System.Drawing;
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

            Design.Resize(buffer.Graphics.VisibleClipBounds.Size);

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
            Rectangle rect = new Rectangle(
                    Design.Globals.Margin.Width,
                    Design.Globals.Margin.Height,
                    Design.Titles.Size.Width,
                    Design.Titles.Size.Height);

            buffer.Graphics.DrawRectangle(new Pen(Design.Globals.LineColor,2), rect);

            rect = new Rectangle(
                    Design.Globals.Margin.Width,
                    Design.Globals.Margin.Height,
                    Design.Titles.Size.Width,
                    (int)(Design.Globals.Font.Height * 1.5));

            for (int i = 0; i < Data.Titles.Length; i++)
            {
                DrawString(buffer, Data.Titles[i], Design.Globals.Font, new SolidBrush(Design.Globals.FontColor), rect);
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

            buffer.Graphics.DrawRectangle(new Pen(Design.Globals.LineColor,2), rect);

            buffer.Graphics.FillRectangle(new SolidBrush(Design.TrainTypes.BackColor), InnerRectangle(rect,2));

            DrawString(buffer, Data.TrainType, Design.TrainTypes.Font, new SolidBrush(Design.TrainTypes.FontColor), InnerRectangle(rect,2));
        }

        /// <summary>
        /// タイムテーブルの描画
        /// </summary>
        private void DrawTimeTable(BufferedGraphics buffer)
        {
            Rectangle rect;
            SolidBrush brush_fill, brush_text;
            Font font;
            Pen pen_line = new Pen(Design.Globals.LineColor);

            int pos_x = Design.Globals.Margin.Width;
            int pos_y = Design.Globals.Margin.Height + Design.Titles.Size.Height;
            int height;

            if(Data.TimeTables == null)
            {
                return;
            }

            for (int i = 0; i < Data.TimeTables.Count; i++)
            {
                pos_x = Design.Globals.Margin.Width;
                height = CalcTimeTableHeight(Data.TimeTables[i], Design.TimeTables);

                // 駅名（左から1番目）
                rect = new Rectangle(pos_x, pos_y, Design.TimeTables.WidthStation, height);
                buffer.Graphics.DrawRectangle(pen_line, rect);
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
                buffer.Graphics.FillRectangle(brush_fill, InnerRectangle(rect,1));
                DrawString(buffer, Data.TimeTables[i].Station, font, brush_text, InnerRectangle(rect,1));
                pos_x += rect.Width;

                font = Design.Globals.Font;
                brush_text = new SolidBrush(Design.Globals.FontColor);

                // 時間（左から2,3,4番目）
                for (int j = 0; j < 3; j++)
                {
                    rect = new Rectangle(pos_x, pos_y, Design.TimeTables.WidthTime, height);
                    buffer.Graphics.DrawRectangle(pen_line, rect);

                    int ofs_y = 0;
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
                            rect = new Rectangle(pos_x, pos_y + ofs_y, Design.TimeTables.WidthTime, Design.TimeTables.Height);
                            DrawString(buffer, hms[j], font, brush_text, InnerRectangle(rect,1));
                            ofs_y += Design.TimeTables.Height;
                        }
                    }
                    pos_x += rect.Width;
                }

                // 着発番線等（左から5番目）
                rect = new Rectangle(pos_x, pos_y, Design.TimeTables.WidthSup1, height);
                buffer.Graphics.DrawRectangle(pen_line, rect);

                rect = new Rectangle(pos_x, pos_y, Design.TimeTables.WidthSup1, Design.TimeTables.Height);
                DrawString(buffer, Data.TimeTables[i].Supplement1, font, brush_text, InnerRectangle(rect,1));
                pos_x += rect.Width;

                // 入替時刻等（左から6番目）
                rect = new Rectangle(pos_x, pos_y, Design.TimeTables.WidthSup2, Design.TimeTables.Height);
                DrawString(buffer, Data.TimeTables[i].Supplement2, font, brush_text, InnerRectangle(rect,1));
                rect = new Rectangle(pos_x, pos_y + Design.TimeTables.Height, Design.TimeTables.WidthSup2, Design.TimeTables.Height);
                DrawString(buffer, Data.TimeTables[i].Supplement2_2, font, brush_text, InnerRectangle(rect, 1));
                pos_x += rect.Width;

                pos_y += height;
            }

        }

        /// <summary>
        /// 枠の内側の領域を返す
        /// </summary>
        private Rectangle InnerRectangle(Rectangle rect, int space)
        {
            return new Rectangle(rect.X + 1, rect.Y + 1, rect.Width  - space, rect.Height - space);
        }

        /// <summary>
        /// タイムテーブルの各要素の高さを決定する
        /// </summary>
        private int CalcTimeTableHeight(StaffData.TimeTable table, StaffDesign.Timetable rule)
        {
            int height = rule.Height;

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

        private void DrawString(BufferedGraphics bg, string s, Font font, Brush brush, Rectangle rect)
        {
            int y = rect.Y + (rect.Height - font.Height) / 2;
            int x = rect.X;
            int w = rect.Width;
            int h = rect.Height;
            
            int len = TextRenderer.MeasureText(s, font).Width;
            if (w < len)
            {
               font = new Font(font.FontFamily, font.Size * w / len) ;
            }

            bg.Graphics.DrawString(s, font, brush, new Rectangle(x,y,w,h));
        }
    }
}