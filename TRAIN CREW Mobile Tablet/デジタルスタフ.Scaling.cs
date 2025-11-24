using System;
using System.Drawing;
using System.Windows.Forms;

namespace test
{
    public partial class デジタルスタフ : Form
    {
        private readonly ControlScaler _scaler = new ControlScaler();
        private bool _scalerCaptured = false;
        private Size _originalClientSize;
        private bool _internalResizeInProgress = false;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!_scalerCaptured)
            {
                // InitializeComponent() 後の初回 Load で初期状態をキャプチャ
                _scaler.CaptureInitialState(this);
                _originalClientSize = this.ClientSize;
                _scalerCaptured = true;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (!_scalerCaptured || _originalClientSize.Width == 0 || _originalClientSize.Height == 0)
                return;

            // 再帰防止フラグ
            if (_internalResizeInProgress)
                return;

            // 現在のスケールを計算（縦横比を維持するため最小倍率を選ぶ）
            float scaleX = (float)this.ClientSize.Width / _originalClientSize.Width;
            float scaleY = (float)this.ClientSize.Height / _originalClientSize.Height;
            float scale = Math.Min(scaleX, scaleY);

            // フォーム自体のサイズをアスペクト比を保って調整（余白を残す挙動）
            int targetWidth = Math.Max(1, (int)Math.Round(_originalClientSize.Width * scale));
            int targetHeight = Math.Max(1, (int)Math.Round(_originalClientSize.Height * scale));

            // ClientSize が期待値と大きく異なる時だけ修正して再スケール
            if (this.ClientSize.Width != targetWidth || this.ClientSize.Height != targetHeight)
            {
                try
                {
                    _internalResizeInProgress = true;
                    this.ClientSize = new Size(targetWidth, targetHeight);
                }
                finally
                {
                    _internalResizeInProgress = false;
                }
            }

            // 内部コントロールを同一倍率でスケール適用
            //_scaler.ScaleToCurrentSize(this);
        }
    }
}