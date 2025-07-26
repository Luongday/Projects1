using Moq;
using QuanLyHoSoSinhVien.BusinessLayer.Services.LopServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.LopRepository;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace QuanLyHoSoSinhVien.Tests
{
    public class LopQueryServicesTests
    {
        [Fact]
        public void GetAll_WhenDataExists_ReturnsList()
        {
            // Arrange
            var mockLopRepo = new Mock<ILopRepository>();
            mockLopRepo.Setup(repo => repo.getAll()).Returns(new List<Lop>
            {
                new Lop { malop = "L01", tenlop = "CNTT21-01", manganh = "NG01" }
            });
            var service = new LopQueryIServicempl(mockLopRepo.Object);

            // Act
            var result = service.getAll();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("CNTT21-01", result[0].tenlop);
        }

        [Fact]
        public void GetLopWithMa_ValidMa_ReturnsLop()
        {
            // Arrange
            var mockLopRepo = new Mock<ILopRepository>();
            mockLopRepo.Setup(repo => repo.getByMa("L01")).Returns(new Lop { malop = "L01", tenlop = "CNTT21-01" });
            var service = new LopQueryIServicempl(mockLopRepo.Object);

            // Act
            var result = service.getLopWithMa("L01");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("L01", result.malop);
            Assert.Equal("CNTT21-01", result.tenlop);
        }

        [Fact]
        public void GetLopWithMa_NullMa_ReturnsEmptyLop()
        {
            // Arrange
            var mockLopRepo = new Mock<ILopRepository>();
            var service = new LopQueryIServicempl(mockLopRepo.Object);

            // Act
            var result = service.getLopWithMa(null);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.malop);
        }

        [Fact]
        public void GetLopWithTen_ValidName_ReturnsList()
        {
            // Arrange
            var mockLopRepo = new Mock<ILopRepository>();
            mockLopRepo.Setup(repo => repo.getAll()).Returns(new List<Lop>
            {
                new Lop { malop = "L01", tenlop = "CNTT21-01" }
            });
            var service = new LopQueryIServicempl(mockLopRepo.Object);

            // Act
            var result = service.getLopWithTen("CNTT21-01");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("CNTT21-01", result[0].tenlop);
        }

        [Fact]
        public void GetLopForNganh_ValidNganh_ReturnsList()
        {
            // Arrange
            var mockLopRepo = new Mock<ILopRepository>();
            mockLopRepo.Setup(repo => repo.getAll()).Returns(new List<Lop>
            {
                new Lop { malop = "L01", tenlop = "CNTT21-01", nganh = new Nganh { tennganh = "Khoa học máy tính" } }
            });
            var service = new LopQueryIServicempl(mockLopRepo.Object);

            // Act
            var result = service.getLopForNganh("Khoa học máy tính");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("CNTT21-01", result[0].tenlop);
        }
    }
}