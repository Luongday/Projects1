using Moq;
using QuanLyHoSoSinhVien.BusinessLayer.Services.KhoaServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.KhoaRepository;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.KhoaDTO;
using System;
using Xunit;

namespace QuanLyHoSoSinhVien.Tests
{
    public class KhoaComandServicesTests
    {
        [Fact]
        public void Add_ValidInput_ReturnsTrue()
        {
            // Arrange
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            mockKhoaRepo.Setup(repo => repo.AddNew(It.IsAny<Khoa>()));
            var service = new KhoaComandServicesImpl(mockKhoaRepo.Object);
            var khoaDto = new AddKhoaDto { Id = "K01", tenKhoa = "Công nghệ Thông tin" };

            // Act
            var result = service.add(khoaDto);

            // Assert
            Assert.True(result);
            mockKhoaRepo.Verify(repo => repo.AddNew(It.IsAny<Khoa>()), Times.Once());
        }

        [Fact]
        public void Add_NullInput_ReturnsFalse()
        {
            // Arrange
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            var service = new KhoaComandServicesImpl(mockKhoaRepo.Object);

            // Act
            var result = service.add(null);

            // Assert
            Assert.False(result);
            mockKhoaRepo.Verify(repo => repo.AddNew(It.IsAny<Khoa>()), Times.Never());
        }

        [Fact]
        public void Add_EmptyID_ReturnFalse() {
            //Arrange
            var mockKhoarepo = new Mock<IKhoaRepository>();
            var service = new KhoaComandServicesImpl(mockKhoarepo.Object);
            var khoaDto = new AddKhoaDto { Id = "", tenKhoa = "Công nghệ Thông tin" };

            //Act
            var result = service.add(khoaDto);

            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void Add_InvalidName_ReturnFalse(string name) {
            //Assert
            var mockKhoarepo = new Mock<IKhoaRepository>();
            var service = new KhoaComandServicesImpl(mockKhoarepo.Object);
            var khoaDto = new AddKhoaDto { Id = "K01", tenKhoa = name };

            //Act
            var result = service.add(khoaDto);

            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(" ", "khoa cntt")]
        [InlineData("","Khoa cntt")]
        [InlineData(null,"khoacntt")]
        public void  Add_InvalidId_ReturnFalse(string id,string name)
        {
            //Arrange
            var mockKhoarepo = new Mock<IKhoaRepository>();
            var service = new KhoaComandServicesImpl(mockKhoarepo.Object);
            var khoaDto = new AddKhoaDto { Id = id, tenKhoa = name };

            //Act
            var result = service.add(khoaDto);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void Add_KhoaIsNull_ReturnFalse() {
            //Arrange
            var mockKhoarepo = new Mock<IKhoaRepository>();
            var service = new KhoaComandServicesImpl(mockKhoarepo.Object);
            AddKhoaDto khoaDto = null;

            //Act
            var result = service.add(khoaDto);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void  Add_ValidInput_ReturnTrue()
        {
            //Arrange
            var mockKhoarepo = new Mock<IKhoaRepository>();
            var service = new KhoaComandServicesImpl(mockKhoarepo.Object);
            var khoaDto = new AddKhoaDto { Id = "k01", tenKhoa = "name" };

            //Act
            var result = service.add(khoaDto);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Add_NullID_ReturnFalse() {
            //Arrange
            var mockKhoarepo = new Mock<IKhoaRepository>();
            var service = new KhoaComandServicesImpl(mockKhoarepo.Object);
            var khoaDto = new AddKhoaDto { Id = null, tenKhoa = "Công nghệ Thông tin" };

            //Act
            var result = service.add(khoaDto);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void DeleteKhoaById_ValidId_ReturnsTrue()
        {
            // Arrange
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            mockKhoaRepo.Setup(repo => repo.GetByMa("K01")).Returns(new Khoa { makhoa = "K01" });
            mockKhoaRepo.Setup(repo => repo.delete(It.IsAny<Khoa>()));
            var service = new KhoaComandServicesImpl(mockKhoaRepo.Object);

            // Act
            var result = service.deleteKhoaById("K01");

            // Assert
            Assert.True(result);
            mockKhoaRepo.Verify(repo => repo.delete(It.IsAny<Khoa>()), Times.Once());
        }

        [Fact]
        public void DeleteKhoaById_InvalidId_ReturnsFalse()
        {
            // Arrange
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            mockKhoaRepo.Setup(repo => repo.GetByMa(It.IsAny<string>())).Returns((Khoa)null);
            var service = new KhoaComandServicesImpl(mockKhoaRepo.Object);

            // Act
            var result = service.deleteKhoaById("K01");

            // Assert
            Assert.False(result);
            mockKhoaRepo.Verify(repo => repo.delete(It.IsAny<Khoa>()), Times.Never());
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void deleteKhoaById_InvalidInput_ReturnFalse(string id) {
            //Arrange
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            var service = new KhoaComandServicesImpl(mockKhoaRepo.Object);

            //Act
            var result = service.deleteKhoaById(id);

            //Assert
            Assert.False(result);
            mockKhoaRepo.Verify(repo => repo.delete(It.IsAny<Khoa>()), Times.Never);
        }

        [Fact]
        public void EditKhoa_ValidInput_ReturnsTrue()
        {
            // Arrange
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            mockKhoaRepo.Setup(repo => repo.GetByMa("K01")).Returns(new Khoa { makhoa = "K01", tenkhoa = "Old Name" });
            mockKhoaRepo.Setup(repo => repo.edit(It.IsAny<Khoa>()));
            var service = new KhoaComandServicesImpl(mockKhoaRepo.Object);
            var khoaDto = new KhoaDto { maKhoa = "K01", tenKhoa = "Công nghệ Thông tin" };

            // Act
            var result = service.editKhoa(khoaDto);

            // Assert
            Assert.True(result);
            mockKhoaRepo.Verify(repo => repo.edit(It.IsAny<Khoa>()), Times.Once());
        }

        [Fact]
        public void EditKhoa_KhoaNotFound_ReturnsFalse()
        {
            // Arrange
            var mockKhoaRepo = new Mock<IKhoaRepository>();
            mockKhoaRepo.Setup(repo => repo.GetByMa(It.IsAny<string>())).Returns((Khoa)null);
            var service = new KhoaComandServicesImpl(mockKhoaRepo.Object);
            var khoaDto = new KhoaDto { maKhoa = "K01", tenKhoa = "Công nghệ Thông tin" };

            // Act
            var result = service.editKhoa(khoaDto);

            // Assert
            Assert.False(result);
            mockKhoaRepo.Verify(repo => repo.edit(It.IsAny<Khoa>()), Times.Never());
        }
    }
}