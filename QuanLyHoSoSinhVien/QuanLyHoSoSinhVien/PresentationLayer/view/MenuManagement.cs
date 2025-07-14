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
using QuanLyHoSoSinhVien.PresentationLayer;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.KhoaControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.LopControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.NganhControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.StudentControl;

namespace QuanLyHoSoSinhVien.view
{
    public partial class MenuManagement : Form
    {
        IStudentController studentController;
        INganhControllers nganhControllers;
        ILopController lopController;
        IKhoaController khoaController;
        ManagerServicesFacade managerServicesFacade;

        public MenuManagement(ManagerServicesFacade managerServicesFacade)
        {
            InitializeComponent();
            this.managerServicesFacade = managerServicesFacade;
            studentController = managerServicesFacade.studentController;
            nganhControllers = managerServicesFacade.nganhControllers;
            lopController = managerServicesFacade.lopController;
            khoaController = managerServicesFacade.KhoaController;
            TongSoSV.Text = studentController.totalStudent().ToString();
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
        private void LoadNganhDataToGrid()
        {
            var dsNganh = nganhControllers.getAllNganhWithFullInfor(); // gọi controller
            foreach (var nganh in dsNganh)
            {
                dgvNganh.Rows.Add(
                    nganh.maNganh,
                    nganh.tenNganh,
                    nganh.khoa,
                    nganh.soLop
                );
            }
        }
        private void LoadLopDataToGrid()
        {
            var dsLop = lopController.getAllLopWithFullInfor();
            foreach(var lop in dsLop)
            {
                dgvLop.Rows.Add(
                    lop.maLop,
                    lop.tenLop,
                    lop.nganh,
                    lop.khoa,
                    lop.siSo
                );
            }
        }
        private void LoadDataKhoaToGrid()
        {
            var dsKhoa = khoaController.getAllKhoaWithFullInfor();
            foreach(var khoa in dsKhoa)
            {
                dgvKhoa.Rows.Add(
                    khoa.maKhoa,
                    khoa.tenKhoa,
                    khoa.soNganh,
                    khoa.soLop
                );
            }
        }


        private void MenuManagement_Load(object sender, EventArgs e)
        {
            Load_SinhVien();
        }

        private void guna2TabControl2_MouseClick(object sender, MouseEventArgs e)
        {
            LoadNganhDataToGrid();
        }

        private void guna2TabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcQuanLiNganhKhoaLop.SelectedTab == tpNganh)
            {
                LoadNganhDataToGrid();
            }
            if (tcQuanLiNganhKhoaLop.SelectedTab == tpLop)
            {
                LoadLopDataToGrid();
            }
            if(tcQuanLiNganhKhoaLop.SelectedTab == tpKhoa)
            {
                LoadDataKhoaToGrid();
            }

        }

        private void tcMenuManager_MouseClick(object sender, MouseEventArgs e)
        {
            LoadNganhDataToGrid();
            lbltongSoNganh.Text = nganhControllers.totalNganh().ToString();
            lblTongSoLop.Text = lopController.totalLop().ToString();
            lblTongSoKhoa.Text = khoaController.totalKhoa().ToString();
        }
    }
}
