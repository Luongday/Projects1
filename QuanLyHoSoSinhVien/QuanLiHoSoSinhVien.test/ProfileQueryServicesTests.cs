using Moq;
using QuanLyHoSoSinhVien.BusinessLayer.Services.ProfileServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.HoSoRepository;
using System.Collections.Generic;
using Xunit;

namespace QuanLyHoSoSinhVien.Test
{
    public class ProfileQueryServicesTests
    {
        private readonly Mock<IHoSoRepository> _hoSoRepoMock;
        private readonly ProfileQueryServicesImpl _service;

        public ProfileQueryServicesTests()
        {
            _hoSoRepoMock = new Mock<IHoSoRepository>();
            _service = new ProfileQueryServicesImpl(_hoSoRepoMock.Object);
        }

        [Fact]
        public void GetAllHoSo_ShouldReturnList_WhenRepositoryReturnsData()
        {
            // Arrange
            var expectedList = new List<HoSo>
            {
                new HoSo { mahoso = "HS01", masv = "SV01" },
                new HoSo { mahoso = "HS02", masv = "SV02" }
            };

            _hoSoRepoMock.Setup(r => r.getAllHoSo()).Returns(expectedList);

            // Act
            var result = _service.getAllHoSo();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("HS01", result[0].mahoso);
            Assert.Equal("HS02", result[1].mahoso);
        }

        [Fact]
        public void GetAllHoSo_ShouldReturnEmptyList_WhenRepositoryReturnsEmpty()
        {
            _hoSoRepoMock.Setup(r => r.getAllHoSo()).Returns(new List<HoSo>());

            var result = _service.getAllHoSo();

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void TakeProfileById_ShouldReturnHoSo_WhenFound()
        {
            // Arrange
            var expectedHoSo = new HoSo { mahoso = "HS01", masv = "SV01" };
            _hoSoRepoMock.Setup(r => r.getHoSoByMaHS("HS01")).Returns(expectedHoSo);

            // Act
            var result = _service.TakeProfileById("HS01");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("HS01", result.mahoso);
            Assert.Equal("SV01", result.masv);
        }

        [Fact]
        public void TakeProfileById_ShouldReturnEmptyHoSo_WhenNotFound()
        {
            // Arrange
            _hoSoRepoMock.Setup(r => r.getHoSoByMaHS("HS99")).Returns((HoSo)null);

            // Act
            var result = _service.TakeProfileById("HS99");

            // Assert
            Assert.Null(result);
        }
    }
}
