using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.KhoaServices
{
    public interface IDeleteKhoaService
    {
        bool deleteKhoaById(string id);
    }
}
