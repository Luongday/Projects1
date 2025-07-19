using QuanLyHoSoSinhVien.BusinessLayer.Services.DetailsProefileServices;
using QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.DetailsProfileRepository;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.DetailsProfileController;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.DetailsProfileDTO;
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
    public partial class ChiTietHoSo : Form
    {
        private string _maSv;
        private string _maHs;
        private readonly IDetailsProfileController _controller;
        public ChiTietHoSo(string masv, string mahs, IDetailsProfileController controller)
        {
            InitializeComponent();
            _maHs = mahs;
            _maSv = masv;
            _controller = controller;
        }


        private void LoadChiTietHoSo()
        {
            var Dto = _controller.takeAStudentWithFullInfor(_maSv);
            if (Dto == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên.");
                return;
            }

            lblMaHoSo.Text = _maHs;
            lblMaSv.Text = Dto.maSV;
            lblTenSv.Text = Dto.tenSv;
            lblDateTime.Text = Dto.ngaySinh.ToString();
            lblGioiTinh.Text = Dto.GioiTinh;
            lblDanToc.Text = Dto.danToc;
            lblTonGiao.Text = Dto.tonGiao;
            lblNoiSinh.Text = Dto.noiSinh;
            lblSdt.Text = Dto.sdt;
            lbltt.Text = Dto.trangThai;
            lblCCCD.Text = Dto.cccd;
            lblAddress.Text = Dto.diaChi;
            lblEmail.Text = Dto.email;
            lblClass.Text = Dto.tenLop;
            lblNganh.Text = Dto.tenNganh;
            lblKhoa.Text = Dto.tenKhoa;
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void ChiTietHoSo_Load(object sender, EventArgs e)
        {
            LoadChiTietHoSo();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
