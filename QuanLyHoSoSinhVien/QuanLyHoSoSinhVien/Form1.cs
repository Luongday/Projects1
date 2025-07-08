using QuanLyHoSoSinhVien.model;

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
            dataGridView1.DataSource = _context.SinhViens.ToList();
            dataGridView2.DataSource = _context.HoSos.ToList();
            dataGridView3.DataSource = _context.Lops.ToList();
            dataGridView4.DataSource = _context.Nganhs.ToList();
            dataGridView5.DataSource = _context.Khoas.ToList();
        }
    }
}
