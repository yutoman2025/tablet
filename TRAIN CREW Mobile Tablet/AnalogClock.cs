using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using tablet; // DigitalClock が定義されている namespace をインポート

namespace test
{
    public class AnalogClock : Form
    {
        private System.Windows.Forms.Timer timer;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HourOffset { get; set; } = 0;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MinuteOffset { get; set; } = 0;

        // 追加：DigitalClock 参照と直近の補正時刻
        private DigitalClock? sourceClock;
        private DateTime lastSourceTime = DateTime.MinValue;

        public AnalogClock() : this(0, 0) { }

        public AnalogClock(int hourOffset, int minuteOffset)
        {
            HourOffset = hourOffset;
            MinuteOffset = minuteOffset;
            InitializeComponent();

            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 200; // 更新感を上げる（200ms ごと）
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        // DigitalClock を受け取って購読するコンストラクタ
        public AnalogClock(DigitalClock source) : this(0, 0)
        {
            AttachSourceClock(source);
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            // sourceClock があればそれを使って描画更新、無ければシステム時刻を使う
            if (sourceClock != null)
            {
                // DigitalClock が CurrentAdjustedTime を正しく初期化している前提
                lastSourceTime = sourceClock.CurrentAdjustedTime;
            }
            else
            {
                lastSourceTime = DateTime.Now.AddHours(HourOffset).AddMinutes(MinuteOffset);
            }
            Invalidate();
        }

        // source を Attach／Detach するヘルパー
        public void AttachSourceClock(DigitalClock source)
        {
            if (sourceClock != null)
            {
                sourceClock.TimeUpdated -= OnSourceTimeUpdated;
            }
            sourceClock = source ?? throw new ArgumentNullException(nameof(source));
            sourceClock.TimeUpdated += OnSourceTimeUpdated;
            // 初期読み取り
            lastSourceTime = sourceClock.CurrentAdjustedTime;
            Invalidate();
        }

        private void OnSourceTimeUpdated(DateTime dt)
        {
            // UI スレッドで更新
            if (IsHandleCreated)
            {
                BeginInvoke((Action)(() =>
                {
                    lastSourceTime = dt;
                    Invalidate();
                }));
            }
            else
            {
                lastSourceTime = dt;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int w = ClientSize.Width;
            int h = ClientSize.Height;
            int size = Math.Min(w, h);
            var center = new PointF(w / 2f, h / 2f);
            float radius = size * 0.45f;

            // 背景
            using (var brush = new SolidBrush(Color.White))
                g.FillEllipse(brush, center.X - radius, center.Y - radius, radius * 2, radius * 2);

            // 外周
            using (var pen = new Pen(Color.Black, Math.Max(1, size / 200f)))
                g.DrawEllipse(pen, center.X - radius, center.Y - radius, radius * 2, radius * 2);

            // 分／秒目盛り（60本）
            for (int i = 0; i < 60; i++)
            {
                double angle = i * Math.PI * 2.0 / 60.0 - Math.PI / 2.0;
                float cos = (float)Math.Cos(angle);
                float sin = (float)Math.Sin(angle);

                bool isFive = (i % 5 == 0);
                float markOuter = radius;
                float markInner = radius - (isFive ? radius * 0.12f : radius * 0.06f);
                float thickness = isFive ? Math.Max(2, size / 120f) : Math.Max(1, size / 300f);

                using (var markPen = new Pen(Color.Black, thickness))
                {
                    g.DrawLine(markPen,
                        center.X + cos * markInner, center.Y + sin * markInner,
                        center.X + cos * markOuter, center.Y + sin * markOuter);
                }
            }

            // 12時間数字描画（見やすく）
            using (var font = new Font(FontFamily.GenericSansSerif, Math.Max(10, size / 15f), FontStyle.Bold))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                for (int hnum = 1; hnum <= 12; hnum++)
                {
                    double angle = hnum * Math.PI * 2.0 / 12.0 - Math.PI / 2.0;
                    float x = center.X + (float)(Math.Cos(angle) * radius * 0.68);
                    float y = center.Y + (float)(Math.Sin(angle) * radius * 0.68);
                    g.DrawString(hnum.ToString(), font, Brushes.Black, x, y, sf);
                }
            }

            // 使用する時刻（sourceClock 経由で更新される lastSourceTime、未設定時は現在時刻）
            DateTime now = lastSourceTime == DateTime.MinValue ? DateTime.Now.AddHours(HourOffset).AddMinutes(MinuteOffset) : lastSourceTime;

            // 各針の角度（秒・分・時）
            float second = now.Second + now.Millisecond / 1000f;
            float minute = now.Minute + second / 60f;
            float hour = (now.Hour % 12) + minute / 60f;

            // 針の描画（太さや色を調整）
            DrawHand(g, center, hour / 12f * 360f - 90f, radius * 0.5f, new Pen(Color.Black, Math.Max(3, size / 80f)));
            DrawHand(g, center, minute / 60f * 360f - 90f, radius * 0.75f, new Pen(Color.Black, Math.Max(2, size / 140f)));
            DrawHand(g, center, second / 60f * 360f - 90f, radius * 0.85f, new Pen(Color.Red, Math.Max(1, size / 300f)));

            // 中央のつまみ
            float centerDot = Math.Max(4, size / 50f);
            g.FillEllipse(Brushes.Black, center.X - centerDot / 2, center.Y - centerDot / 2, centerDot, centerDot);

            // デジタル表示（秒まで一目で読めるように文字列表示）
            string timeStr = now.ToString("HH:mm:ss");
            using (var tf = new Font(FontFamily.GenericSansSerif, Math.Max(10, size / 12f), FontStyle.Regular))
            using (var brush = new SolidBrush(Color.Black))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near })
            {
                var rect = new RectangleF(center.X - radius, center.Y + radius * 0.1f, radius * 2, radius * 0.5f);
                g.DrawString(timeStr, tf, brush, rect, sf);
            }
        }

        private void DrawHand(Graphics g, PointF center, double angleDeg, float length, Pen pen)
        {
            try
            {
                double rad = angleDeg * Math.PI / 180.0;
                float x = center.X + (float)(Math.Cos(rad) * length);
                float y = center.Y + (float)(Math.Sin(rad) * length);
                g.DrawLine(pen, center.X, center.Y, x, y);
            }
            finally
            {
                pen.Dispose();
            }
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // AnalogClock
            // 
            ClientSize = new Size(300, 300);
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "AnalogClock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "アナログ時計";
            TopMost = true;
            ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // 購読解除
                if (sourceClock != null)
                {
                    sourceClock.TimeUpdated -= OnSourceTimeUpdated;
                    sourceClock = null;
                }
                if (timer != null)
                {
                    timer.Tick -= Timer_Tick;
                    timer.Stop();
                    timer.Dispose();
                    timer = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}