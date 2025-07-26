using Moq;
using QuanLyHoSoSinhVien.BusinessLayer.Services.NganhServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.NganhRepository;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace QuanLyHoSoSinhVien.Tests
{
    public class NganhQueryServicesTests
    {
        [Fact]
        public void GetAll_WhenDataExists_ReturnsList()
        {
            // Arrange
            var mockNganhRepo = new Mock<INganhRepository>();
            mockNganhRepo.Setup(repo => repo.getAll()).Returns(new List<Nganh>
            {
                new Nganh { manganh = "NG01", tennganh = "Khoa học máy tính" }
            });
            var service = new NganhQueryServiceImpl(mockNganhRepo.Object);

            // Act
            var result = service.getAll();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Khoa học máy tính", result[0].tennganh);
        }

        [Fact]
        public void GetNganhForId_ValidId_ReturnsList()
        {
            // Arrange
            var mockNganhRepo = new Mock<INganhRepository>();
            mockNganhRepo.Setup(repo => repo.getNganhForID("NG01")).Returns(new List<Nganh>
            {
                new Nganh { manganh = "NG01", tennganh = "Khoa học máy tính" }
            });
            var service = new NganhQueryServiceImpl(mockNganhRepo.Object);

            // Act
            var result = service.getNganhForId("NG01");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Khoa học máy tính", result[0].tennganh);
        }

        [Fact]
        public void GetNganhForId_EmptyId_ReturnsEmptyList()
        {
            // Arrange
            var mockNganhRepo = new Mock<INganhRepository>();
            mockNganhRepo.Setup(repo => repo.getNganhForID(It.IsAny<string>())).Returns(new List<Nganh>());
            var service = new NganhQueryServiceImpl(mockNganhRepo.Object);

            // Act
            var result = service.getNganhForId("");

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetNganhForKhoa_ValidKhoa_ReturnsList()
        {
            // Arrange
            var mockNganhRepo = new Mock<INganhRepository>();
            mockNganhRepo.Setup(repo => repo.getAll()).Returns(new List<Nganh>
            {
                new Nganh { manganh = "NG01", tennganh = "Khoa học máy tính", Khoa = new Khoa { tenkhoa = "Công nghệ Thông tin" } }
            });
            var service = new NganhQueryServiceImpl(mockNganhRepo.Object);

            // Act
            var result = service.getNganhForKhoa("Công nghệ Thông tin");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Khoa học máy tính", result[0].tennganh);
        }

        [Fact]
        public void GetNganhForName_ValidName_ReturnsList()
        {
            // Arrange
            var mockNganhRepo = new Mock<INganhRepository>();
            mockNganhRepo.Setup(repo => repo.getAll()).Returns(new List<Nganh>
            {
                new Nganh { manganh = "NG01", tennganh = "Khoa học máy tính" }
            });
            var service = new NganhQueryServiceImpl(mockNganhRepo.Object);

            // Act
            var result = service.getNganhForName("Khoa học máy tính");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Khoa học máy tính", result[0].tennganh);
        }

        [Fact]
        public void GetNganhForName_EmptyName_ReturnsEmptyList()
        {
            // Arrange
            var mockNganhRepo = new Mock<INganhRepository>();
            var service = new NganhQueryServiceImpl(mockNganhRepo.Object);

            // Act
            var result = service.getNganhForName("");

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}