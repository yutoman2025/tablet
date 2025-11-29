using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using tablet; // DigitalClock の namespace

namespace test
{
    public class AnalogClock : Form
    {
        private System.Windows.Forms.Timer? timer;
        private DigitalClock? sourceClock;
        private bool ownsSourceClock = false; // 内部生成した DigitalClock を所有しているか

        // DigitalClock と同じロジックを再現するためのフィールド
        int H = 0;
        int HH = 0;
        int flgLocal = 0;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HourOffset { get; set; } = 0;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MinuteOffset { get; set; } = 0;

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

            // 初期化を一度実行して HH 等を初期化（DigitalClock がしているのと同じ）
            Timer_Tick(this, EventArgs.Empty);
        }

        // DigitalClock を受け取って参照する（必要なら運転士から渡す）
        public AnalogClock(DigitalClock source) : this(0, 0)
        {
            AttachSourceClock(source);
        }

        /// <summary>
        /// DigitalClock を紐付ける。渡されたインスタンスが null/破棄済みの場合は
        /// 非表示の内部 DigitalClock を作成して購読する。
        /// </summary>
        public void AttachSourceClock(DigitalClock? source)
        {
            // 既存購読解除
            if (sourceClock != null)
            {
                try { sourceClock.TimeUpdated -= Source_TimeUpdated; } catch { }
                // 内部生成したものを所有しているなら不要時に破棄する
                if (ownsSourceClock)
                {
                    try
                    {
                        // 内部のデジタルクロックは画面表示していないため ShutdownClock で確実に閉じる
                        sourceClock.AllowRealClose = true;
                        sourceClock.Close();
                        sourceClock.Dispose();
                    }
                    catch { }
                    ownsSourceClock = false;
                }
                sourceClock = null;
            }

            if (source == null || source.IsDisposed)
            {
                // 内部で非表示の DigitalClock を作成してタイマー等を稼働させる
                var hidden = new DigitalClock();
                // ハンドルを強制生成して初期化（タイマー等を確実に開始）
                var _ = hidden.Handle;
                // 表示は行わない（Showしない）
                sourceClock = hidden;
                ownsSourceClock = true;
            }
            else
            {
                sourceClock = source;
                ownsSourceClock = false;
            }

            // DigitalClock の public プロパティがあれば同期して参照（hour/minute offset）
            try
            {
                HourOffset = sourceClock != null ? sourceClock.HourOffset : HourOffset;
                MinuteOffset = sourceClock != null ? sourceClock.MinuteOffset : MinuteOffset;
            }
            catch
            {
                // 無視
            }

            // DigitalClock の更新イベントを購読して即時同期する
            try
            {
                sourceClock!.TimeUpdated += Source_TimeUpdated;
            }
            catch
            {
                // 無視
            }

            // もし source が既に補正済み時刻を持っていれば即座に反映
            try
            {
                var cur = sourceClock!.CurrentAdjustedTime;
                if (cur != DateTime.MinValue)
                {
                    lastDisplayedTime = cur;
                }
            }
            catch
            {
                // 無視
            }

            // 初期描画
            Invalidate();
        }

        // DigitalClock と同じアルゴリズムで adjustedTime を計算して表示する
        private void Timer_Tick(object? sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime adjustedTime = now;

            // DigitalClock と同様のロジックを使う（static DigitalClock.time / DigitalClock.f, M.time2 / M.f を参照）
            H = now.Hour;

            // DigitalClock.time と DigitalClock.f は static なので参照可能
            if (HH != DigitalClock.time && DigitalClock.f == 0)
            {
                HH++;
            }
            else if (DigitalClock.f == 1)
            {
                // M.time2 は 運転士.cs の static フィールド
                HH = DigitalClock.time + (H - M.time2);
            }
            else
            {
                M.f = 1;
                M.time2 = H;
            }

            HH = Math.Max(0, Math.Min(23, HH));

            if (flgLocal == 0)
            {
                adjustedTime = new DateTime(now.Year, now.Month, now.Day, HH, now.Minute, now.Second);
            }
            else
            {
                adjustedTime = now;
            }

            // hour/minute offset は DigitalClock インスタンスがあればそちらの値を優先して使う
            int effectiveHourOffset = sourceClock != null ? sourceClock.HourOffset : HourOffset;
            int effectiveMinuteOffset = sourceClock != null ? sourceClock.MinuteOffset : MinuteOffset;

            adjustedTime = adjustedTime.AddHours(effectiveHourOffset).AddMinutes(effectiveMinuteOffset);

            // 重要: DigitalClock 側の補正済み時刻が利用可能ならそれを優先して表示する
            if (sourceClock != null)
            {
                try
                {
                    var src = sourceClock.CurrentAdjustedTime;
                    if (src != DateTime.MinValue)
                    {
                        lastDisplayedTime = src;
                        Invalidate();
                        return;
                    }
                }
                catch
                {
                    // 取得できなければ上で計算した adjustedTime を使う
                }
            }

            // 描画用に現在の adjustedTime を使う（OnPaint 内で計算しないように lastTime を保持）
            lastDisplayedTime = adjustedTime;

            Invalidate();
        }

        private DateTime lastDisplayedTime = DateTime.MinValue;

        // DigitalClock の更新イベントハンドラ
        private void Source_TimeUpdated(DateTime dt)
        {
            // DigitalClock は System.Windows.Forms.Timer を使っているので通常 UI スレッドだが、
            // 念のため InvokeRequired を使って UI スレッドに戻す
            if (InvokeRequired)
            {
                BeginInvoke(new Action<DateTime>(Source_TimeUpdated), dt);
                return;
            }

            lastDisplayedTime = dt;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = ClientSize.Width;
            int h = ClientSize.Height;
            int size = Math.Min(w, h);
            var center = new PointF(w / 2f, h / 2f + size * 0.05f); // わずかに下寄せ
            float radius = size * 0.42f;

            // 背景（ウィンドウ全体を淡い色に）
            using (var bg = new SolidBrush(Color.FromArgb(240, 238, 230)))
                g.FillRectangle(bg, ClientRectangle);

            // 金属の外縁 (PathGradientBrush で金属っぽく)
            var rimRect = new RectangleF(center.X - radius - size * 0.06f, center.Y - radius - size * 0.06f, (radius + size * 0.06f) * 2, (radius + size * 0.06f) * 2);
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(rimRect);
                using (var pgb = new PathGradientBrush(path))
                {
                    pgb.CenterColor = Color.FromArgb(220, 220, 220);
                    pgb.SurroundColors = new Color[] { Color.FromArgb(120, 120, 120) };
                    pgb.CenterPoint = new PointF(center.X - size * 0.03f, center.Y - size * 0.03f);
                    g.FillEllipse(pgb, rimRect);
                }
            }

            // 光沢ハイライト（上半分）
            using (var highlight = new LinearGradientBrush(
                new PointF(center.X - radius, center.Y - radius),
                new PointF(center.X + radius, center.Y - radius),
                Color.FromArgb(180, Color.White),
                Color.FromArgb(0, Color.White)))
            {
                var clip = g.Clip;
                g.SetClip(new RectangleF(center.X - radius, center.Y - radius, radius * 2, radius));
                g.FillEllipse(highlight, new RectangleF(center.X - radius, center.Y - radius, radius * 2, radius));
                g.Clip = clip;
            }

            // 文字盤（クリーム色）
            using (var faceBrush = new SolidBrush(Color.FromArgb(250, 244, 229)))
            using (var facePen = new Pen(Color.FromArgb(180, 140, 80), Math.Max(1, size / 200f)))
            {
                g.FillEllipse(faceBrush, center.X - radius, center.Y - radius, radius * 2, radius * 2);
                g.DrawEllipse(facePen, center.X - radius, center.Y - radius, radius * 2, radius * 2);
            }

            // 上部のリング（懐中時計のループ）
            float ringRadius = radius * 0.22f;
            var ringCenter = new PointF(center.X, center.Y - radius - ringRadius * 0.5f);
            using (var pen = new Pen(Color.FromArgb(120, 120, 120), Math.Max(2, size / 120f)))
            {
                g.DrawEllipse(pen, ringCenter.X - ringRadius, ringCenter.Y - ringRadius, ringRadius * 2, ringRadius * 2);
                g.DrawEllipse(pen, ringCenter.X - ringRadius * 0.6f, ringCenter.Y - ringRadius * 0.6f, ringRadius * 1.2f, ringRadius * 1.2f);
            }

            // 分/秒目盛り（60本）
            for (int i = 0; i < 60; i++)
            {
                double angle = i * Math.PI * 2.0 / 60.0 - Math.PI / 2.0;
                float cos = (float)Math.Cos(angle);
                float sin = (float)Math.Sin(angle);

                bool isFive = (i % 5 == 0);
                float outer = radius * 0.98f;
                float inner = isFive ? radius * 0.82f : radius * 0.90f;
                float thickness = isFive ? Math.Max(2, size / 120f) : Math.Max(1, size / 300f);

                using (var markPen = new Pen(Color.FromArgb(70, 50, 30), thickness)) // 茶色寄りの目盛り
                {
                    g.DrawLine(markPen,
                        center.X + cos * inner, center.Y + sin * inner,
                        center.X + cos * outer, center.Y + sin * outer);
                }
            }

            // 12時間数字（Times New Roman）— 目盛り側に寄せる
            float numberRadiusFactor = 0.77f;
            using (var numFont = new Font("Times New Roman", Math.Max(10, size / 12f), FontStyle.Bold))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                for (int n = 1; n <= 12; n++)
                {
                    double angle = n * Math.PI * 2.0 / 12.0 - Math.PI / 2.0;
                    float x = center.X + (float)(Math.Cos(angle) * radius * numberRadiusFactor);
                    float y = center.Y + (float)(Math.Sin(angle) * radius * numberRadiusFactor);
                    float scale = (n % 3 == 0) ? 1.05f : 1.0f;
                    using (var fnt = new Font(numFont.FontFamily, numFont.Size * scale, numFont.Style))
                    {
                        g.DrawString(n.ToString(), fnt, Brushes.Black, x, y, sf);
                    }
                }
            }

            // ここで 12 時の文字の下にリソースの TATEHAMA ロゴを描画する
            {
                // 12時の位置を計算（数値描画と同じ numberRadiusFactor を使う）
                double angle12 = -Math.PI / 2.0;
                var num12Pos = new PointF(
                    center.X + (float)(Math.Cos(angle12) * radius * numberRadiusFactor),
                    center.Y + (float)(Math.Sin(angle12) * radius * numberRadiusFactor)
                );

                // ロゴの表示サイズ（調整可）
                float logoBase = radius * 0.5f; // ロゴの基準幅
                var logoPos = new PointF(num12Pos.X, num12Pos.Y + logoBase * 0.9f); // 下方向へオフセット

                DrawTatehamaLogoFromResources(g, logoPos, logoBase);
            }

            // 使用する時刻（Timer_Tick が lastDisplayedTime に格納）
            DateTime nowDisplayed = lastDisplayedTime == DateTime.MinValue ? DateTime.Now : lastDisplayedTime;

            // ここで時刻の針を計算 — lastDisplayedTime は既に補正済み
            float second = nowDisplayed.Second + nowDisplayed.Millisecond / 1000f;
            float minute = nowDisplayed.Minute + second / 60f;
            float hour = (nowDisplayed.Hour % 12) + minute / 60f;

            // 針の角度から不必要な -90° を削除（パスは上向きが基準）
            DrawDecorativeHourHand(g, center, hour / 12f * 360f, radius * 0.52f, Math.Max(4, size / 60f), Color.FromArgb(40, 30, 20));
            DrawDecorativeMinuteHand(g, center, minute / 60f * 360f, radius * 0.75f, Math.Max(3, size / 100f), Color.FromArgb(30, 20, 15));
            DrawSecondHand(g, center, second / 60f * 360f, radius * 0.85f, Math.Max(1, size / 200f), Color.Red);

            // 中央の装飾
            using (var centralBrush = new SolidBrush(Color.FromArgb(50, 30, 15)))
            {
                float dot = Math.Max(6, size / 40f);
                g.FillEllipse(Brushes.Gold, center.X - dot, center.Y - dot, dot * 2, dot * 2);
                g.FillEllipse(centralBrush, center.X - dot * 0.6f, center.Y - dot * 0.6f, dot * 1.2f, dot * 1.2f);
            }
        }

        private void DrawDecorativeHourHand(Graphics g, PointF center, double angleDeg, float length, float thickness, Color color)
        {
            using (var path = new GraphicsPath())
            {
                float w = thickness * 2.2f;
                path.AddRectangle(new RectangleF(-w / 2, -length * 0.15f, w, length * 0.65f));
                var tri = new PointF[] {
                    new PointF(-w, -length * 0.15f + length * 0.65f),
                    new PointF(w, -length * 0.15f + length * 0.65f),
                    new PointF(0, -length)
                };
                path.AddPolygon(tri);
                path.AddEllipse(-thickness * 0.6f, -thickness * 0.6f, thickness * 1.2f, thickness * 1.2f);

                // Graphics の変換を使って回転中心を正しく扱う
                var state = g.Save();
                g.TranslateTransform(center.X, center.Y);
                g.RotateTransform((float)angleDeg);
                using (var brush = new SolidBrush(color))
                using (var pen = new Pen(Color.FromArgb(30, 20, 10), 1))
                {
                    g.FillPath(brush, path);
                    g.DrawPath(pen, path);
                }
                g.Restore(state);
            }
        }

        private void DrawDecorativeMinuteHand(Graphics g, PointF center, double angleDeg, float length, float thickness, Color color)
        {
            using (var path = new GraphicsPath())
            {
                float w = thickness * 1.6f;
                path.AddRectangle(new RectangleF(-w / 2, -length * 0.05f, w, length * 0.85f));
                var tri = new PointF[] {
                    new PointF(-w * 0.9f, -length * 0.05f + length * 0.85f),
                    new PointF(w * 0.9f, -length * 0.05f + length * 0.85f),
                    new PointF(0, -length)
                };
                path.AddPolygon(tri);

                // Graphics の変換を使って回転中心を正しく扱う
                var state = g.Save();
                g.TranslateTransform(center.X, center.Y);
                g.RotateTransform((float)angleDeg);
                using (var brush = new SolidBrush(color))
                using (var pen = new Pen(Color.FromArgb(30, 20, 10), 1))
                {
                    g.FillPath(brush, path);
                    g.DrawPath(pen, path);
                }
                g.Restore(state);
            }
        }

        private void DrawSecondHand(Graphics g, PointF center, double angleDeg, float length, float thickness, Color color)
        {
            using (var pen = new Pen(color, thickness))
            {
                var m = g.Transform;
                g.TranslateTransform(center.X, center.Y);
                g.RotateTransform((float)angleDeg);
                using (var backPen = new Pen(Color.FromArgb(120, 120, 120), Math.Max(1, thickness / 2)))
                {
                    g.DrawLine(backPen, 0, thickness * 2, 0, length * -0.12f);
                }
                g.DrawLine(pen, 0, 0, 0, -length);
                g.FillEllipse(Brushes.Red, -thickness * 2, -length - thickness * 2, thickness * 4, thickness * 4);
                g.Transform = m;
            }
        }

        /// <summary>
        /// リソースにある TATEHAMA イメージを描画する。
        /// pos は描画中心、baseSize はロゴ幅のベース（ピクセル相当） — 必要なら調整してください。
        /// </summary>
        private void DrawTatehamaLogoFromResources(Graphics g, PointF pos, float baseSize)
        {
            // Resources の画像を取得（Properties.Resources.TATEHAMA が存在する前提）
            Image? logo = null;
            try
            {
                logo = tablet.Properties.Resources.TATEHAMA;
            }
            catch
            {
                // リソースが見つからない場合は何もしない
                return;
            }

            if (logo == null) return;

            // アスペクト比を保って表示サイズを決定
            float aspect = logo.Width > 0 && logo.Height > 0 ? (float)logo.Width / logo.Height : 1f;
            float destW = baseSize;               // 基準幅
            float destH = destW / aspect;         // 幅を基準に高さを算出
            // 必要に応じて縦横を入れ替えることで高さを基準にすることも可能

            var dest = new RectangleF(pos.X - destW / 2f, pos.Y - destH / 2f, destW, destH);

            // 高品質に描画（元の補助状態を復元）
            var prevMode = g.InterpolationMode;
            var prevSmo = g.SmoothingMode;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // リソースのイメージは共有インスタンスの可能性があるので Dispose はしない
            g.DrawImage(logo, dest);

            g.InterpolationMode = prevMode;
            g.SmoothingMode = prevSmo;
        }

        /// <summary>
        /// 既存の三枚羽描画は残しておく（将来の参照用）。今回は使用されない。
        /// </summary>
        private void DrawThreeBladeLogo(Graphics g, PointF pos, float size)
        {
            // ローカル座標で下方向を -Y としてブレードを作り、回転して三枚並べる。
            // ブレード形状（スムーズな多角形）
            PointF[] blade = new PointF[]
            {
                new PointF(0, -size * 0.98f),                  // tip
                new PointF(size * 0.65f, -size * 0.15f),
                new PointF(size * 0.30f, size * 0.70f),
                new PointF(-size * 0.30f, size * 0.70f),
                new PointF(-size * 0.65f, -size * 0.15f)
            };

            // 各ブレードの角度と色（イメージに合わせて配置）
            (float angle, Color color)[] blades = new (float, Color)[]
            {
                (-90f, Color.FromArgb(0, 220, 60)),   // 上寄り（緑）
                (30f, Color.FromArgb(20, 140, 240)),  // 右（青）
                (150f, Color.FromArgb(245, 190, 30))  // 左（黄）
            };

            foreach (var (angle, color) in blades)
            {
                using (var path = new GraphicsPath())
                {
                    path.AddPolygon(blade);

                    // transform: rotate then translate
                    var m = new Matrix();
                    m.Rotate(angle);
                    path.Transform(m);
                    path.Transform(new Matrix(1,0,0,1,pos.X,pos.Y)); // translate

                    // グラデーションで少し立体感を出す
                    using (var brush = new PathGradientBrush(path))
                    {
                        brush.CenterColor = ControlPaint.Light(color);
                        brush.SurroundColors = new Color[] { ControlPaint.Dark(color) };
                        // 中心点を少しずらして光の当たりを表現
                        brush.CenterPoint = new PointF(pos.X - size * 0.15f, pos.Y - size * 0.25f);
                        g.FillPath(brush, path);
                    }

                    using (var pen = new Pen(Color.FromArgb(40, 40, 40), Math.Max(1, size / 50f)))
                    {
                        g.DrawPath(pen, path);
                    }
                }
            }

            // 中心の小さな継ぎ目（接合点）
            using (var centerBrush = new SolidBrush(Color.FromArgb(30, 30, 30)))
            {
                float r = Math.Max(1.5f, size * 0.07f);
                g.FillEllipse(centerBrush, pos.X - r * 0.5f, pos.Y - r * 0.5f, r, r);
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
            Text = "懐中時計";
            TopMost = true;
            ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (sourceClock != null)
                {
                    try { sourceClock.TimeUpdated -= Source_TimeUpdated; } catch { }
                    // 内部で生成した DigitalClock を所有していれば終了・破棄する
                    if (ownsSourceClock)
                    {
                        try
                        {
                            sourceClock.AllowRealClose = true;
                            sourceClock.Close();
                            sourceClock.Dispose();
                        }
                        catch { }
                        ownsSourceClock = false;
                    }
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