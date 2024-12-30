using System;
using System.Windows.Forms;

namespace To_Do_List_Manager
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void register_bt_Click(object sender, EventArgs e)
        {
            if (password.Text ==  "" ||checkpass.Text == "")
                MessageBox.Show("Vui lòng không để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (password.Text == checkpass.Text)
            {
                if (DataManager.gI().Register(username.Text, password.Text, HandleTD.gI().users, HandleTD.gI().dataManager))
                    MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Đã có tài khoản username.Text", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  
            else
                MessageBox.Show("Mật Khẩu phải giống nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void login_bt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
