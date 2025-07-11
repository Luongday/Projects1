using QuanLyHoSoSinhVien.DAOHoSoSV;
using QuanLyHoSoSinhVien.model;
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
    public partial class MenuManagement : Form
    {
        DataContext _context = new DataContext();
        public MenuManagement()
        {
            InitializeComponent();
        }

        private void Load_SinhVien()
        {
            dgvSinhVien.Rows.Clear();

            var danhSach = (from sv in _context.SinhViens
                            join lop in _context.Lops on sv.malop equals lop.malop
                            join nganh in _context.Nganhs on lop.manganh equals nganh.manganh
                            join khoa in _context.Khoas on nganh.makhoa equals khoa.makhoa
                            select new
                            {
                                sv.masv,
                                sv.tensv,
                                sv.NgaySinh,
                                gioitinh = sv.gt ? "Nam" : "Nữ",
                                sv.dc,
                                sv.sdt,
                                sv.dantoc,
                                sv.tongiao,
                                sv.email,
                                sv.cccd,
                                sv.noisinh,
                                sv.trangthai,
                                tenlop = lop.tenlop,
                                tennganh = nganh.tennganh,
                                tenkhoa = khoa.tenkhoa
                            }).ToList();

            foreach (var sv in danhSach)
            {
                dgvSinhVien.Rows.Add(
                    sv.masv,
                    sv.tensv,
                    sv.NgaySinh.ToString("dd/MM/yyyy"),
                    sv.gioitinh,
                    sv.dc,
                    sv.sdt,
                    sv.dantoc,
                    sv.tongiao,
                    sv.email,
                    sv.cccd,
                    sv.noisinh,
                    sv.trangthai,
                    sv.tenlop,
                    sv.tennganh,
                    sv.tenkhoa
                );
            }
        }

        private void MenuManagement_Load(object sender, EventArgs e)
        {
            Load_SinhVien();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenNganh_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
