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
using System.Windows.Forms.DataVisualization.Charting;
using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.DependencyInjection;
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
        IProfileController hoSoController;
        private readonly IDetailsProfileController chitietHSController;
        IDeleteKhoaController deleteKhoaController;
        IEditKhoaController editKhoaController;
        IEditProfileController editProfileController;
        IDeleteProfileController deleteProfileController;
        ManagerServicesFacade managerServicesFacade;

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


            var danhSach = getAllSinhVienTamVangComtroller.getAllSinhVienTamVang();
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
            dgvHoSoSv.Rows.Clear();
            dgvHoSoSv.Refresh();
            var hoso = hoSoController.getAllHoSo();
            foreach (var ho in hoso)
            {
                dgvHoSoSv.Rows.Add(
                ho.mahs,
                ho.masv,
                ho.ngaytao,
                ho.ngaycapnhat,
                ho.TrangThaiText
                );
            }

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
            if (string.IsNullOrWhiteSpace(selectedMaSv) || string.IsNullOrWhiteSpace(selectedMaHs))
            {
                MessageBox.Show("Vui lòng chọn hồ sơ sinh viên từ danh sách!");
                return;
            }
            var chiTietHoSo = new ChiTietHoSo(selectedMaSv, selectedMaHs, chitietHSController);
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
            if(tcMenuManager.SelectedTab == tpBaoCaoThongKe)
            {
                lblToTalSinhVienDangHoc.Text = studentController.totalStudentDangHoc().ToString();
                lblTotalSinVienTamVang.Text = studentController.totalStudentTamVang().ToString();
                LoadChartThongKe(studentController.totalStudentDangHoc(), studentController.totalStudentTamVang());
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
                selectedMaHs = row.Cells["mahs"].Value?.ToString();
                selectedMaSv = row.Cells["masv"].Value?.ToString();
                hoSoDto = new HoSoDto
                {
                    mahs = row.Cells["mahs"].Value?.ToString() ?? "a",
                    masv = row.Cells["masv"].Value?.ToString() ?? "b",
                    ngaycapnhat = DateTime.Parse(row.Cells["ngayct"].Value?.ToString() ?? "2000/1/1"),
                    trangthaihoso = row.Cells["tt"].Value?.ToString() == "Không hoạt động" ? false : true
                };

            }
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(selectedMaHs) == null)
            {
                MessageBox.Show("!");
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
                    maLop = txtMaLop.Text,
                    tenLop = txtTenLop.Text,
                    nganh = cbxNganhAtTPLop.SelectedItem.ToString() ?? ""
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
            if (comboBox1.SelectedIndex == 0)
            {
                AddMaNganhToComboBox(cbxTimKiemForNganh);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                AddNganhToComboBox(cbxTimKiemForNganh);
            }
            else if (comboBox1.SelectedIndex == 2)
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
            if (comboBox3.SelectedIndex == 0)
            {
                addMaKhoaToCombobox(cbxTimKiemForKhoa);
            }
            else if (comboBox3.SelectedIndex == 1)
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
            if (comboBox5.SelectedIndex == 0)
            {
                addMaLopToCombobox(cbxTimKiemForLop);
            }
            else if (comboBox5.SelectedIndex == 1)
            {
                addLopToCombobox(cbxTimKiemForLop);
            }
            else if (comboBox5.SelectedIndex == 2)
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
                panel.ShadowDepth = 100;
                panel.ShadowShift = 15;
                panel.ShadowColor = Color.Gray;
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
                panel.ShadowDepth = 20;
                panel.ShadowShift = 15;
                panel.ShadowColor = Color.DarkGray;

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
                panel.ShadowDepth = 100;
                panel.ShadowShift = 15;
                panel.ShadowColor = Color.Gray;

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
                panel.ShadowDepth = 20;
                panel.ShadowShift = 15;
                panel.ShadowColor = Color.DarkGray;

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
    }
}
