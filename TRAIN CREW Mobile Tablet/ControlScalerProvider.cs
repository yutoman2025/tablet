using System.ComponentModel;

namespace tablet
{
    /// <summary>
    /// ControlScalerで使用するプロパティーをデザイナに提供します。
    /// </summary>
    [ProvideProperty("Anchor", typeof(Control))]
    [ProvideProperty("FontResizable", typeof(Control))]
    [ProvideProperty("Movable", typeof(Control))]
    [ProvideProperty("RefLocation", typeof(Control))]
    [ProvideProperty("ResizableX", typeof(Control))]
    [ProvideProperty("ResizableY", typeof(Control))]
    public class ControlScalerProvider : Component, IExtenderProvider
    {
        private Dictionary<Control, ControlAnchor> anchor = new();
        private Dictionary<Control, ControlExpantion> fontResizable = new();
        private Dictionary<Control, bool> movable = new();
        private Dictionary<Control, Point> refLocation = new();
        private Dictionary<Control, ControlExpantion> resizableX = new();
        private Dictionary<Control, ControlExpantion> resizableY = new();

        public bool CanExtend(object extendee)
        {
            return extendee is Control;
        }

        [Category("ControlScaler")]
        [Description("ControlScalerにおけるコントロールの基準位置を決定します。")]
        public ControlAnchor GetAnchor(Control control)
        {
            return anchor.TryGetValue(control, out ControlAnchor v) ? v : ControlAnchor.TopLeft;
        }
        public void SetAnchor(Control control, ControlAnchor value)
        {
            anchor[control] = value;
        }

        [Category("ControlScaler")]
        [Description("ControlScalerによるフォントのサイズ変更を行うかを決定します。")]
        public ControlExpantion GetFontResizable(Control control)
        {
            return fontResizable.TryGetValue(control, out ControlExpantion v) ? v : ControlExpantion.NotAllow;
        }
        public void SetFontResizable(Control control, ControlExpantion value)
        {
            fontResizable[control] = value;
        }

        [Category("ControlScaler")]
        [Description("ControlScalerによるコントロールの移動を行うかを決定します。")]
        public bool GetMovable(Control control)
        {
            return movable.TryGetValue(control, out bool v) ? v : false;
        }
        public void SetMovable(Control control, bool value)
        {
            movable[control] = value;
        }

        [Category("ControlScaler")]
        [Description("ControlScalerによるコントロールの横幅変更を行うかを決定します。")]
        public ControlExpantion GetResizableX(Control control)
        {
            return resizableX.TryGetValue(control, out ControlExpantion v) ? v : ControlExpantion.NotAllow;
        }
        public void SetResizableX(Control control, ControlExpantion value)
        {
            resizableX[control] = value;
        }

        [Category("ControlScaler")]
        [Description("ControlScalerによるコントロールの縦幅変更を行うかを決定します。")]
        public ControlExpantion GetResizableY(Control control)
        {
            return resizableY.TryGetValue(control, out ControlExpantion v) ? v : ControlExpantion.NotAllow;
        }
        public void SetResizableY(Control control, ControlExpantion value)
        {
            resizableY[control] = value;
        }

        [Category("ControlScaler")]
        [Description("ControlScalerによる変形を行う際のフォーム上の基準位置を決定します。")]
        public Point GetRefLocation(Control control)
        {
            return refLocation.TryGetValue(control, out Point v) ? v : new Point(0,0);
        }
        public void SetRefLocation(Control control, Point value)
        {
            refLocation[control] = value;
        }

    }

}
