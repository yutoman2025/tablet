namespace tc_staff_draw
{
    partial class DigitalStaff
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // DigitalStaff
            // 
            AutoScaleDimensions = new SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 621);
            Font = new Font("MS UI Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Name = "DigitalStaff";
            Text = "Form1";
            Paint += Form1_Paint;
            ResumeLayout(false);

        }

        #endregion
    }
}

