using Moq;
using QuanLyHoSoSinhVien.BusinessLayer.Services.NganhServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.KhoaRepository;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.NganhRepository;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.NganhDTO;
using System.Collections.Generic;
using Xunit;

namespace QuanLyHoSoSinhVien.Tests
{
    public class NganhCommandServicesTests
    {
        [Fact]
        public void AddNewNganh_NganhNotExists_ReturnsTrue()
        {
            // Arrange
            var mockNganhRepo = new Mock<INganhRepository>();
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            mockNganhRepo.Setup(repo => repo.getAll()).Returns(new List<Nganh>());
            mockKhoaRepo.Setup(repo => repo.getAll()).Returns(new List<Khoa> { new Khoa { makhoa = "K01", tenkhoa = "Công nghệ Thông tin" } });
            var service = new NganhCommandServiceImpl(mockNganhRepo.Object, mockKhoaRepo.Object);
            var nganhDto = new AddNganhDto { maNganh = "NG01", tenNganh = "Khoa học máy tính", tenKhoa = "Công nghệ Thông tin" };

            // Act
            var result = service.addNewNganh(nganhDto);

            // Assert
            Assert.True(result);
            mockNganhRepo.Verify(repo => repo.addNganh(It.IsAny<Nganh>()), Times.Once());
        }

        [Fact]
        public void AddNewNganh_NganhExists_ReturnsFalse()
        {
            // Arrange
            var mockNganhRepo = new Mock<INganhRepository>();
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            mockNganhRepo.Setup(repo => repo.getAll()).Returns(new List<Nganh> { new Nganh { manganh = "NG01" } });
            var service = new NganhCommandServiceImpl(mockNganhRepo.Object, mockKhoaRepo.Object);
            var nganhDto = new AddNganhDto { maNganh = "NG01", tenNganh = "Khoa học máy tính", tenKhoa = "Công nghệ Thông tin" };

            // Act
            var result = service.addNewNganh(nganhDto);

            // Assert
            Assert.False(result);
            mockNganhRepo.Verify(repo => repo.addNganh(It.IsAny<Nganh>()), Times.Never());
        }

        [Fact]
        public void DeleteNganhWithId_ValidId_ReturnsTrue()
        {
            // Arrange
            var mockNganhRepo = new Mock<INganhRepository>();
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            mockNganhRepo.Setup(repo => repo.getAll()).Returns(new List<Nganh> { new Nganh { manganh = "NG01" } });
            mockNganhRepo.Setup(repo => repo.deleteNganh(It.IsAny<string>()));
            var service = new NganhCommandServiceImpl(mockNganhRepo.Object, mockKhoaRepo.Object);

            // Act
            var result = service.deleteNganhWithId("NG01");

            // Assert
            Assert.True(result);
            mockNganhRepo.Verify(repo => repo.deleteNganh(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void DeleteNganhWithId_InvalidId_ReturnsFalse()
        {
            // Arrange
            var mockNganhRepo = new Mock<INganhRepository>();
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            mockNganhRepo.Setup(repo => repo.getAll()).Returns(new List<Nganh>());
            var service = new NganhCommandServiceImpl(mockNganhRepo.Object, mockKhoaRepo.Object);

            // Act
            var result = service.deleteNganhWithId("NG01");

            // Assert
            Assert.False(result);
            mockNganhRepo.Verify(repo => repo.deleteNganh(It.IsAny<string>()), Times.Never());
        }

        [Fact]
        public void EditNganh_ValidInput_ReturnsTrue()
        {
            // Arrange
            var mockNganhRepo = new Mock<INganhRepository>();
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            mockNganhRepo.Setup(repo => repo.getAll()).Returns(new List<Nganh> { new Nganh { manganh = "NG01", tennganh = "Old Name", makhoa = "K01",
                                                                                Khoa = new Khoa { makhoa = "K01", tenkhoa = "Công nghệ Thông tin" } } });
            mockNganhRepo.Setup(repo => repo.editNganh(It.IsAny<Nganh>()));
            var service = new NganhCommandServiceImpl(mockNganhRepo.Object, mockKhoaRepo.Object);
            var nganhDto = new NganhDto { maNganh = "NG01", tenNganh = "Khoa học máy tính", khoa = "Công nghệ Thông tin" };

            // Act
            var result = service.editNganh(nganhDto);

            // Assert
            Assert.True(result);
            mockNganhRepo.Verify(repo => repo.editNganh(It.IsAny<Nganh>()), Times.Once());
        }

        [Fact]
        public void EditNganh_NganhNotFound_ReturnsFalse()
        {
            // Arrange
            var mockNganhRepo = new Mock<INganhRepository>();
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            mockNganhRepo.Setup(repo => repo.getAll()).Returns(new List<Nganh>());
            var service = new NganhCommandServiceImpl(mockNganhRepo.Object, mockKhoaRepo.Object);
            var nganhDto = new NganhDto { maNganh = "NG01", tenNganh = "Khoa học máy tính", khoa = "Công nghệ Thông tin" };

            // Act
            var result = service.editNganh(nganhDto);

            // Assert
            Assert.False(result);
            mockNganhRepo.Verify(repo => repo.editNganh(It.IsAny<Nganh>()), Times.Never());
        }
    }
}