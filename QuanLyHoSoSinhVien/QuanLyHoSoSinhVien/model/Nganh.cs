using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.model
{
    public class Nganh
    {
        [Key]
        public string? manghanh {  get; set; }

        public string? tennganh { get; set; }

        [ForeignKey("Khoa")]
        public string? makhoa {  get; set; }

        public Khoa? Khoa { get; set; }

        public ICollection<Lop>? Lop { get; set; }
    }
}
