﻿//using QuanLyHoSoSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;
using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.DependencyInjection;
using QuanLyHoSoSinhVien.BusinessLayer.Services.KhoaServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.DetailsProfileController;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.HoSoController;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.KhoaControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.LopControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.NganhControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.StudentControl;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDto;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.KhoaDTO;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.LopDTO;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.NganhDTO;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.StudentDTO;
using QuanLyHoSoSinhVien.PresentationLayer.view;

namespace QuanLyHoSoSinhVien.view
{
    public partial class MenuManagement : Form
    {
        private IServiceProvider serviceProvider;
        IStudentController studentController;
        IGetAllStudentDangHocController getAllStudentDangHocController;
        IGetSinhVienTamVangController getAllSinhVienTamVangComtroller;
        INganhControllers nganhControllers;
        IDeleteNganhController deleteNganhController;
        ILopController lopController;
        IAddLopController addLopController;
        IDeleteLopController deleteLopController;
        // IEditLopController editLopController;
        IEditLopController editLopController;
        IKhoaController khoaController;
        IGetKhoaForNameController getKhoaForNameController;
        IProfileController hoSoController;
        private readonly IDetailsProfileController chitietHSController;
        IDeleteKhoaController deleteKhoaController;
        IEditKhoaController editKhoaController;
        IEditProfileController editProfileController;
        IDeleteProfileController deleteProfileController;
        IGetLopForNganhController getLopForNganhController;
        IGetLopWithMaController getLopWithMaController;
        IGetLopWithNameController getLopWithNameController;
        IGetNganhForKhoaController getNganhForKhoaController;
        IGetNganhForNameController getNganhForNameController;
        IGetNganhForIdController getNganhForIdController;
        IDeleteStudentController deleteStudentController;
        IEditNganhController editNganhController;
        IEditDetailsProfileController editDetailsProfileController;
        IGetAllStudentForNganhController getAllStudnetForNganhController;
        IGetAllStudentForLopController getAllStudentForLopController;
        IGetAStudentController getAStudentController;
        ManagerServicesFacade managerServicesFacade;
        StudentDto sv;
        HoSoDto hoSo;
        public MenuManagement(ManagerServicesFacade managerServicesFacade, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.managerServicesFacade = managerServicesFacade;
            studentController = managerServicesFacade.studentController;
            nganhControllers = managerServicesFacade.nganhControllers;
            deleteNganhController = managerServicesFacade.deleteNganhController;
            lopController = managerServicesFacade.lopController;
            khoaController = managerServicesFacade.KhoaController;
            this.hoSoController = managerServicesFacade.hoSoController;
            this.deleteKhoaController = managerServicesFacade.deleteKhoaController;
            this.editKhoaController = managerServicesFacade.editKhoaController;
            this.serviceProvider = serviceProvider;
            this.chitietHSController = managerServicesFacade.detailsProfileController;
            this.deleteProfileController = managerServicesFacade.deleteProfileController;
            this.editProfileController = managerServicesFacade.editProfileController;
            this.addLopController = managerServicesFacade.addLopController;
            this.deleteLopController = managerServicesFacade.deleteLopController;
            this.editLopController = managerServicesFacade.editLopController;
            this.getAllStudentDangHocController = managerServicesFacade.getAllStudentDangHocController;
            this.getAllSinhVienTamVangComtroller = managerServicesFacade.getAllSinhVienTamVangComtroller;
            this.getKhoaForNameController = managerServicesFacade.getKhoaForNameController;
            this.getLopForNganhController = managerServicesFacade.getLopForNganh;
            this.getLopWithMaController = managerServicesFacade.getLopWithMa;
            this.getLopWithNameController = managerServicesFacade.getLopWithName;
            this.getNganhForKhoaController = managerServicesFacade.getNganhForKhoaController;
            this.getNganhForNameController = managerServicesFacade.getNganhForNameController;
            this.getNganhForIdController = managerServicesFacade.getNganhForIdController;
            this.deleteStudentController = managerServicesFacade.deleteStudentController;
            this.editNganhController = managerServicesFacade.editnganhController;
            this.editDetailsProfileController = managerServicesFacade.editDetailsProfileController;
            this.getAllStudnetForNganhController = managerServicesFacade.getAllStudnetForNganh;
            this.getAllStudentForLopController = managerServicesFacade.getAllStudentForLop;
            this.getAStudentController = managerServicesFacade.getAStudent;
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
        private void LoadSinhVienDangHoc()
        {
            dgvDSSVDangHoc.Rows.Clear();


            var danhSach = getAllStudentDangHocController.getAllStudentDangHoc();
            //  dgvDSSVDangHoc.DataSource = danhSach;


            foreach (var sv in danhSach)
            {
                dgvDSSVDangHoc.Rows.Add(
                    sv.maSV,
                    sv.tenSv,
                    sv.ngaySinh.ToString("dd/MM/yyyy"),
                    sv.GioiTinh,
                    sv.diaChi,
                    sv.sdt,
                    sv.tenLop
                );
            }
        }

        private void LoadSinhVienTamVang()
        {
            dgvDSSVTamVang.Rows.Clear();


            var danhSach = getAllSinhVienTamVangComtroller.getAllSinhVienTotNghiep();
            //  dgvDSSVDangHoc.DataSource = danhSach;


            foreach (var sv in danhSach)
            {
                dgvDSSVTamVang.Rows.Add(
                    sv.maSV,
                    sv.tenSv,
                    sv.ngaySinh.ToString("dd/MM/yyyy"),
                    sv.GioiTinh,
                    sv.diaChi,
                    sv.sdt,
                    sv.tenLop
                );
            }
        }
        private void LoadNganhDataToGrid()
        {
            dgvNganh.Rows.Clear();
            var dsNganh = nganhControllers.getAllNganhWithFullInfor();
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
            dgvLop.Rows.Clear();
            var dsLop = lopController.getAllLopWithFullInfor();
            foreach (var lop in dsLop)
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
            dgvKhoa.Rows.Clear();
            foreach (var khoa in dsKhoa)
            {
                dgvKhoa.Rows.Add(
                    khoa.maKhoa,
                    khoa.tenKhoa,
                    khoa.soNganh,
                    khoa.soLop
                );
            }
        }

        private void LoadHoSo()
        {
            lblTotalProfile.Text = hoSoController.TotalProfile().ToString();
            dgvHoSoSv.DataSource = null;
            var hoso = hoSoController.getAllHoSo();
            dgvHoSoSv.DataSource = hoso;
            dgvHoSoSv.Columns["trangthaihoso"].Visible = false;
        }

        private void LoadChartThongKe(int dangHoc, int tamVang)
        {
            //chartThongKe.Series.Clear();
            //chartThongKe.Titles.Clear();

            //chartThongKe.Titles.Add("Thống kê sinh viên");

            //Series series = new Series
            //{
            //    Name = "SinhVien",
            //    IsValueShownAsLabel = true,
            //    ChartType = SeriesChartType.Pie
            //};

            //series.Points.AddXY("Đang học", dangHoc);
            //series.Points.AddXY("Tạm vắng", tamVang);
            //series.Points[0].Color = Color.Green;  // Đang học = Xanh
            //series.Points[1].Color = Color.Red;
            int totalDangHoc = studentController.totalStudentDangHoc();
            int totalTamVang = studentController.totalStudentTamVang();

            // Cập nhật giá trị Y của từng DataPoint
            chartThongKe.Series["Series1"].Points[0].YValues[0] = totalDangHoc;
            chartThongKe.Series["Series1"].Points[1].YValues[0] = totalTamVang;

        }

        public void AddNganhToComboBox(ComboBox cbx)
        {
            try
            {
                List<NganhDto> lNganhDto = nganhControllers.getAllNganhWithFullInfor() ?? new List<NganhDto>();
                cbx.DataSource = null;
                cbx.Items.Clear();
                cbx.DataSource = lNganhDto.Select(ng => ng.tenNganh).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NganhController is null");
            }

        }

        public void AddMaNganhToComboBox(ComboBox cbx)
        {
            try
            {
                List<NganhDto> lNganhDto = nganhControllers.getAllNganhWithFullInfor() ?? new List<NganhDto>();
                cbx.DataSource = null;
                cbx.Items.Clear();
                cbx.DataSource = lNganhDto.Select(ng => ng.maNganh).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NganhController is null");
            }

        }
        public void addKhoaToCombobox(ComboBox cbx)
        {
            try
            {
                List<KhoaDto> lKhoaDto = khoaController.getAllKhoaWithFullInfor() ?? new List<KhoaDto>();
                cbx.DataSource = null;
                cbx.Items.Clear();
                cbx.DataSource = lKhoaDto.Select(kh => kh.tenKhoa).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NganhController is null");
            }
        }
        public void addMaKhoaToCombobox(ComboBox cbx)
        {
            try
            {
                List<KhoaDto> lKhoaDto = khoaController.getAllKhoaWithFullInfor() ?? new List<KhoaDto>();
                cbx.DataSource = null;
                cbx.Items.Clear();
                cbx.DataSource = lKhoaDto.Select(kh => kh.maKhoa).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NganhController is null");
            }
        }
        public void addLopToCombobox(ComboBox cbx)
        {
            try
            {
                List<LopDto> lLopDto = lopController.getAllLopWithFullInfor() ?? new List<LopDto>();
                cbx.DataSource = null;
                cbx.Items.Clear();
                cbx.DataSource = lLopDto.Select(l => l.tenLop).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NganhController is null");
            }
        }
        public void addMaLopToCombobox(ComboBox cbx)
        {
            try
            {
                List<LopDto> lLopDto = lopController.getAllLopWithFullInfor() ?? new List<LopDto>();
                cbx.DataSource = null;
                cbx.Items.Clear();
                cbx.DataSource = lLopDto.Select(l => l.maLop).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NganhController is null");
            }
        }
        public void AddKhoaToComboBoxKhoaInTabPageNganh()
        {
            try
            {
                List<KhoaDto> khoaDto = khoaController.getAllKhoaWithFullInfor() ?? new List<KhoaDto>();
                List<String> items = new List<string>();
                foreach (KhoaDto k in khoaDto)
                {
                    items.Add(k.tenKhoa);
                }
                cbxDsKhoa.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show("khoaController is null");
            }

        }
        public void AddMaSVtoCombobox(ComboBox cbx)
        {
            try
            {
                List<StudentDto> lStudentDto = studentController.getAllStudentWithFullInfor() ?? new List<StudentDto>();
                cbx.DataSource = null;
                cbx.Items.Clear();
                cbx.DataSource = lStudentDto.Select(sv => sv.maSV).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("StudentController is null");
            }
        }
        public void setPanel()
        {
            btnDSSVDangHoc.Enabled = true; // Bật tương tác
            btnDSSVDangHoc.Visible = true; // Hiển thị panel
            btnDSSVDangHoc.ShadowDepth = 20; // Độ sâu bóng (từ 1-10, càng cao càng đậm)
            btnDSSVDangHoc.ShadowShift = 10;
            btnDSSVDangHoc.ShadowColor = Color.DarkGray;
            btnDSSVDangHoc.Tag = btnDSSVDangHoc.Location;
            btnDSSVTamVang.Enabled = true; // Bật tương tác
            btnDSSVTamVang.Visible = true; // Hiển thị panel
            btnDSSVTamVang.ShadowDepth = 20; // Độ sâu bóng (từ 1-10, càng cao càng đậm)
            btnDSSVTamVang.ShadowShift = 10;
            btnDSSVTamVang.ShadowColor = Color.DarkGray;
            btnDSSVTamVang.Tag = btnDSSVTamVang.Location;
        }
        private void MenuManagement_Load(object sender, EventArgs e)
        {
            Load_SinhVien();
            LoadHoSo();
            cboOptions.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;
            // Ẩn tất cả
            txtMahs.Visible = false;
            lblMahs.Visible = false;
            txtMasv.Visible = false;
            lblMasv.Visible = false;
            cboTrangThai.Visible = false;
            lblmhs.Visible = false;
            lblmsv.Visible = false;
            txtmhs.Visible = false;
            txtmsv.Visible = false;
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
                AddKhoaToComboBoxKhoaInTabPageNganh();
            }
            if (tcQuanLiNganhKhoaLop.SelectedTab == tpLop)
            {
                LoadLopDataToGrid();
                AddNganhToComboBox(cbxNganhAtTPLop);
            }
            if (tcQuanLiNganhKhoaLop.SelectedTab == tpKhoa)
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

        private string? selectedMaSv = null;
        private string? selectedMaHs = null;
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedMaSv) || string.IsNullOrWhiteSpace(selectedMaHs) || string.IsNullOrEmpty(selectedMaSv) || string.IsNullOrEmpty(selectedMaHs))
            {
                MessageBox.Show("Vui lòng chọn hồ sơ sinh viên từ danh sách!");
                return;
            }
            var chiTietHoSo = new ChiTietHoSo(selectedMaSv, selectedMaHs, chitietHSController, lopController, nganhControllers, khoaController, studentController, editDetailsProfileController, serviceProvider, this);
            this.Hide();
            chiTietHoSo.ShowDialog();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoSoSv.Rows[e.RowIndex];
                selectedMaHs = row.Cells["mahs"].Value?.ToString();
                selectedMaSv = row.Cells["masv"].Value?.ToString();
            }
        }

        private void tcMenuManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcMenuManager.SelectedTab == tpQuanLiHoSo)
            {
                LoadHoSo();
            }
            if (tcMenuManager.SelectedTab == tpBaoCaoThongKe)
            {
                lblToTalSinhVienDangHoc.Text = studentController.totalStudentDangHoc().ToString();
                lblTotalSinVienTamVang.Text = studentController.totalStudentTamVang().ToString();
                LoadChartThongKe(studentController.totalStudentDangHoc(), studentController.totalStudentTamVang());
            }
            if (tcMenuManager.SelectedTab == tpQuanLiTaiKhoan)
            {
                var qltkFrm = serviceProvider.GetRequiredService<QuanLiTaiKhoan>();
                qltkFrm.Show();
                this.Hide();
            }
        }

        private void dgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow current = dgvKhoa.CurrentRow;
            if (current != null)
            {
                txtMaKhoa.Text = current.Cells["MaKhoaCol"].Value?.ToString();
                txtTenKhoa.Text = current.Cells["TenKhoaCol"].Value?.ToString();
            }
        }

        private void btnXoaKhoa_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text == null || txtMaKhoa.Text == "")
            {
                MessageBox.Show("Bạn cần nhập thông tin mã khoa muốn xóa!");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn muốn xóa Khoa này?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (deleteKhoaController.DeleteById(txtMaKhoa.Text))
                    {
                        MessageBox.Show("Xóa thành công");
                        LoadDataKhoaToGrid();
                    }
                    else
                    {
                        MessageBox.Show("Không có khoa này");
                    }

                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var ThemKhoaFrm = serviceProvider.GetRequiredService<ThemKhoa>();
            ThemKhoaFrm.Show();
        }
        private void RefreshData()
        {
            try
            {
                LoadDataKhoaToGrid();

                // Clear form sau khi update thành công
                txtMaKhoa.Clear();
                txtTenKhoa.Clear();

                // Focus vào control đầu tiên
                txtMaKhoa.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKhoa.Text) || string.IsNullOrEmpty(txtTenKhoa.Text))
            {
                MessageBox.Show("Bạn cần nhập đủ thông tin");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn muốn sửa thông tin?", "thông báo", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    if (editKhoaController.editKhoa(txtMaKhoa.Text, txtTenKhoa.Text))
                    {
                        MessageBox.Show("Sửa thành công.");
                        RefreshData();
                        LoadDataKhoaToGrid();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công!!!");
                    }
                }
            }
        }

        private void dgvNganh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow current = dgvNganh.CurrentRow;
            if (current != null)
            {
                txtMaNganh.Text = current.Cells["maNganhCol"].Value?.ToString();
                txtTenNganh.Text = current.Cells["tenNganhCol"].Value?.ToString();
                cbxDsKhoa.Text = current.Cells["khoaCol"].Value?.ToString();
            }
        }

        private void btnXoaNganh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNganh.Text))
            {
                MessageBox.Show("Bạn cần nhập mã ngành muốn xóa!");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn muốn xóa Ngành này?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (deleteNganhController.deleteNganhWithId(txtMaNganh.Text))
                    {
                        MessageBox.Show("Xóa thành công");
                        LoadNganhDataToGrid();
                    }
                    else
                    {
                        MessageBox.Show("Không có ngành này");
                    }
                }
            }
        }

        private void btnThemNganh_Click(object sender, EventArgs e)
        {
            var ThemNganhFrm = serviceProvider.GetRequiredService<ThemNganhFrm>();
            ThemNganhFrm.Show();
            this.Hide();
        }
        HoSoDto hoSoDto;

        private void dgvHoSoSv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoSoSv.Rows[e.RowIndex];
                selectedMaHs = row.Cells[0].Value?.ToString();
                selectedMaSv = row.Cells[1].Value?.ToString();
                hoSoDto = new HoSoDto
                {
                    mahs = row.Cells[0].Value?.ToString() ?? "a",
                    masv = row.Cells[1].Value?.ToString() ?? "b",
                    ngaycapnhat = DateTime.Parse(row.Cells[3].Value?.ToString() ?? "2000/1/1"),
                    trangthaihoso = row.Cells[5].Value?.ToString() == "Không hoạt động" ? false : true
                };

            }
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedMaHs) || string.IsNullOrEmpty(selectedMaHs))
            {
                MessageBox.Show("Không tồn tại hồ sơ có!");
                return;
            }

            if (string.IsNullOrWhiteSpace(selectedMaSv) || string.IsNullOrWhiteSpace(selectedMaHs))
            {
                MessageBox.Show("Vui lòng chọn hồ sơ sinh viên từ danh sách!");
                return;
            }

            if (hoSoDto.trangthaihoso == false)
            {
                MessageBox.Show("Hồ sơ đã bị xóa!");
                return;
            }

            var tmp = deleteProfileController.DeleteProfile(selectedMaHs);
            if (tmp != null)
            {
                MessageBox.Show(tmp);
                LoadHoSo();
                Load_SinhVien();
            }
            else
            {
                MessageBox.Show(tmp);
            }
        }

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            var themLopFrm = serviceProvider.GetRequiredService<ThemLopFrm>();
            themLopFrm.Show();
            this.Hide();
        }

        private void btnXoaLop_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLop.Text))
            {
                MessageBox.Show("Bạn cần nhập mã lớp muốn xóa");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn muốn xóa lớp này?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (deleteLopController.deleteLop(txtMaLop.Text))
                {
                    MessageBox.Show("Xóa lớp thành công");
                    LoadLopDataToGrid();
                }
                else
                {
                    MessageBox.Show("Không có lớp này");
                }
            }
        }

        private void btnSuaLop_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLop.Text) || string.IsNullOrEmpty(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn muốn sửa thông tin lớp này?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (editLopController.editLop(new LopDto
                {
                    maLop = txtMaLop.Text.Trim(),
                    tenLop = txtTenLop.Text,
                    nganh = cbxNganhAtTPLop?.SelectedItem!.ToString() ?? ""
                }))
                {
                    MessageBox.Show("Sửa lớp thành công");
                    LoadLopDataToGrid();
                }
                else
                {
                    MessageBox.Show("Sửa lớp thất bại, vui lòng kiểm tra lại thông tin");
                }
            }
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow current = dgvLop.CurrentRow;
            if (current != null)
            {
                txtMaLop.Text = current.Cells["maLopColAtTpLop"].Value?.ToString();
                txtTenLop.Text = current.Cells["tenLopColAtTpLop"].Value?.ToString();
                cbxNganhAtTPLop.Text = current.Cells["nganhColAtTpLop"].Value?.ToString();
            }

        }

        private void btnClearText_Click(object sender, EventArgs e)
        {
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            cbxNganhAtTPLop.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFieldSearchNganh.SelectedIndex == 0)
            {
                AddMaNganhToComboBox(cbxTimKiemForNganh);
            }
            else if (cbxFieldSearchNganh.SelectedIndex == 1)
            {
                AddNganhToComboBox(cbxTimKiemForNganh);
            }
            else if (cbxFieldSearchNganh.SelectedIndex == 2)
            {
                addKhoaToCombobox(cbxTimKiemForNganh);
            }
            else
            {
                AddNganhToComboBox(cbxTimKiemForNganh);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFieldSearchKhoa.SelectedIndex == 0)
            {
                addMaKhoaToCombobox(cbxTimKiemForKhoa);
            }
            else if (cbxFieldSearchKhoa.SelectedIndex == 1)
            {
                addKhoaToCombobox(cbxTimKiemForKhoa);
            }
            else
            {
                addKhoaToCombobox(cbxTimKiemForKhoa);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFieldSearchLop.SelectedIndex == 0)
            {
                addMaLopToCombobox(cbxTimKiemForLop);
            }
            else if (cbxFieldSearchLop.SelectedIndex == 1)
            {
                addLopToCombobox(cbxTimKiemForLop);
            }
            else if (cbxFieldSearchLop.SelectedIndex == 2)
            {
                AddNganhToComboBox(cbxTimKiemForLop);
            }
            else
            {
                addLopToCombobox(cbxTimKiemForLop);
            }
        }

        private void guna2ShadowPanel6_Paint(object sender, PaintEventArgs e)
        {
            //dgvDSSVDangHoc.Visible = true;

            //LoadSinhVienDangHoc();

            //dgvDSSVDangHoc.Show();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void btnDSSVDangHoc_MouseEnter(object sender, EventArgs e)
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

                //Tăng hiệu ứng bóng
                panel.ShadowDepth = 110;
                // panel.ShadowShift = 15;
                panel.ShadowColor = Color.Black;
            }
        }

        private void btnDSSVDangHoc_MouseLeave(object sender, EventArgs e)
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
                panel.ShadowDepth = 100;
                //panel.ShadowShift = 5;
                panel.ShadowColor = Color.Black;

            }
        }

        private void btnDSSVTamVang_MouseEnter(object sender, EventArgs e)
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
                panel.ShadowDepth = 110;
                //panel.ShadowShift = 5;
                panel.ShadowColor = Color.Black;

            }
        }

        private void btnDSSVTamVang_MouseLeave(object sender, EventArgs e)
        {
            var panel = sender as Guna2ShadowPanel;


            // Đưa panel về vị trí cũ
            panel.Location = new Point(panel.Location.X, panel.Location.Y + 6);

            if (panel != null)
            {
                // Trả panel về vị trí cũ từ Tag
                if (panel.Tag is Point originalLocation)
                {
                    panel.Location = originalLocation;
                }

                // Giảm hiệu ứng bóng
                panel.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
                panel.ShadowDepth = 100;
                //panel.ShadowShift = 15;
                panel.ShadowColor = Color.Black;

            }
        }

        private void btnDSSVDangHoc_MouseClick(object sender, MouseEventArgs e)
        {
            dgvDSSVDangHoc.Visible = true;

            LoadSinhVienDangHoc();

            dgvDSSVDangHoc.Show();
        }

        private void btnDSSVTamVang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDSSVTamVang_MouseClick(object sender, MouseEventArgs e)
        {
            dgvDSSVTamVang.Visible = true;

            LoadSinhVienTamVang();

            dgvDSSVDangHoc.Hide();
            dgvDSSVTamVang.Show();
        }

        private void btnTimKiemNganh_Click(object sender, EventArgs e)
        {
            if (cbxFieldSearchNganh.SelectedIndex == 0)
            {
                if (string.IsNullOrEmpty(cbxTimKiemForNganh.Text))
                {
                    MessageBox.Show("Vui lòng chọn mã ngành để tìm kiếm");
                    return;
                }
                var dsNganh = getNganhForIdController.getNganhForId(cbxTimKiemForNganh.Text);
                dgvNganh.Rows.Clear();
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
            else if (cbxFieldSearchNganh.SelectedIndex == 1)
            {
                if (string.IsNullOrEmpty(cbxTimKiemForNganh.Text))
                {
                    MessageBox.Show("Vui lòng chọn tên ngành để tìm kiếm");
                    return;
                }
                var dsNganh = getNganhForNameController.getNganhForName(cbxTimKiemForNganh.Text);
                dgvNganh.Rows.Clear();
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
            else if (cbxFieldSearchNganh.SelectedIndex == 2)
            {
                if (string.IsNullOrEmpty(cbxTimKiemForNganh.Text))
                {
                    MessageBox.Show("Vui lòng chọn khoa để tìm kiếm");
                    return;
                }
                var dsNganh = getNganhForKhoaController.getNganhForKhoa(cbxTimKiemForNganh.Text);
                dgvNganh.Rows.Clear();
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
        }

        private void btnTimKiemKhoa_Click(object sender, EventArgs e)
        {
            if (cbxFieldSearchKhoa.SelectedIndex == 0)
            {
                if (string.IsNullOrEmpty(cbxTimKiemForKhoa.Text))
                {
                    MessageBox.Show("Vui lòng chọn mã khoa để tìm kiếm");
                    return;
                }
                var khoa = khoaController.getByMa(cbxTimKiemForKhoa.Text);
                dgvKhoa.Rows.Clear();
                dgvKhoa.Rows.Add(
                    khoa.maKhoa,
                    khoa.tenKhoa,
                    khoa.soNganh,
                    khoa.soLop
                );
            }

            else if (cbxFieldSearchKhoa.SelectedIndex == 1)
            {
                if (string.IsNullOrEmpty(cbxTimKiemForKhoa.Text))
                {
                    MessageBox.Show("Vui lòng chọn tên khoa để tìm kiếm");
                    return;
                }
                var dsKhoa = getKhoaForNameController.getKhoaForName(cbxTimKiemForKhoa.Text);
                dgvKhoa.Rows.Clear();
                foreach (var khoa in dsKhoa)
                {
                    dgvKhoa.Rows.Add(
                        khoa.maKhoa,
                        khoa.tenKhoa,
                        khoa.soNganh,
                        khoa.soLop
                    );
                }
            }
        }

        private void btnTimKiemLop_Click(object sender, EventArgs e)
        {
            if (cbxFieldSearchLop.SelectedIndex == 0)
            {
                if (string.IsNullOrEmpty(cbxTimKiemForLop.Text))
                {
                    MessageBox.Show("Vui lòng chọn mã lớp để tìm kiếm");
                    return;
                }
                var lop = getLopWithMaController.getLopWithMa(cbxTimKiemForLop.Text);
                dgvLop.Rows.Clear();
                dgvLop.Rows.Add(
                    lop.maLop,
                    lop.tenLop,
                    lop.nganh,
                    lop.khoa,
                    lop.siSo
                );
            }
            else if (cbxFieldSearchLop.SelectedIndex == 1)
            {
                if (string.IsNullOrEmpty(cbxTimKiemForLop.Text))
                {
                    MessageBox.Show("Vui lòng chọn tên lớp để tìm kiếm");
                    return;
                }
                var dsLop = getLopWithNameController.getLopWithName(cbxTimKiemForLop.Text);
                dgvLop.Rows.Clear();
                foreach (var lop in dsLop)
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
            else if (cbxFieldSearchLop.SelectedIndex == 2)
            {
                if (string.IsNullOrEmpty(cbxTimKiemForLop.Text))
                {
                    MessageBox.Show("Vui lòng chọn ngành để tìm kiếm");
                    return;
                }
                var dsLop = getLopForNganhController.getLopForNganh(cbxTimKiemForLop.Text);
                dgvLop.Rows.Clear();
                foreach (var lop in dsLop)
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
        }

        private void btnXoaSinhVien_Click(object sender, EventArgs e)
        {
            string masv = sv.maSV;
            if (string.IsNullOrEmpty(masv))
            {
                MessageBox.Show("Vui lòng chọn sinh viên để xóa.");
                return;
            }
            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa sinh viên {masv}?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool isDeleted = deleteStudentController.deleteStudent(masv);
                if (isDeleted)
                {
                    MessageBox.Show("Xóa sinh viên thành công.");
                    Load_SinhVien();
                }
                else
                {
                    MessageBox.Show("Xóa sinh viên không thành công. Vui lòng kiểm tra lại.");
                }
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow current = dgvSinhVien.CurrentRow;
            sv = new StudentDto
            {
                maSV = current.Cells["msvColInDgvSV"].Value?.ToString() ?? "",
                tenSv = current.Cells["tenSVColInDgvSV"].Value?.ToString() ?? "",
                // ngaySinh = DateTime.Parse(current.Cells["ngaySinhColInDgvSv"].Value?.ToString("yyyy/MM/dd") ?? "2000/01/01"),
                GioiTinh = current.Cells["gtColInDgvSV"].Value?.ToString() ?? "",
                //  diaChi = current.Cells["diaChiColInDgvSV"].Value?.ToString() ?? "",
                sdt = current.Cells["sdtColInDgvSV"].Value?.ToString() ?? "",
                danToc = current.Cells["danTocInDgvSV"].Value?.ToString() ?? "",
                tonGiao = current.Cells["tonGiaoInDgvSV"].Value?.ToString() ?? "",
                email = current.Cells["emailInDgvSV"].Value?.ToString() ?? "",
                cccd = current.Cells["cccdColInDgvSV"].Value?.ToString() ?? "",
                noiSinh = current.Cells["noiSinhColInDgvSV"].Value?.ToString() ?? "",
                trangThai = current.Cells["trangThaiColInDgvSV"].Value?.ToString() ?? "",
                tenLop = current.Cells["lopColInDgvSV"].Value?.ToString() ?? "",
                tenNganh = current.Cells["nganhInDgvSV"].Value?.ToString() ?? "",
                tenKhoa = current.Cells["khoaInDgvSV"].Value?.ToString() ?? ""
            };
        }

        private void btnThemSinhVien_Click(object sender, EventArgs e)
        {
            var themSinhVienFrm = serviceProvider.GetRequiredService<ThemSV>();
            themSinhVienFrm.Show();
            this.Hide();
        }

        private void btnSuaNganh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNganh.Text) || string.IsNullOrEmpty(txtTenNganh.Text) || string.IsNullOrEmpty(cbxDsKhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn muốn sửa thông tin ngành này?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (editNganhController.editNganh(new NganhDto
                {
                    maNganh = txtMaNganh.Text,
                    tenNganh = txtTenNganh.Text,
                    khoa = cbxDsKhoa?.SelectedItem!.ToString() ?? ""
                }))
                {
                    MessageBox.Show("Sửa ngành thành công");
                    LoadNganhDataToGrid();
                }
                else
                {
                    MessageBox.Show("Sửa ngành thất bại, vui lòng kiểm tra lại thông tin");
                }
            }
        }

        private void cboFieldForSearchSinhVien_TextChanged(object sender, EventArgs e)
        {
            if (cboFieldForSearchSinhVien.SelectedIndex == 0)
            {
                //AddMaNganhToComboBox(cboTimKiemSinhVien);
            }
            else if (cboFieldForSearchSinhVien.SelectedIndex == 1)
            {
                addLopToCombobox(cboSearchSinhVien);
            }
            else if (cboFieldForSearchSinhVien.SelectedIndex == 2)
            {
                AddNganhToComboBox(cboSearchSinhVien);
            }
            else if (cboFieldForSearchSinhVien.SelectedIndex == 3)
            {
                cboSearchSinhVien.DataSource = new List<string> { "Đang học", "Tốt nghiệp" };

            }
        }

        private void cboFieldForSearchSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFieldForSearchSinhVien.SelectedIndex == 0)
            {
                AddMaSVtoCombobox(cboSearchSinhVien);
            }
            else if (cboFieldForSearchSinhVien.SelectedIndex == 1)
            {
                addLopToCombobox(cboSearchSinhVien);
            }
            else if (cboFieldForSearchSinhVien.SelectedIndex == 2)
            {
                AddNganhToComboBox(cboSearchSinhVien);
            }
            else if (cboFieldForSearchSinhVien.SelectedIndex == 3)
            {
                cboSearchSinhVien.DataSource = new List<string> { "Đang học", "Tốt nghiệp" };

            }
        }

        private void btnTimKiemForStudent_Click(object sender, EventArgs e)
        {
            if (cboFieldForSearchSinhVien.SelectedIndex == 0)
            {
                var StudentWithId = getAStudentController.getAStudent(cboSearchSinhVien.Text);
                if (StudentWithId != null)
                {
                    dgvSinhVien.Rows.Clear();
                    dgvSinhVien.Rows.Add(
                        StudentWithId.maSV,
                        StudentWithId.tenSv,
                        StudentWithId.ngaySinh.ToString("yyyy/MM/dd"),
                        StudentWithId.GioiTinh,
                        StudentWithId.diaChi,
                        StudentWithId.sdt,
                        StudentWithId.danToc,
                        StudentWithId.tonGiao,
                        StudentWithId.email,
                        StudentWithId.cccd,
                        StudentWithId.noiSinh,
                        StudentWithId.trangThai,
                        StudentWithId.tenLop,
                        StudentWithId.tenNganh,
                        StudentWithId.tenKhoa
                    );
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên với mã này.");
                }
            }
            else if (cboFieldForSearchSinhVien.SelectedIndex == 1)
            {
                var lStudentInLop = getAllStudentForLopController.getAllStudentForLop(cboSearchSinhVien.Text);
                if (lStudentInLop != null)
                {
                    dgvSinhVien.Rows.Clear();
                    foreach (var student in lStudentInLop)
                    {

                        dgvSinhVien.Rows.Add(
                            student.maSV,
                            student.tenSv,
                            student.ngaySinh.ToString("yyyy/MM/dd"),
                            student.GioiTinh,
                            student.diaChi,
                            student.sdt,
                            student.danToc,
                            student.tonGiao,
                            student.email,
                            student.cccd,
                            student.noiSinh,
                            student.trangThai,
                            student.tenLop,
                            student.tenNganh,
                            student.tenKhoa
                        );
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên trong lớp này.");
                }
            }
            else if (cboFieldForSearchSinhVien.SelectedIndex == 2)
            {
                var lStudentInNganh = getAllStudnetForNganhController.getStudentForNganhController(cboSearchSinhVien.Text);
                if (lStudentInNganh != null)
                {
                    dgvSinhVien.Rows.Clear();
                    foreach (var student in lStudentInNganh)
                    {

                        dgvSinhVien.Rows.Add(
                            student.maSV,
                            student.tenSv,
                            student.ngaySinh.ToString("yyyy/MM/dd"),
                            student.GioiTinh,
                            student.diaChi,
                            student.sdt,
                            student.danToc,
                            student.tonGiao,
                            student.email,
                            student.cccd,
                            student.noiSinh,
                            student.trangThai,
                            student.tenLop,
                            student.tenNganh,
                            student.tenKhoa
                        );
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên trong ngành này.");
                }
            }
            else if (cboFieldForSearchSinhVien.SelectedIndex == 3)
            {
                if (cboSearchSinhVien.Text.Contains("Đang học"))
                {
                    var lStudentWithStatusDangHoc = getAllStudentDangHocController.getAllStudentDangHoc();
                    if (lStudentWithStatusDangHoc != null)
                    {
                        dgvSinhVien.Rows.Clear();
                        foreach (var student in lStudentWithStatusDangHoc)
                        {

                            dgvSinhVien.Rows.Add(
                                student.maSV,
                                student.tenSv,
                                student.ngaySinh.ToString("yyyy/MM/dd"),
                                student.GioiTinh,
                                student.diaChi,
                                student.sdt,
                                student.danToc,
                                student.tonGiao,
                                student.email,
                                student.cccd,
                                student.noiSinh,
                                student.trangThai,
                                student.tenLop,
                                student.tenNganh,
                                student.tenKhoa
                            );
                        }
                    }
                }
                if (cboSearchSinhVien.Text.Contains("Tạm vắng"))
                {
                    var lStudentTamVang = getAllSinhVienTamVangComtroller.getAllSinhVienTotNghiep();
                    if (lStudentTamVang != null)
                    {
                        dgvSinhVien.Rows.Clear();
                        foreach (var student in lStudentTamVang)
                        {

                            dgvSinhVien.Rows.Add(
                                student.maSV,
                                student.tenSv,
                                student.ngaySinh.ToString("yyyy/MM/dd"),
                                student.GioiTinh,
                                student.diaChi,
                                student.sdt,
                                student.danToc,
                                student.tonGiao,
                                student.email,
                                student.cccd,
                                student.noiSinh,
                                student.trangThai,
                                student.tenLop,
                                student.tenNganh,
                                student.tenKhoa
                            );
                        }
                    }
                }
            }
        }

        private void btnLuuFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Lưu danh sách sinh viên";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("DanhSachSinhVien");

                // Giả sử bạn có DataGridView dgvSinhVien
                for (int i = 0; i < dgvSinhVien.Columns.Count; i++)
                {
                    ws.Cell(1, i + 1).Value = dgvSinhVien.Columns[i].HeaderText;
                }

                for (int i = 0; i < dgvSinhVien.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvSinhVien.Columns.Count; j++)
                    {
                        ws.Cell(i + 2, j + 1).Value = dgvSinhVien.Rows[i].Cells[j].Value?.ToString() ?? "";
                    }
                }

                wb.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Lưu file thành công!");
            }
        }

        public void ShowTab(string tabName)
        {
            foreach (TabPage tab in tcMenuManager.TabPages)
            {
                if (tab.Name == tabName)
                {
                    tcMenuManager.SelectedTab = tab;
                    break;
                }
            }
        }

        private void cboOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cboOptions.SelectedItem?.ToString();

            // 1. Ẩn toàn bộ controls đầu vào
            txtMahs.Visible = false;
            lblMahs.Visible = false;
            txtmhs.Visible = false;
            lblmhs.Visible = false;
            txtmsv.Visible = false;
            txtMasv.Visible = false;
            lblMasv.Visible = false;
            lblmsv.Visible = false;
            cboTrangThai.Visible = false;

            // 2. Hiện đúng control theo lựa chọn
            switch (selected)
            {
                case "Tìm theo mã hs":
                    txtmhs.Visible = true;
                    lblmhs.Visible = true;
                    break;

                case "Tìm theo mã sv":
                    txtmsv.Visible = true;
                    lblmsv.Visible = true;
                    break;

                case "Tìm theo trạng thái":
                    cboTrangThai.Visible = true;
                    break;

                case "Tìm theo các tiêu chí":
                    txtMahs.Visible = true;
                    lblMahs.Visible = true;
                    txtMasv.Visible = true;
                    lblMasv.Visible = true;
                    cboTrangThai.Visible = true;
                    break;

                case "-- Lựa chọn --":
                default:
                    break;
            }
        }

        private void btnSuaHS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaHs) || string.IsNullOrWhiteSpace(selectedMaHs))
            {
                MessageBox.Show("Vui lòng chọn hồ sơ từ danh sách");
                return;
            }

            var suahs = new SuaHS(selectedMaHs, serviceProvider, editProfileController, hoSoController, this);
            this.Hide();
            suahs.ShowDialog();
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblmhs_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string luachon = cboOptions.SelectedItem?.ToString();

            var dto = new HoSoDto();
            dgvHoSoSv.Refresh();
            switch (luachon)
            {
                case "Tìm theo mã hs":
                    if (string.IsNullOrEmpty(txtmhs.Text) || string.IsNullOrWhiteSpace(txtmhs.Text)) { MessageBox.Show("Vui lòng nhập mã hồ sơ!"); return; }
                    var result = hoSoController.getHoSoByMaHS(txtmhs.Text);
                    if (result == null) { MessageBox.Show("Không tìm thấy hồ sơ có mã là " + txtmhs.Text + " này!"); dgvHoSoSv.DataSource = null; return; }
                    dgvHoSoSv.DataSource = new List<HoSoDto> { result };
                    break;

                case "Tìm theo mã sv":
                    if (string.IsNullOrEmpty(txtmsv.Text) || string.IsNullOrWhiteSpace(txtmsv.Text)) { MessageBox.Show("Vui lòng nhập mã sinh viên!"); return; }
                    var result2 = hoSoController.getHoSoByMaSV(txtmsv.Text);
                    if (result2 == null) { MessageBox.Show("Không tìm thấy hồ sơ có mã sinh viên là " + txtmsv.Text + " này!"); dgvHoSoSv.DataSource = null; return; }
                    dgvHoSoSv.DataSource = new List<HoSoDto> { result2 };
                    break;

                case "Tìm theo trạng thái":
                    if (cboTrangThai.SelectedItem?.ToString() == "Hoạt động")
                        dto.trangthaihoso = true;
                    else if (cboTrangThai.SelectedItem?.ToString() == "Không hoạt động")
                        dto.trangthaihoso = false;

                    var result3 = hoSoController.getHoSoByTrangThai(dto.trangthaihoso == true ? "Hoạt động" : "Không hoạt động");
                    if (result3 == null) { MessageBox.Show("Không tìm thấy hồ sơ có trạng thái này!"); dgvHoSoSv.DataSource = null; return; }
                    dgvHoSoSv.DataSource = result3;
                    break;

                case "Tìm theo các tiêu chí":
                    dto.mahs = txtMahs.Text.Trim();
                    dto.masv = txtMasv.Text.Trim();
                    if (cboTrangThai.SelectedItem?.ToString() == "Hoạt động")
                        dto.trangthaihoso = true;
                    else if (cboTrangThai.SelectedItem?.ToString() == "Không hoạt động")
                        dto.trangthaihoso = false;
                    var result4 = hoSoController.getHoSoTheoNhieuTieuChi(dto);
                    //if((string.IsNullOrEmpty(dto.mahs) && (string.IsNullOrWhiteSpace(dto.mahs))
                    //|| ((string.IsNullOrEmpty(dto.masv)) && (string.IsNullOrWhiteSpace(dto.masv)) && ((cboTrangThai.SelectedItem?.ToString() != "Hoạt động") || (cboTrangThai.SelectedItem?.ToString() != "Không hoạt động"))
                    //))){
                    //    MessageBox.Show("Không được để trống cả 3!");
                    //    dgvHoSoSv.DataSource = null;
                    //    return;
                    //}
                    List<string> tieuChi = new List<string>();
                    tieuChi.Add(txtMahs.Text);
                    tieuChi.Add(txtMasv.Text);
                    tieuChi.Add(cboTrangThai.SelectedItem.ToString());
                    dgvHoSoSv.DataSource = new List<HoSoDto> { result4 };
                    break;

                case "-- Lựa chọn --":
                default:
                    MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm.");
                    return;
            }
        }

        private void txtmhs_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtMahs_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHoSoSv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSuaSinhVien_Click(object sender, EventArgs e)
        {
            new ChiTietHoSo(selectedMaSv, selectedMaHs, chitietHSController, lopController, nganhControllers, khoaController, studentController, editDetailsProfileController, serviceProvider, this).ShowDialog();
            this.Hide();

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboFieldForSearchSinhVien.Text = "-- Lựa chọn --";
            cboSearchSinhVien.Text = "";
        }

        private void btnLamMoiNganh_Click(object sender, EventArgs e)
        {
            cbxTimKiemForNganh.Text = "";
        }

        private void btnRefreshTxtKhoa_Click(object sender, EventArgs e)
        {
            txtMaNganh.Text = "";
            txtTenNganh.Text = "";
            cbxDsKhoa.SelectedIndex = -1;
        }

        private void btnLamMoiKhoa_Click(object sender, EventArgs e)
        {
            cbxFieldSearchKhoa.Text = "-- Lựa chọn --";
            cbxTimKiemForKhoa.Text = "";
        }

        private void btnLamMoiLop_Click(object sender, EventArgs e)
        {
            cbxFieldSearchLop.Text = "-- Lựa chọn --";
            cbxTimKiemForLop.Text = "";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var loginFrm = serviceProvider.GetRequiredService<LoginFrm>();
            loginFrm.Show();
            this.Close();
        }
    }
}
