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
        UserDto userDto;
        public QuanLiTaiKhoan(IServiceProvider serviceProvider, IEditRegisterController editRegisterController, UserDto user)
        {
            this.serviceProvider = serviceProvider;
            this.editRegisterController = editRegisterController;
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

        }

        private void QuanLiTaiKhoan_Load(object sender, EventArgs e)
        {
            if (userDto.isAdmin)
            {

            }
            else
            {
                txtUserDoiMk.Text = userDto.userName;
            }
        }
    }
}
