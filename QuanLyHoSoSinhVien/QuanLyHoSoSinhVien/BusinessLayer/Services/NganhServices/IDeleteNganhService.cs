using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.BusinessLayer.Services.NganhServices
{
    public interface IDeleteNganhService
    {
        public bool deleteNganhWithId(string id); 
    }
}
