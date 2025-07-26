using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using QuanLyHoSoSinhVien.PresentationLayer;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.KhoaControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.LopControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.NganhControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.StudentControl;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.KhoaDTO;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.LopDTO;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.NganhDTO;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.StudentDTO;

namespace QuanLyHoSoSinhVien.view
{
    public partial class ThemSV : Form
    {
        IAddStudentController _addStudentController;
        IServiceProvider _serviceProvider;
        INganhControllers nganhControllers;
        ILopController lopController;
        IKhoaController khoaController;
        ManagerServicesFacade _managerServicesFacade;
        public ThemSV(ManagerServicesFacade managerServicesFacade, IServiceProvider _serviceProvider)
        {
            this._managerServicesFacade = managerServicesFacade;
            this._addStudentController = managerServicesFacade.addStudentController;
            this._serviceProvider = _serviceProvider;
            this.nganhControllers = managerServicesFacade.nganhControllers;
            this.lopController = managerServicesFacade.lopController;
            this.khoaController = managerServicesFacade.KhoaController;
            InitializeComponent();
            addKhoaToCombobox(cbxKhoa);
            AddNganhToComboBox(cbxNganh);
            addLopToCombobox(cbxLop);
        }
        private bool IsValidEmail(string email)
        {
            var emailAttr = new EmailAddressAttribute();
            return emailAttr.IsValid(email);
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
        private void btnThemSV_Click(object sender, EventArgs e)
        {
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) || string.IsNullOrWhiteSpace(txtTenSV.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(cbxLop.Text) ||
                txtMaSV.TextLength > 20 || txtTenSV.TextLength > 20 || txtEmail.TextLength > 20)
            {
                MessageBox.Show("Vui lòng kiểm tra thông tin sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (dtpNgaySinh.Value > DateTime.Now)
                {
                    MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng chọn lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var result = _addStudentController.addStudent(new StudentDto
                {
                    maSV = txtMaSV.Text,
                    tenSv = txtTenSV.Text,
                    email = txtEmail.Text,
                    tenLop = cbxLop.Text,
                    sdt = txtSoDt.Text??"",
                    diaChi = txtDiaChi.Text??"",
                    danToc = txtDanToc.Text??"",
                    tonGiao = txtTonGiao.Text??"",
                    cccd = txtCCCD.Text ?? "",
                    noiSinh = txtNoiSinh.Text ?? "",
                    ngaySinh = dtpNgaySinh.Value,
                    GioiTinh = cbxGioiTinh.Text ?? "",
                    trangThai = cbxTrangThai.Text ?? ""
                });
                if (result)
                {
                    MessageBox.Show("Thêm sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var menuStudent = _serviceProvider.GetRequiredService<MenuManagement>();
                    menuStudent.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm sinh viên thất bại. Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn quay trở lại menu và hủy mọi thay đổi?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var menuStudent = _serviceProvider.GetRequiredService<MenuManagement>();
                menuStudent.Show();
                this.Close();
            }
        }
    }
}
