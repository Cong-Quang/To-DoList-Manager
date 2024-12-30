using System;
using System.Windows.Forms;

namespace To_Do_List_Manager
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            HandleTD.gI().setup();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (userName.Text == "" || PassWord.Text == "")
                MessageBox.Show("Vui lòng không để trống ô tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else if (HandleUser.gI().CheckLogin(userName.Text, PassWord.Text, HandleTD.gI().users))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Handle h = new Handle(HandleUser.gI().Login(userName.Text, PassWord.Text, HandleTD.gI().users), HandleTD.gI().dataManager);

                this.Hide(); // ẩn nó đi

                h.ShowDialog();
                this.Show();

                this.Close(); // đóng task chính

                DataManager.gI().SaveData(HandleTD.gI().users); // lưu toàn bộ data và bộ giữ liệu ( nếu có data nào mới cx lưu luôn )
            }
            else MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            register r = new register();
            this.Hide();
            r.ShowDialog();
            this.Show();
        }
    }
}
