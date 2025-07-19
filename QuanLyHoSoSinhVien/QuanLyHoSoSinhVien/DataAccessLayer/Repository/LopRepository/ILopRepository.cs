using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Repository.LopRepository
{
    public interface ILopRepository
    {
        public List<Lop> getAll();
        public Lop getByMa(string id);
        public void addLop(Lop lop);
        public void deleteLop(Lop lop);
        public void editLop (Lop lop); 
    }
}
