using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;
using Microsoft.Extensions.DependencyInjection;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.KhoaControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.NganhControl;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.KhoaDTO;
using QuanLyHoSoSinhVien.view;

namespace QuanLyHoSoSinhVien.PresentationLayer.view
{
    public partial class ThemNganhFrm : Form
    {
        IKhoaController khoaController;
        IAddNganhController addNganhController;
        IServiceProvider serviceProvider;
        public ThemNganhFrm(IKhoaController khoaController, IAddNganhController addNganhController, IServiceProvider serviceProvider)
        {
            this.khoaController = khoaController ?? throw new ArgumentNullException(nameof(khoaController));
            this.addNganhController = addNganhController ?? throw new ArgumentNullException(nameof(addNganhController));
            InitializeComponent();
            AddItemToComboBox();
            this.serviceProvider = serviceProvider;
        }
        public void AddItemToComboBox()
        {
            try
            {
                List<KhoaDto> khoaDto = khoaController.getAllKhoaWithFullInfor() ?? new List<KhoaDto>();
                List<String> items = new List<string>();
                foreach (KhoaDto k in khoaDto)
                {
                    items.Add(k.tenKhoa);
                }
                cbxKhoa.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show("khoaController is null");
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNganh.Text) || string.IsNullOrEmpty(txtTenNganh.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else { 
                if(addNganhController.addNewNganh(new DTO.NganhDTO.AddNganhDto
                {
                    maNganh = txtMaNganh.Text,
                    tenNganh = txtTenNganh.Text,
                    tenKhoa = cbxKhoa.SelectedItem.ToString()
                }))
                {
                    MessageBox.Show("Thêm ngành thành công");
                    var menu = serviceProvider.GetRequiredService<MenuManagement>();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Thêm ngành thất bại, vui lòng kiểm tra lại thông tin");
                }
            }
        }
    }
}
