using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Repository.NganhRepository
{
    public interface INganhRepository
    {
        public List<Nganh> getAll();
        public void addNganh(Nganh nganh);
        public void deleteNganh(string id);
        public void editNganh(Nganh nganhNew);
        public List<Nganh> getNganhForID(string id);
    }
}
