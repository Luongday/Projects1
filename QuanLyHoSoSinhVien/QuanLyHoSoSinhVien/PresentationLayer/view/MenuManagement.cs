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
using Microsoft.Extensions.DependencyInjection;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.PresentationLayer;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.HoSoController;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.KhoaControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.LopControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.NganhControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.StudentControl;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.KhoaDTO;
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
        IKhoaController khoaController;
        IHoSoController hoSoController;
        IDeleteKhoaController deleteKhoaController;
        IEditKhoaController editKhoaController;
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
            dgvKhoa.Refresh();
        }

        private void LoadHoSo()
        {
            var hoso = hoSoController.getAllHoSo();
            foreach (var ho in hoso)
            {
                dgvHoSoSv.Rows.Add(
                ho.mahs,
                ho.masv,
                ho.ngaytao,
                ho.ngaycapnhat,
                ho.trangthaihoso
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

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new view.ChiTietHoSo().Show();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoSoSv.Rows[e.RowIndex];

                string? s = row.Cells[1].Value?.ToString();

                if (s == null)
                {
                    MessageBox.Show("Không có thông tin sinh viên với mã này!");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hồ sơ!");
                return;
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
    }
}
