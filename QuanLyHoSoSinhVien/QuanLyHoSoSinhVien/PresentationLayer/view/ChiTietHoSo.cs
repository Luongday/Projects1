using QuanLyHoSoSinhVien.BusinessLayer.Services.DetailsProefileServices;
using QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.DetailsProfileRepository;
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
        private readonly IGetInforStudent _getInforStudent;
        public ChiTietHoSo()
        {
            InitializeComponent();
            _getInforStudent = new GetInforStudentImpl(new DetailsProfileRepository(new DataContext()));

        }

      
        private void LoadHoSoSinhVien(DetailsProfileDto dp)
        {
            lblMaSv.Text = dp.maSV;
            lblTenSv.Text = dp.tenSv;
            lblDateTime.Text = dp.ngaySinh.ToString("dd/MM/yyyy");
            lblGioiTinh.Text = dp.GioiTinh;
            lblAddress.Text = dp.diaChi;
            lblEmail.Text = dp.email;
            lblCCCD.Text = dp.cccd;
            lblSdt.Text = dp.sdt;
            lblDanToc.Text = dp.danToc;
            lblTonGiao.Text = dp.tonGiao;
            lblNoiSinh.Text = dp.noiSinh;
            lbltt.Text = dp.trangThai;
            lblClass.Text = dp.tenLop;
            lblNganh.Text = dp.tenNganh;
            lblKhoa.Text = dp.tenKhoa;

        }

       
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void ChiTietHoSo_Load(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {

        }
    }
}
