using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Entity
{
    internal class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<HoSo> HoSos { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<Nganh> Nganhs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-ED6SANE\\SQLEXPRESS;Initial Catalog=QlHSSV;Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SinhVien>()
            .HasOne(sv => sv.HoSo)
            .WithOne(hs => hs.SinhVien)
            .HasForeignKey<HoSo>(hs => hs.masv)
            .OnDelete(DeleteBehavior.Cascade);

            // USER
            modelBuilder.Entity<User>().HasData(FakeDataService.GenerateUsers(100));

            // KHOA
            modelBuilder.Entity<Khoa>().HasData(FakeDataService.GenerateKhoas());

            // NGANH
            modelBuilder.Entity<Nganh>().HasData(FakeDataService.GenerateNganhs());

            // LOP
            modelBuilder.Entity<Lop>().HasData(FakeDataService.GenerateLops());

            // SINH VIEN
            modelBuilder.Entity<SinhVien>().HasData(FakeDataService.GenerateSinhViens());

            // HOSO 
            modelBuilder.Entity<HoSo>().HasData(FakeDataService.GenerateHoSos());
        }
    }
}