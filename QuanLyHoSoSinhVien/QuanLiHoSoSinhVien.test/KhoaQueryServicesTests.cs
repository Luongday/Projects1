using Moq;
using QuanLyHoSoSinhVien.BusinessLayer.Services.KhoaServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.KhoaRepository;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace QuanLyHoSoSinhVien.Tests
{
    public class KhoaQueryServicesTests
    {
        [Fact]
        public void GetAll_WhenDataExists_ReturnsList()
        {
            // Arrange
            //Tạo dữ liệu giả gồm 2 khoa
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            mockKhoaRepo.Setup(repo => repo.getAll()).Returns(new List<Khoa>
            {
                new Khoa { makhoa = "CNTT", tenkhoa = "Công nghệ Thông tin" },
                new Khoa { makhoa = "KT", tenkhoa = "Kinh tế" }
            });
            var service = new KhoaQueryServicesImpl(mockKhoaRepo.Object);

            // Act
            var result = service.getAll();

            // Assert
            //Kết quả mong muốn la  danh sách khoa không null và có 2 phần tử
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            //Kiểm tra tên khoa của phần tử đầu tiên mong muốn là "Công nghệ Thông tin"
            Assert.Equal("Công nghệ Thông tin", result[0].tenkhoa);
        }

        [Fact]
        public void GetAll_WhenNoData_ReturnsEmptyList()
        {
            // Arrange
            //Responsitory trả về null hoặc danh sách rỗng
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            mockKhoaRepo.Setup(repo => repo.getAll()).Returns((List<Khoa>)null);
            var service = new KhoaQueryServicesImpl(mockKhoaRepo.Object);

            // Act
            var result = service.getAll();

            // Assert
            //Kết quả mong muốn là danh sách khoa không null và rỗng
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetById_ValidId_ReturnsKhoa()
        {
            // Arrange
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            mockKhoaRepo.Setup(repo => repo.GetByMa("CNTT")).Returns(new Khoa { makhoa = "CNTT", tenkhoa = "Công nghệ Thông tin" });
            var service = new KhoaQueryServicesImpl(mockKhoaRepo.Object);

            // Act
            var result = service.GetById("CNTT");

            // Assert
            //Kết quả mong muốn là khoa không null và có mã khoa là "CNTT" và tên khoa là "Công nghệ Thông tin"
            Assert.NotNull(result);
            Assert.Equal("CNTT", result.makhoa);
            Assert.Equal("Công nghệ Thông tin", result.tenkhoa);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GetById_InValidId_ReturnsEmptyKhoa(string id)
        {
            // Arrange
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            var service = new KhoaQueryServicesImpl(mockKhoaRepo.Object);

            // Act
            var result = service.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.makhoa);
            Assert.Null(result.tenkhoa);
        }

        [Fact]
        public void GetKhoaForName_ValidName_ReturnsList()
        {
            // Arrange
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            mockKhoaRepo.Setup(repo => repo.getAll()).Returns(new List<Khoa>
            {
                new Khoa { makhoa = "CNTT", tenkhoa = "Công nghệ Thông tin" }
            });
            var service = new KhoaQueryServicesImpl(mockKhoaRepo.Object);

            // Act
            var result = service.getKhoaForName("Công nghệ Thông tin");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Công nghệ Thông tin", result[0].tenkhoa);
        }

        [Fact]
        public void GetKhoaForName_EmptyName_ReturnsEmptyList()
        {
            // Arrange
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            var service = new KhoaQueryServicesImpl(mockKhoaRepo.Object);

            // Act
            var result = service.getKhoaForName("");

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}