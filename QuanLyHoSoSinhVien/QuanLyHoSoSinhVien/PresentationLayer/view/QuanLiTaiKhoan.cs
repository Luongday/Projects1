using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.UserControl;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.UserDTO;
using QuanLyHoSoSinhVien.view;

namespace QuanLyHoSoSinhVien.PresentationLayer.view
{
    public partial class QuanLiTaiKhoan : Form
    {
        IServiceProvider serviceProvider;
        IEditRegisterController editRegisterController;
        IAddRegisterController addRegisterController;
        ManagerServicesFacade managerServicesFacade;
        UserDto userDto;
        public QuanLiTaiKhoan(IServiceProvider serviceProvider, ManagerServicesFacade managerServicesFacade, UserDto user)
        {
            this.serviceProvider = serviceProvider;
            this.editRegisterController = managerServicesFacade.editRegisterController;
            this.addRegisterController = managerServicesFacade.addRegisterController;
            this.userDto = user;
            InitializeComponent();

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveNewRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserDoiMk.Text) || string.IsNullOrEmpty(txtNewPassWord.Text) || string.IsNullOrWhiteSpace(txtNewPassWord.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }
            if (txtNewPassWord.Text.Trim() == userDto.passWord)
            {
                MessageBox.Show("Mật khẩu mới không được trùng với mật khẩu cũ");
                return;
            }
            if (editRegisterController.editRegister(new UserDto
            {
                userId = userDto.userId,
                userName = txtUserDoiMk.Text.Trim(),
                passWord = txtNewPassWord.Text.Trim(),
                isAdmin = userDto.isAdmin
            }))
            {
                MessageBox.Show("Cập nhật thành công");
                var loginFrm = serviceProvider.GetRequiredService<LoginFrm>();
                loginFrm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

        private void btnAddRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassWord.Text) || string.IsNullOrWhiteSpace(txtPassWord.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }
            if (txtUserName.Text.Trim().Length > 20 || txtPassWord.Text.Trim().Length > 20)
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được quá 20 ký tự");
                return;
            }
            if (addRegisterController.addRegisterController(new UserDto
            {
                userName = txtUserName.Text.Trim(),
                passWord = txtPassWord.Text.Trim(),
                isAdmin = cbxIsAdmin.Checked
            }))
            {
                MessageBox.Show("Thêm tài khoản thành công");
                txtUserName.Clear();
                txtPassWord.Clear();
                var menuManager = serviceProvider.GetRequiredService<MenuManagement>();
                menuManager.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
        }

        private void QuanLiTaiKhoan_Load(object sender, EventArgs e)
        {
            if (userDto.isAdmin)
            {

            }
            else
            {
                txtUserDoiMk.Text = userDto.userName;
                tpThemTaiKhoan.Hide();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            var menuManager = serviceProvider.GetRequiredService<MenuManagement>();
            menuManager.Show();
            this.Close();
        }
    }
}
