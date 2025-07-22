using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Extensions.DependencyInjection;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.StudentControl;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.UserDTO;
using QuanLyHoSoSinhVien.PresentationLayer.view;

namespace QuanLyHoSoSinhVien.view
{
    public partial class MenuStudent : Form
    {
        IServiceProvider serviceProvider;
        IGetAStudentController studentController;
        UserDto userDto;

        public MenuStudent(IServiceProvider serviceProvider, IGetAStudentController studentController, UserDto userDto)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.studentController = studentController;
            this.userDto = userDto;
        }
        public void setPanel()
        {
            ThongTinCaNhanPanel.Enabled = true; // Bật tương tác
            ThongTinCaNhanPanel.Visible = true; // Hiển thị panel
            ThongTinCaNhanPanel.ShadowDepth = 20; // Độ sâu bóng (từ 1-10, càng cao càng đậm)
            ThongTinCaNhanPanel.ShadowColor = Color.DarkGray;
            ThongTinCaNhanPanel.Tag = ThongTinCaNhanPanel.Location;
            ThongTinLienHePanel.Enabled = true; // Bật tương tác
            ThongTinLienHePanel.Visible = true; // Hiển thị panel
            ThongTinLienHePanel.ShadowDepth = 20; // Độ sâu bóng (từ 1-10, càng cao càng đậm)
            ThongTinLienHePanel.ShadowColor = Color.DarkGray;
            ThongTinLienHePanel.Tag = ThongTinCaNhanPanel.Location;
        }
        public string getMaSVFromUserId()
        {
            if (string.IsNullOrEmpty(this.userDto.userId)) return "";
            this.userDto.userId = this.userDto.userId.Trim();
            const string suffix = "register";
            if (this.userDto.userId.EndsWith(suffix))
            {
                return this.userDto.userId.Substring(0, this.userDto.userId.Length - suffix.Length);
            }

            return "";
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var loginFrm = serviceProvider.GetRequiredService<LoginFrm>();
            loginFrm.Show();
            this.Close();
        }

        private void MenuStudent_Load(object sender, EventArgs e)
        {

            if (this.getMaSVFromUserId() == "")
            {
                MessageBox.Show("Không tìm thấy mã sinh viên từ userId. Vui lòng đăng nhập lại.");
                var loginFrm = serviceProvider.GetRequiredService<LoginFrm>();
                loginFrm.Show();
                this.Close();
            }
            var studentInfor = studentController.getAStudent(this.getMaSVFromUserId());
            if (studentInfor == null)
            {
                MessageBox.Show("Không tìm thấy mã sinh viên từ userId. Vui lòng đăng nhập lại.");
                var loginFrm = serviceProvider.GetRequiredService<LoginFrm>();
                loginFrm.Show();
                this.Close();
            }
            else
            {
                lblMaSv.Text = studentInfor.maSV;
                //.Text = studentInfor.hoTen;
                lblLop.Text = studentInfor.tenLop;
                lblNganh.Text = studentInfor.tenNganh;
                lblKhoa.Text = studentInfor.tenKhoa;
                lblEmail.Text = studentInfor.email;
                lblSdt.Text = studentInfor.sdt;
                lblNoiSinh.Text = studentInfor.noiSinh;
                lblNgaySinh.Text = studentInfor.ngaySinh.ToString("dd/MM/yyyy");
                lblGioiTinh.Text = studentInfor.GioiTinh;
                lblDanToc.Text = studentInfor.danToc;
                lblDiaChi.Text = studentInfor.diaChi;
                lblTonGiao.Text = studentInfor.tonGiao;
                lblCCCD.Text = studentInfor.cccd;
                trangthai.Text = studentInfor.trangThai;
                if (studentInfor.trangThai.Contains("Đang học"))
                {
                    lblTrangThai.ForeColor = Color.Green;
                }
                else if (studentInfor.trangThai.Contains("Tạm dừng"))
                {
                    lblTrangThai.ForeColor = Color.Orange;
                }
                lblstudentNameAtBanner.Text = $"<h1 style=\"color:#4B0082\">{studentInfor.tenSv}</h1>";
                lblstudentNameAtheader.Text = $"<h3 style=\"color:#4B0082\">{studentInfor.tenSv}</h3>";
                lblmsvAtHeader.Text = studentInfor.maSV;
            }
        }

        private void ThongTinCaNhanPanel_MouseEnter(object sender, EventArgs e)
        {
            var panel = sender as Guna2ShadowPanel;

            // Nâng panel lên 8px
            panel.Location = new Point(panel.Location.X, panel.Location.Y - 8);

            // Tăng shadow
            if (panel != null)
            {
                // Đảm bảo Tag là Point trước khi sử dụng
                if (panel.Tag is Point originalLocation)
                {
                    panel.Tag = originalLocation; // Giữ nguyên vị trí ban đầu
                }
                else
                {
                    panel.Tag = panel.Location; // Lưu vị trí hiện tại nếu chưa có
                }
                // Nâng panel lên 8px
                panel.Location = new Point(panel.Location.X, panel.Location.Y - 8);

                // Tăng hiệu ứng bóng
                panel.ShadowDepth = 100;
                panel.ShadowColor = Color.Gray;
            }
        }

        private void ThongTinCaNhanPanel_MouseLeave(object sender, EventArgs e)
        {
            var panel = sender as Guna2ShadowPanel;

            // Đưa panel về vị trí cũ
            panel.Location = new Point(panel.Location.X, panel.Location.Y + 8);

            if (panel != null)
            {
                // Trả panel về vị trí cũ từ Tag
                if (panel.Tag is Point originalLocation)
                {
                    panel.Location = originalLocation;
                }

                // Giảm hiệu ứng bóng
                panel.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
                panel.ShadowDepth = 20;
                panel.ShadowColor = Color.DarkGray;
            }
        }

        private void ThongTinLienHePanel_MouseEnter(object sender, EventArgs e)
        {
            var panel = sender as Guna2ShadowPanel;

            // Nâng panel lên 8px
            panel.Location = new Point(panel.Location.X, panel.Location.Y - 8);

            // Tăng shadow
            if (panel != null)
            {
                // Đảm bảo Tag là Point trước khi sử dụng
                if (panel.Tag is Point originalLocation)
                {
                    panel.Tag = originalLocation; // Giữ nguyên vị trí ban đầu
                }
                else
                {
                    panel.Tag = panel.Location; // Lưu vị trí hiện tại nếu chưa có
                }
                // Nâng panel lên 8px
                panel.Location = new Point(panel.Location.X, panel.Location.Y - 8);

                // Tăng hiệu ứng bóng
                panel.ShadowDepth = 100;
                panel.ShadowColor = Color.Gray;
            }
        }

        private void ThongTinLienHePanel_MouseLeave(object sender, EventArgs e)
        {
            var panel = sender as Guna2ShadowPanel;

            // Đưa panel về vị trí cũ
            panel.Location = new Point(panel.Location.X, panel.Location.Y + 8);

            if (panel != null)
            {
                // Trả panel về vị trí cũ từ Tag
                if (panel.Tag is Point originalLocation)
                {
                    panel.Location = originalLocation;
                }

                // Giảm hiệu ứng bóng
                panel.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
                panel.ShadowDepth = 20;
                panel.ShadowColor = Color.DarkGray;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                var menuRegister = serviceProvider.GetRequiredService<QuanLiTaiKhoan>();
                menuRegister.Show();
                this.Close();
            }
        }
    }
}
