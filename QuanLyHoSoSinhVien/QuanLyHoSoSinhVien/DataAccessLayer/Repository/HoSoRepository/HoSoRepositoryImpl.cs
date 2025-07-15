using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Repository.HoSoRepository
{
    internal class HoSoRepositoryImpl : IHoSoRepository
    {
        DataContext _context = new DataContext();
        public List<HoSo> getAllHoSo()
        {
            List<HoSo> list = _context.HoSos.ToList();

            return list;
        }
    }
}
