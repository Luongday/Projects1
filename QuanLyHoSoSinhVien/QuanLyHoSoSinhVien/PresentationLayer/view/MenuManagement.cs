//using QuanLyHoSoSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.StudentControl;

namespace QuanLyHoSoSinhVien.view
{
    public partial class MenuManagement : Form
    {
        IStudentController studentController;
        public MenuManagement(IStudentController studentController)
        {
            InitializeComponent();
            this.studentController = studentController;
        }
        private void Load_SinhVien()
        {
            dgvSinhVien.Rows.Clear();

            var danhSach = studentController.getAllStudentWithFullInfor();

            foreach (var sv in danhSach)
            {
                dgvSinhVien.Rows.Add(
                    sv.maSV,
                    sv.tenSv,
                    sv.ngaySinh.ToString("dd/MM/yyyy"),
                    sv.GioiTinh,
                    sv.diaChi,
                    sv.sdt,
                    sv.danToc,
                    sv.tonGiao,
                    sv.email,
                    sv.cccd,
                    sv.noiSinh,
                    sv.trangThai,
                    sv.tenLop,
                    sv.tenNganh,
                    sv.tenKhoa
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Run(new view.ChiTietHoSo());
        }
    }
}
