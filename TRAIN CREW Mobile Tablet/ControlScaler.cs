using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using tablet;



public class ControlScaler
{
    private Size originalClientSize;
    private readonly Dictionary<Control, Rectangle> originalBounds = new();
    private readonly Dictionary<Control, float> originalFontSizes = new();

    // キャプチャは InitializeComponent 後の一度だけ呼ぶ
    public void CaptureInitialState(Form form)
    {
        originalClientSize = form.ClientSize;
        originalBounds.Clear();
        originalFontSizes.Clear();
        RegisterControls(form);
    }

    private void RegisterControls(Control parent)
    {
        foreach (Control control in parent.Controls)
        {
            originalBounds[control] = control.Bounds;
            if (control.Font != null) originalFontSizes[control] = control.Font.Size;
        }
    }

    // リサイズ時に呼ぶ。縦横比を保つために最小倍率を採用
    public void ScaleToCurrentSize(Form form, ControlScalerProvider provider)
    {
        
        if (originalClientSize.Width == 0 || originalClientSize.Height == 0) return;

        form.SuspendLayout();
        foreach (var originalBound in originalBounds)
        {
            var control = originalBound.Key;
            PointF refLocation = provider.GetRefLocation(control);

            // コントロールの基準位置からの倍率
            float scaleX = (float)(form.ClientSize.Width - refLocation.X)
                / (originalClientSize.Width - refLocation.X);
            float scaleY = (float)(form.ClientSize.Height - refLocation.Y)
                / (originalClientSize.Height - refLocation.Y);

            // Anchorを基準とした四角形に変換
            RectangleF rect = TransformRectangle(originalBound.Value, provider.GetAnchor(control));

            // 配置調整
            if(provider.GetMovable(control))
            {
                rect.X = refLocation.X + (rect.X - refLocation.X) * scaleX;
                rect.Y = refLocation.Y + (rect.Y - refLocation.Y) * scaleY;
            }

            ControlExpantion expantion;

            // サイズ調整
            expantion = provider.GetResizableX(control);
            if (expantion == ControlExpantion.AllowBoth)
            {
                rect.Width *= scaleX;
            }
            else if(expantion == ControlExpantion.AllowEnlargementOnly)
            {
                if(scaleX > 1.0f) rect.Width *= scaleX;
            }
            else if(expantion == ControlExpantion.AllowShrinkingOnly)
            {
                if (scaleX < 1.0f) rect.Width *= scaleX;
            }

            expantion = provider.GetResizableY(control);
            if (expantion == ControlExpantion.AllowBoth)
            {
                rect.Height *= scaleY;
            }
            else if (expantion == ControlExpantion.AllowEnlargementOnly)
            {
                if (scaleY > 1.0f) rect.Height *= scaleY;
            }
            else if (expantion == ControlExpantion.AllowShrinkingOnly)
            {
                if (scaleY < 1.0f) rect.Height *= scaleY;
            }

            // フォント調整
            expantion = provider.GetFontResizable(control);
            if(originalFontSizes.TryGetValue(control, out float baseSize))
            {
                float scaleFont = Math.Min(scaleX, scaleY);
                bool isRescaleFont = false;
                if (expantion == ControlExpantion.AllowBoth)
                {
                    isRescaleFont = true;
                }
                else if (expantion == ControlExpantion.AllowEnlargementOnly)
                {
                    if (scaleFont > 1.0f) isRescaleFont = true;
                }
                else if (expantion == ControlExpantion.AllowShrinkingOnly)
                {
                    if (scaleFont < 1.0f) isRescaleFont = true;
                }
                
                if(isRescaleFont)
                {
                    control.Font = new Font(
                        control.Font.FontFamily,
                        Math.Max(1f, baseSize * scaleFont),
                        control.Font.Style);
                }
            }
            
            // 通常の四角形に戻して設定
            control.Bounds = InverseRectangle(Rectangle.Round(rect), provider.GetAnchor(control));

        }

        form.ResumeLayout();
        
    }

    /// <summary>
    /// 通常のRectangleからAnchorを基準としたRectangleに変換します。
    /// </summary>
    public static Rectangle TransformRectangle(Rectangle rect, ControlAnchor anchor)
    {
        switch(anchor) 
        {
            case ControlAnchor.TopLeft:
                return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
            case ControlAnchor.TopRight:
                return new Rectangle(rect.X + rect.Width, rect.Y, rect.Width, rect.Height);
            case ControlAnchor.BottomLeft:
                return new Rectangle(rect.X, rect.Y + rect.Height, rect.Width, rect.Height);
            case ControlAnchor.BottomRight:
                return new Rectangle(rect.X + rect.Width, rect.Y + rect.Height, rect.Width, rect.Height);
            default:
                return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
        }
    }

    /// <summary>
    /// Anchorを基準としたRectangleから通常のRectangleに変換します。
    /// </summary>
    public static Rectangle InverseRectangle(Rectangle rect, ControlAnchor anchor)
    {
        switch (anchor)
        {
            case ControlAnchor.TopLeft:
                return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
            case ControlAnchor.TopRight:
                return new Rectangle(rect.X - rect.Width, rect.Y, rect.Width, rect.Height);
            case ControlAnchor.BottomLeft:
                return new Rectangle(rect.X, rect.Y - rect.Height, rect.Width, rect.Height);
            case ControlAnchor.BottomRight:
                return new Rectangle(rect.X - rect.Width, rect.Y - rect.Height, rect.Width, rect.Height);
            default:
                return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
        }
    }
}

/// <summary>
/// ControlScalerにおけるコントロールの基準位置を示します。
/// </summary>
public enum ControlAnchor
{
    /// <summary>
    /// コントロールの左上
    /// </summary>
    TopLeft,
    /// <summary>
    /// コントロールの右上
    /// </summary>
    TopRight,
    /// <summary>
    /// コントロールの左下
    /// </summary>
    BottomLeft,
    /// <summary>
    /// コントロールのを右下
    /// </summary>
    BottomRight
}

/// <summary>
/// ControlScalerにおけるサイズ変更の挙動を示します。
/// </summary>
public enum ControlExpantion
{
    /// <summary>
    /// 拡大と縮小を禁止
    /// </summary>
    NotAllow,
    /// <summary>
    /// 拡大と縮小の両方許可
    /// </summary>
    AllowBoth,
    /// <summary>
    /// 拡大のみ許可
    /// </summary>
    AllowEnlargementOnly,
    /// <summary>
    /// 縮小のみ許可
    /// </summary>
    AllowShrinkingOnly
}