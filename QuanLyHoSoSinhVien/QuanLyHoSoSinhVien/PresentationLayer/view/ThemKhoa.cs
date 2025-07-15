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
using QuanLyHoSoSinhVien.PresentationLayer.DTO.KhoaDTO;
using QuanLyHoSoSinhVien.view;

namespace QuanLyHoSoSinhVien.PresentationLayer.view
{
    public partial class ThemKhoa : Form
    {
        private IServiceProvider serviceProvider;
        IAddKhoaController addKhoaController;
        IKhoaController khoaQuey;
        ManagerServicesFacade managerServicesFacade;
        public ThemKhoa(ManagerServicesFacade managerServicesFacade, IServiceProvider serviceProvider, IKhoaController khoaQuey)
        {
            InitializeComponent();
            this.managerServicesFacade = managerServicesFacade;
            this.addKhoaController = managerServicesFacade.addKhoaController;
            this.serviceProvider = serviceProvider;
            this.khoaQuey = khoaQuey;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMaKhoa.Text == "" || txtTenKhoa.Text == "")
            {
                MessageBox.Show("Hãy nhập đủ thông tin");
            }
            else
            {
                if (khoaQuey.getByMa(txtMaKhoa.Text)!=null)
                {
                    MessageBox.Show("Đã tồn tại khoa này");
                }
                else
                {
                    AddKhoaDto newKhoa = new AddKhoaDto { Id = txtMaKhoa.Text, tenKhoa = txtTenKhoa.Text };
                    if (addKhoaController.addKhoa(newKhoa))
                    {
                        MessageBox.Show("Them thanh cong");
                        this.Hide();
                        var managerForm = serviceProvider.GetRequiredService<MenuManagement>();
                        managerForm.Show();
                    }
                    
                }
            }
        }
    }
}
