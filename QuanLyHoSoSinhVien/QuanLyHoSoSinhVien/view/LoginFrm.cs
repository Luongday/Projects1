using QuanLyHoSoSinhVien.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoSoSinhVien.view
{
    public partial class LoginFrm : Form
    {
        UserControllers userController = new UserControllers();
        public LoginFrm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            tgShowHidePass.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String userName = txtUserName.Text;
            String password = txtPassword.Text;
            if (userController.hasUser(userName, password))
            {
                this.Hide();
                new view.MenuManagement().Show();
            }
            else
            {
                MessageBox.Show("Thong tin tai khoan hoac mat khau khong chinh xac");
            }
        }

        private void tgShowHidePass_Click(object sender, EventArgs e)
        {
            if (tgShowHidePass.IconChar == FontAwesome.Sharp.IconChar.EyeSlash)
            {
                tgShowHidePass.IconChar = FontAwesome.Sharp.IconChar.Eye;
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tgShowHidePass.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {

                Application.Exit();
            }

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {



        }
    }
}
