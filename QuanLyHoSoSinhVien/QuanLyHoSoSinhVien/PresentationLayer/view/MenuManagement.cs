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
using QuanLyHoSoSinhVien.PresentationLayer.view;

namespace QuanLyHoSoSinhVien.view
{
    public partial class MenuManagement : Form
    {
        private IServiceProvider serviceProvider;
        IStudentController studentController;
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
                    nganh = cbxNganhAtTPLop.SelectedItem.ToString()??""
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
    }
}
