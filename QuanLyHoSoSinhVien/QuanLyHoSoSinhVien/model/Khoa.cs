using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.model
{
    public class Khoa
    {
        [Key]
        public string? makhoa {  get; set; }

        public string? tenkhoa { get; set; }

        public ICollection<Nganh>? Nganh { get; set; }
    }
}

