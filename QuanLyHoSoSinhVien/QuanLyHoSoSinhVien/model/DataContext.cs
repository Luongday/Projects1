using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.model
{
    internal class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=LAP-TOP-VIP-PRO;Initial Catalog=QuanLyHoSoSinhVien;Integrated Security=True;Trust Server Certificate=True;Encrypt=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);
             modelBuilder.Entity<SinhVien>().HasData(

             );

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Lop>().HasData(

            );

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Khoa>().HasData(

            );

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Nghanh>().HasData(

            );

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HoSo>().HasData(

            );

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(

            );
        }
    }
}
