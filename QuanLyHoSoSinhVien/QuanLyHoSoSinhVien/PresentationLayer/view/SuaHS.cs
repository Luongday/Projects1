using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.DependencyInjection;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.HoSoController;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.HoSoDto;
using QuanLyHoSoSinhVien.view;
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

namespace QuanLyHoSoSinhVien.PresentationLayer.view
{
    public partial class SuaHS : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private string _maHs;
        private readonly IEditProfileController _editProfileController;
        private readonly IProfileController _hoSoController;
        private readonly MenuManagement _menuForm;
        public SuaHS(string mahs, IServiceProvider serviceProvider, IEditProfileController editProfileController, IProfileController hoSoController, MenuManagement menuManagement)
        {
            InitializeComponent();
            this._maHs = mahs;
            this._serviceProvider = serviceProvider;
            this._editProfileController = editProfileController;
            this._hoSoController = hoSoController;
            this._menuForm = menuManagement;
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
        HoSoDto _hoSoDto;
        private void SuaHS_Load(object sender, EventArgs e)
        {
            var tmp = _hoSoController.getHoSoByMaHS(_maHs);
            if (tmp == null)
            {
                MessageBox.Show("Dữ liệu lỗi hoặc không tồn tại!");
            }

            txtmahs.Text = tmp?.mahs;
            txtmasv.Text = tmp?.masv;
            dtpNgayTao.Value = tmp.ngaytao!.Value;
            dtpNgayCapNhat.Value = tmp.ngaycapnhat!.Value;
            string s = tmp.trangthaihoso == true ? "Hoạt động" : "Không hoạt động";
            if (cboTrangThai.Items.Contains(s))
            {
                cboTrangThai.SelectedItem = s;
            }
            _hoSoDto = new HoSoDto
            {
                ngaycapnhat = dtpNgayCapNhat.Value,
                trangthaihoso = s == "Hoạt động" ? true : false
            };
            btnCancel.Enabled = false; // chưa có thay đổi thì disable
        }

        private bool IsDataChanged()
        {
            if (_hoSoDto == null || !_hoSoDto.ngaycapnhat.HasValue)
                return false;
            string trangThaiForm = cboTrangThai.SelectedItem?.ToString() ?? "";
            string trangThaiDto = _hoSoDto.trangthaihoso == true ? "Hoạt động" : "Không hoạt động";
            return dtpNgayCapNhat.Value != _hoSoDto.ngaycapnhat.Value || trangThaiForm != trangThaiDto;
        }
        private bool isLoading = false;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            isLoading = true;
            dtpNgayCapNhat.Value = _hoSoDto.ngaycapnhat!.Value;
            cboTrangThai.SelectedItem = _hoSoDto.trangthaihoso == true ? "Hoạt động" : "Không hoạt động";
            isLoading = false;
            btnCancel.Enabled = false; // chưa có thay đổi thì disable
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading)
                btnCancel.Enabled = IsDataChanged();
        }

        private void dtpNgayCapNhat_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
                btnCancel.Enabled = IsDataChanged();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _menuForm.Show();
            _menuForm.ShowTab("tpQuanLiHoSo");
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HoSoDto hoSoDto = new HoSoDto
            {
                mahs = txtmahs.Text,
                masv = txtmasv.Text,
                ngaytao = dtpNgayTao.Value,
                ngaycapnhat = dtpNgayCapNhat.Value,
                trangthaihoso = cboTrangThai.SelectedItem.ToString() == "Hoạt động" ? true : false
            };
            var tmp = _editProfileController.EditProfile(hoSoDto);

            if(tmp != null)
            {
                MessageBox.Show(tmp);
                _menuForm.Show();
                _menuForm.ShowTab("tpQuanLiHoSo");
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show(tmp);
            }

        }
    }
}
