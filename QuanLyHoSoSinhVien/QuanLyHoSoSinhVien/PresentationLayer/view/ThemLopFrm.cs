using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.KhoaControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.LopControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.NganhControl;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.KhoaDTO;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.LopDTO;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.NganhDTO;
using QuanLyHoSoSinhVien.view;

namespace QuanLyHoSoSinhVien.PresentationLayer.view
{
    public partial class ThemLopFrm : Form
    {
        INganhControllers nganhController;
        IAddLopController addlop;
        IServiceProvider serviceProvider;
        public ThemLopFrm(INganhControllers nganhController, IAddLopController addlop, IServiceProvider serviceProvider)
        {
            this.nganhController = nganhController ?? throw new ArgumentNullException(nameof(nganhController));
            this.addlop = addlop ?? throw new ArgumentNullException(nameof(addlop));
            InitializeComponent();
            AddItemToComboBox();
            this.serviceProvider = serviceProvider;
        }
        public void AddItemToComboBox()
        {
            try
            {
                List<NganhDto> lNganhDto = nganhController.getAllNganhWithFullInfor() ?? new List<NganhDto>();
                List<String> items = new List<string>();
                foreach (NganhDto n in lNganhDto)
                {
                    items.Add(n.tenNganh);
                }
                cbxNganh.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show("NganhController is null");
            }

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLop.Text) || string.IsNullOrEmpty(txtTenLop.Text) || cbxNganh.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (addlop.addLop(new AddLopDto
            {
                maLop = txtMaLop.Text,
                tenLop = txtTenLop.Text,
                tenNganh = cbxNganh.SelectedItem.ToString()
            }))
            {
                MessageBox.Show("Thêm lớp thành công");
                serviceProvider.GetRequiredService<MenuManagement>().Show();
                this.Hide();
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm lớp thất bại, vui lòng kiểm tra lại thông tin");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var menuManagement = serviceProvider.GetRequiredService<MenuManagement>();
            menuManagement.Show();
            this.Hide();
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            cbxNganh.SelectedIndex = -1; 
        }
    }
}
