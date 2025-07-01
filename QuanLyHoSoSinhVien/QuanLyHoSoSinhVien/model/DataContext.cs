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
        public DbSet<User> Users { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<HoSo>  HoSos{ get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<Nganh> Nganhs { get; set; }


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
            modelBuilder.Entity<Nganh>().HasData(

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
