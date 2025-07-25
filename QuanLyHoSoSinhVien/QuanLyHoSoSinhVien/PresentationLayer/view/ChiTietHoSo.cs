using Microsoft.Extensions.DependencyInjection;
using QuanLyHoSoSinhVien.BusinessLayer.Services.DetailsProefileServices;
using QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.DetailsProfileRepository;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.DetailsProfileController;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.KhoaControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.LopControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.NganhControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.StudentControl;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.DetailsProfileDTO;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDto;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.KhoaDTO;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.LopDTO;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.NganhDTO;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.StudentDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoSoSinhVien.view
{
    public partial class ChiTietHoSo : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private string _maSv;
        private string _maHs;
        private readonly IDetailsProfileController _controller;
        private readonly INganhControllers _nganhControllers;
        private readonly IEditDetailsProfileController _editDetailsProfileController;
        private readonly ILopController _lopController;
        private readonly IKhoaController _khoaController;
        private readonly IStudentController _studentController;
        private readonly MenuManagement _menuForm;
        public ChiTietHoSo(string masv, string mahs, IDetailsProfileController controller, ILopController lopController, INganhControllers nganhControllers, IKhoaController khoaController, IStudentController studentController, IEditDetailsProfileController editDetailsProfileController, IServiceProvider serviceProvider, MenuManagement menuForm)
        {
            InitializeComponent();
            _maHs = mahs;
            _maSv = masv;
            _lopController = lopController;
            _nganhControllers = nganhControllers;
            _khoaController = khoaController;
            _studentController = studentController;
            _editDetailsProfileController = editDetailsProfileController;
            _serviceProvider = serviceProvider;
            _controller = controller;
            this._menuForm = menuForm;
        }

        DetailsProfileDto _dto;
        private void LoadChiTietHoSo()
        {
            var Dto = _controller.takeAStudentWithFullInfor(_maSv);
            if (Dto == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên.");
                return;
            }

            txtName.Text = Dto.tenSv;
            txtAddress.Text = Dto.diaChi;
            txtDanToc.Text = Dto.danToc;
            txtTonGiao.Text = Dto.tonGiao;
            txtQueQuan.Text = Dto.noiSinh;
            txtMSV.Text = Dto.maSV;
            txtCCCD.Text = Dto.cccd;
            txtEmail.Text = Dto.email;
            txtSDT.Text = Dto.sdt;
            txtMaHoSo.Text = _maHs;
            dtpDateTme.Value = Dto.ngaySinh;
            if (cboSex.Items.Contains(Dto.GioiTinh))
            {
                cboSex.SelectedItem = Dto.GioiTinh;
            }

            if (cboTT.Items.Contains(Dto.trangThai))
            {
                cboTT.SelectedItem = Dto.trangThai;
            }
            AddNganhToComboBox();
            addLopToCombobox();
            addKhoaToCombobox();

            if (cboLop.Items.Contains(Dto.tenLop))
            {
                cboLop.SelectedItem = Dto.tenLop;
            }

            if (cboNganh.Items.Contains(Dto.tenNganh))
            {
                cboNganh.SelectedItem = Dto.tenNganh;
            }

            if (cboKhoa.Items.Contains(Dto.tenKhoa))
            {
                cboKhoa.SelectedItem = Dto.tenKhoa;
            }
            _dto = Dto;
        }


        public void AddNganhToComboBox()
        {
            try
            {
                List<NganhDto> lNganhDto = _nganhControllers.getAllNganhWithFullInfor() ?? new List<NganhDto>();
                cboNganh.DataSource = null;
                cboNganh.Items.Clear();
                cboNganh.DataSource = lNganhDto.Select(ng => ng.tenNganh).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NganhController is null");
            }
        }

        public void addKhoaToCombobox()
        {
            try
            {
                List<KhoaDto> lKhoaDto = _khoaController.getAllKhoaWithFullInfor() ?? new List<KhoaDto>();
                cboKhoa.DataSource = null;
                cboKhoa.Items.Clear();
                cboKhoa.DataSource = lKhoaDto.Select(kh => kh.tenKhoa).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NganhController is null");
            }
        }

        public void addLopToCombobox()
        {
            try
            {
                List<LopDto> lLopDto = _lopController.getAllLopWithFullInfor() ?? new List<LopDto>();
                cboLop.DataSource = null;
                cboLop.Items.Clear();
                cboLop.DataSource = lLopDto.Select(l => l.tenLop).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NganhController is null");
            }
        }

        DetailsProfileDto _detailsProfileDto;

        private void ChiTietHoSo_Load(object sender, EventArgs e)
        {
            LoadChiTietHoSo();
            var tmp = _controller.takeAStudentWithFullInfor(_maSv);
            if (tmp == null)
            {
                MessageBox.Show("Dữ liệu lỗi hoặc không tồn tại!");
            }
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DetailsProfileDto _DetailsProfileDto = new DetailsProfileDto
            {
                maSV = txtMSV.Text,
                tenSv = txtName.Text,
                ngaySinh = dtpDateTme.Value,
                GioiTinh = cboSex?.SelectedItem!.ToString(),
                diaChi = txtAddress.Text,
                danToc = txtDanToc.Text,
                tonGiao = txtTonGiao.Text,
                noiSinh = txtQueQuan.Text,
                cccd = txtCCCD.Text,
                email = txtEmail.Text,
                sdt = txtSDT.Text,
                trangThai = cboTT?.SelectedItem!.ToString(),
                tenLop = cboLop?.SelectedItem!.ToString(),
                tenNganh = cboNganh?.SelectedItem!.ToString(),
                tenKhoa = cboKhoa?.SelectedItem!.ToString(),
            };
            var tmp = _editDetailsProfileController.EditDetailsProfile(_DetailsProfileDto);
            if (tmp != null)
            {
                MessageBox.Show(tmp);
                var hehe = _serviceProvider.GetRequiredService<MenuManagement>();
                hehe.Show();
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show(tmp);
                return;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _menuForm.Show();
            _menuForm.ShowTab("tpQuanLiHoSo");
            this.Close();
        }
     
      
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (_dto == null) return;
            txtName.Text = _dto.tenSv;
            dtpDateTme.Value = _dto.ngaySinh;
            cboSex.SelectedItem = _dto.GioiTinh;
            txtAddress.Text = _dto.diaChi;
            txtDanToc.Text = _dto.danToc;
            txtTonGiao.Text = _dto.tonGiao;
            txtEmail.Text = _dto.email;
            txtSDT.Text = _dto.sdt;
            txtCCCD.Text = _dto.cccd;
            txtQueQuan.Text = _dto.noiSinh;
            cboTT.SelectedItem = _dto.trangThai;
            cboLop.SelectedItem = _dto.tenLop;
            cboNganh.SelectedItem = _dto.tenNganh;
            cboKhoa.SelectedItem = _dto.tenKhoa;
        }
    }
}
