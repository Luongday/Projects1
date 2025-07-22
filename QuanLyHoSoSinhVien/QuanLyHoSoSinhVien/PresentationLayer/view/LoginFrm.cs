using Guna.UI2.WinForms.Internal;
using Microsoft.Extensions.DependencyInjection;
using QuanLyHoSoSinhVien.BusinessLayer.Services.UserServices;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.StudentControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.UserControl;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.UserDTO;
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
        private IServiceProvider serviceProvider;
        IUserController userController;
        public LoginFrm(IUserController userControllers, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.userController = userControllers;
            txtPassword.UseSystemPasswordChar = true;
            tgShowHidePass.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.serviceProvider = serviceProvider;
            txtPassword.PlaceholderText = ". . . . . . . .";
        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String userName = txtUserName.Text;
            String password = txtPassword.Text;
            if (!string.IsNullOrEmpty(userName)&&!string.IsNullOrEmpty(password)&&userController.UserInfor(userName, password) != null)
            {
                var user = userController.UserInfor(userName, password);
                if (user!=null)
                {
                    var userDto = serviceProvider.GetRequiredService<UserDto>();
                    userDto.userId = user.userId; 
                    userDto.userName = userName;
                    userDto.passWord = password;
                    userDto.isAdmin = user.isAdmin;
                }
                if (user.isAdmin)
                {
                    // MessageBox.Show("Dang nhap thanh cong voi quyen quan ly");
                    // this.Hide();
                    // new view.ManagerManagement(userController).Show();
                    var managerFrm = serviceProvider.GetRequiredService<MenuManagement>();
                    managerFrm.Show();
                }
                else
                {
                    // MessageBox.Show("Dang nhap thanh cong voi quyen nguoi dung");
                    // this.Hide();
                    // new view.StudentManagement(userController).Show();
                    var studentFrm = serviceProvider.GetRequiredService<MenuStudent>();
                    studentFrm.Show();
                    this.Hide();
                }
               
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
                txtPassword.PlaceholderText = "Nhập mật khẩu";
                tgShowHidePass.IconChar = FontAwesome.Sharp.IconChar.Eye;
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.PlaceholderText = ". . . . . . . . .";
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

        private void LoginFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
