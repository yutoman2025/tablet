namespace test
{
    public partial class ‹N“®‰æ–Ê : Form
    {
        public ‹N“®‰æ–Ê()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void M_Click(object sender, EventArgs e)
        {
            this.Hide();
            var M = new M();
            M.ShowDialog();
            this.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.TopMost == false)
            {
                this.TopMost = true;
                button3.BackColor = Color.Yellow;
            }
            else
            {
                this.TopMost = false;
                button3.BackColor = Color.White;
            }
        }

        private void One_Click(object sender, EventArgs e)
        {
            this.Hide();
            var One = new One();
            One.ShowDialog();
            this.Show();
        }
        private void C_Click(object sender, EventArgs e)
        {
            this.Hide();
            var C = new C();
            C.ShowDialog();
            this.Show();
        }
    }
}