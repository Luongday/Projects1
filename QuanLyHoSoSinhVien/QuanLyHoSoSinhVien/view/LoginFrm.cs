using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoSoSinhVien.view
{
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            tgShowHidePass.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void tgShowHidePass_Click(object sender, EventArgs e)
        {
            if(tgShowHidePass.IconChar == FontAwesome.Sharp.IconChar.EyeSlash)
            {
                tgShowHidePass.IconChar = FontAwesome.Sharp.IconChar.Eye;
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tgShowHidePass.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
