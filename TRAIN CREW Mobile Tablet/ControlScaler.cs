using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class ControlScaler
{
    private Size originalClientSize;
    private readonly Dictionary<Control, Rectangle> originalBounds = new();
    private readonly Dictionary<Control, float> originalFontSizes = new();
    private readonly Dictionary<ListBox, int> originalItemHeights = new();

    // キャプチャは InitializeComponent 後の一度だけ呼ぶ
    public void CaptureInitialState(Form form)
    {
        originalClientSize = form.ClientSize;
        originalBounds.Clear();
        originalFontSizes.Clear();
        originalItemHeights.Clear();
        RegisterControls(form);
    }

    private void RegisterControls(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            originalBounds[c] = c.Bounds;
            if (c.Font != null) originalFontSizes[c] = c.Font.Size;
            if (c is ListBox lb) originalItemHeights[lb] = lb.ItemHeight;
            if (c.HasChildren) RegisterControls(c);
        }
    }

    // リサイズ時に呼ぶ。縦横比を保つために最小倍率を採用
    public void ScaleToCurrentSize(Form form)
    {
        if (originalClientSize.Width == 0 || originalClientSize.Height == 0) return;

        float scaleX = (float)form.ClientSize.Width / originalClientSize.Width;
        float scaleY = (float)form.ClientSize.Height / originalClientSize.Height;
        float scale = Math.Min(scaleX, scaleY);

        form.SuspendLayout();
        foreach (var kv in originalBounds)
        {
            var c = kv.Key;
            var r = kv.Value;
            c.Bounds = new Rectangle(
                (int)Math.Round(r.X * scale),
                (int)Math.Round(r.Y * scale),
                Math.Max(1, (int)Math.Round(r.Width * scale)),
                Math.Max(1, (int)Math.Round(r.Height * scale))
            );

            if (originalFontSizes.TryGetValue(c, out float baseSize))
            {
                // フォントサイズを比例変更
                c.Font = new Font(c.Font.FontFamily, Math.Max(1f, baseSize * scale), c.Font.Style);
            }
        }

        foreach (var kv in originalItemHeights)
        {
            var lb = kv.Key;
            lb.ItemHeight = Math.Max(1, (int)Math.Round(kv.Value * scale));
        }
        form.ResumeLayout();
    }
}