using Guna.UI2.WinForms;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;

namespace QuanLyHoSoSinhVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dgvHoSoSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        DataContext _context = new DataContext();
        private void Form1_Load(object sender, EventArgs e)
        {
            guna2ShadowPanel1.Enabled = true; // Bật tương tác
            guna2ShadowPanel1.Visible = true; // Hiển thị panel
            guna2ShadowPanel1.ShadowDepth = 20; // Độ sâu bóng (từ 1-10, càng cao càng đậm)
            guna2ShadowPanel1.ShadowColor = Color.DarkGray;
            guna2ShadowPanel1.Tag = guna2ShadowPanel1.Location;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_MouseEnter(object sender, EventArgs e)
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
                panel.ShadowColor = Color.Gray;
            }
        }

        private void guna2ShadowPanel1_MouseLeave(object sender, EventArgs e)
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
                panel.ShadowColor = Color.DarkGray;
            }
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
