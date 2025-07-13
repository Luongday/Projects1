using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Entity
{
    public class Lop
    {
        [Key]
        public string? malop { get; set; }

        [ForeignKey("nganh")]
        public string? manganh { get; set; }

        [Required]
        [MaxLength(20)]
        public string? tenlop  { get; set;}

        [Required]
        public int siso { get; set;}

        public ICollection<SinhVien>? sinhViens { get; set;}
        public Nganh? nganh { get; set; }
    }
}
