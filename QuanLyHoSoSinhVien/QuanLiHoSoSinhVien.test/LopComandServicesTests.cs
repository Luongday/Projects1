using Moq;
using QuanLyHoSoSinhVien.BusinessLayer.Services.LopServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.LopRepository;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.NganhRepository;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.LopDTO;
using System.Collections.Generic;
using Xunit;

namespace QuanLyHoSoSinhVien.Tests
{
    public class LopComandServicesTests
    {
        [Fact]
        public void AddNewLop_ValidInput_ReturnsTrue()
        {
            // Arrange
            var mockLopRepo = new Mock<ILopRepository>();
            var mockNganhRepo = new Mock<INganhRepository>();
            mockLopRepo.Setup(repo => repo.getByMa(It.IsAny<string>())).Returns((Lop)null);
            mockNganhRepo.Setup(repo => repo.getAll()).Returns(new List<Nganh> { new Nganh { manganh = "NG01", tennganh = "Khoa học máy tính" } });
            var service = new LopComandServiceImpl(mockLopRepo.Object, mockNganhRepo.Object);
            var lopDto = new AddLopDto { maLop = "L01", tenLop = "CNTT21-01", tenNganh = "Khoa học máy tính" };

            // Act
            var result = service.addNewLop(lopDto);

            // Assert
            Assert.True(result);
            mockLopRepo.Verify(repo => repo.addLop(It.IsAny<Lop>()), Times.Once());
        }

        [Fact]
        public void AddNewLop_LopExists_ReturnsFalse()
        {
            // Arrange
            var mockLopRepo = new Mock<ILopRepository>();
            var mockNganhRepo = new Mock<INganhRepository>();
            mockLopRepo.Setup(repo => repo.getByMa("L01")).Returns(new Lop { malop = "L01" });
            var service = new LopComandServiceImpl(mockLopRepo.Object, mockNganhRepo.Object);
            var lopDto = new AddLopDto { maLop = "L01", tenLop = "CNTT21-01", tenNganh = "Khoa học máy tính" };

            // Act
            var result = service.addNewLop(lopDto);

            // Assert
            Assert.False(result);
            mockLopRepo.Verify(repo => repo.addLop(It.IsAny<Lop>()), Times.Never());
        }

        [Fact]
        public void DeleteLop_ValidId_ReturnsTrue()
        {
            // Arrange
            var mockLopRepo = new Mock<ILopRepository>();
            var mockNganhRepo = new Mock<INganhRepository>();
            mockLopRepo.Setup(repo => repo.getByMa("L01")).Returns(new Lop { malop = "L01" });
            mockLopRepo.Setup(repo => repo.deleteLop(It.IsAny<Lop>()));
            var service = new LopComandServiceImpl(mockLopRepo.Object, mockNganhRepo.Object);

            // Act
            var result = service.deleteLop("L01");

            // Assert
            Assert.True(result);
            mockLopRepo.Verify(repo => repo.deleteLop(It.IsAny<Lop>()), Times.Once());
        }

        [Fact]
        public void DeleteLop_InvalidId_ReturnsFalse()
        {
            // Arrange
            var mockLopRepo = new Mock<ILopRepository>();
            var mockNganhRepo = new Mock<INganhRepository>();
            mockLopRepo.Setup(repo => repo.getByMa(It.IsAny<string>())).Returns((Lop)null);
            var service = new LopComandServiceImpl(mockLopRepo.Object, mockNganhRepo.Object);

            // Act
            var result = service.deleteLop("L01");

            // Assert
            Assert.False(result);
            mockLopRepo.Verify(repo => repo.deleteLop(It.IsAny<Lop>()), Times.Never());
        }

        [Fact]
        public void EditLop_ValidInput_ReturnsTrue()
        {
            // Arrange
            var mockLopRepo = new Mock<ILopRepository>();
            var mockNganhRepo = new Mock<INganhRepository>();
            mockLopRepo.Setup(repo => repo.getByMa("L01")).Returns(new Lop { malop = "L01" });
            mockNganhRepo.Setup(repo => repo.getAll()).Returns(new List<Nganh> { new Nganh { manganh = "NG01", tennganh = "Khoa học máy tính" } });
            mockLopRepo.Setup(repo => repo.editLop(It.IsAny<Lop>()));
            var service = new LopComandServiceImpl(mockLopRepo.Object, mockNganhRepo.Object);
            var lopDto = new LopDto { maLop = "L01", tenLop = "CNTT21-01", nganh = "Khoa học máy tính" };

            // Act
            var result = service.editLop(lopDto);

            // Assert
            Assert.True(result);
            mockLopRepo.Verify(repo => repo.editLop(It.IsAny<Lop>()), Times.Once());
        }

        [Fact]
        public void EditLop_LopNotFound_ReturnsFalse()
        {
            // Arrange
            var mockLopRepo = new Mock<ILopRepository>();
            var mockNganhRepo = new Mock<INganhRepository>();
            mockLopRepo.Setup(repo => repo.getByMa(It.IsAny<string>())).Returns((Lop)null);
            var service = new LopComandServiceImpl(mockLopRepo.Object, mockNganhRepo.Object);
            var lopDto = new LopDto { maLop = "L01", tenLop = "CNTT21-01", nganh = "Khoa học máy tính" };

            // Act
            var result = service.editLop(lopDto);

            // Assert
            Assert.False(result);
            mockLopRepo.Verify(repo => repo.editLop(It.IsAny<Lop>()), Times.Never());
        }
    }
}