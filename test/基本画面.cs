namespace test
{
    public partial class �N����� : Form
    {
        public �N�����()
        {
            InitializeComponent();
        }

        private void M_Click(object sender, EventArgs e)
        {
            M �^�]�m = new M();
            �^�]�m.Show();
            this.WindowState = FormWindowState.Minimized;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.TopMost == false)
            {
                this.TopMost = true;
                button2.BackColor = Color.Yellow;
            }
            else
            {
                this.TopMost = false;
                button2.BackColor = Color.White;
            }
        }

        private void One_Click(object sender, EventArgs e)
        {
            One �����}�� = new One();
            �����}��.Show();
        }
        private void C_Click(object sender, EventArgs e)
        {
            C �ԏ� = new C();
            �ԏ�.Show();
        }
    }
}
