using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Repository.KhoaRepository
{
    public interface IKhoaRepository
    {
        public List<Khoa> getAll();
        public void AddNew(Khoa khoa);
        public Khoa GetByMa(String id);
    }
}
