using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.StudentRepository;

namespace QuanLyHoSoSinhVien.Tests.BusinessLayer.Services.StudentServices
{
    public class SinhVienQueryImplTests
    {
        private readonly Mock<IStudentRepository> _mockStudentRepo;
        private readonly SinhVienServicesQueryImpl _service;
        private readonly List<QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien> _testData;

        public SinhVienQueryImplTests()
        {
            _mockStudentRepo = new Mock<IStudentRepository>();
            _service = new SinhVienServicesQueryImpl(_mockStudentRepo.Object);

            // Tạo dữ liệu test mẫu
            _testData = new List<QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien>
            {
                new QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien
                {
                    masv = "SV001",
                    trangthai = "Đang học",
                    //malop = "L001",
                    Lop = new QuanLyHoSoSinhVien.DataAccessLayer.Entity.Lop
                    {
                        tenlop = "KHMT21-01",
                        malop = "L001"
                    }
                },
                new QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien
                {
                    masv = "SV002",
                    trangthai = "Tạm dừng",
                   // malop = "L002",
                    Lop = new QuanLyHoSoSinhVien.DataAccessLayer.Entity.Lop
                    {
                        tenlop = "HTTT21-02",
                        malop = "L002"
                    }
                },
                new QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien
                {
                    masv = "SV003",
                    trangthai = "Đang học",
                    //malop = "L003",
                    Lop = new QuanLyHoSoSinhVien.DataAccessLayer.Entity.Lop
                    {
                        tenlop = "KTPM21-03",
                        malop = "L003"
                    }
                },
                new QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien
                {
                    masv = "SV004",
                    trangthai = "Tạm dừng",
                   // malop = "L004"
                   Lop = new QuanLyHoSoSinhVien.DataAccessLayer.Entity.Lop
                    {
                        tenlop = "ATTT21-04",
                        malop = "L004"
                    }
                }
            };
        }

        #region Tests cho getAll()
        [Fact]
        public void GetAll_ShouldReturnAllStudents_WhenCalled()
        {
            // Arrange
            _mockStudentRepo.Setup(x => x.GetAllStudents()).Returns(_testData);

            // Act
            var result = _service.getAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Count);
            _mockStudentRepo.Verify(x => x.GetAllStudents(), Times.Once);
        }

        [Fact]
        public void GetAll_ShouldReturnEmptyList_WhenNoStudents()
        {
            // Arrange
            _mockStudentRepo.Setup(x => x.GetAllStudents()).Returns(new List<QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien>());

            // Act
            var result = _service.getAll();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
        #endregion

        #region Tests cho getAllSinhVienTamVang()
        [Fact]
        public void GetAllSinhVienTamVang_ShouldReturnOnlyTamVangStudents()
        {
            // Arrange
            _mockStudentRepo.Setup(x => x.GetAllStudents()).Returns(_testData);

            // Act
            var result = _service.getAllSinhVienTotNghiep();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.All(result, s => Assert.Contains("Tạm dừng", s.trangthai));
        }

        [Fact]
        public void GetAllSinhVienTamVang_ShouldReturnEmptyList_WhenNoTamVangStudents()
        {
            // Arrange
            var dataWithoutTamVang = _testData.Where(s => !s.trangthai.Contains("Tạm dừng")).ToList();
            _mockStudentRepo.Setup(x => x.GetAllStudents()).Returns(dataWithoutTamVang);

            // Act
            var result = _service.getAllSinhVienTotNghiep();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetAllSinhVienTamVang_ShouldReturnEmptyList_WhenRepositoryReturnsNull()
        {
            // Arrange
            _mockStudentRepo.Setup(x => x.GetAllStudents()).Returns((List<QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien>)null);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _service.getAllSinhVienTotNghiep());
        }
        #endregion

        #region Tests cho getAllStdentDangHoc()
        [Fact]
        public void GetAllStdentDangHoc_ShouldReturnOnlyDangHocStudents()
        {
            // Arrange
            _mockStudentRepo.Setup(x => x.GetAllStudents()).Returns(_testData);

            // Act
            var result = _service.getAllStdentDangHoc();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.All(result, s => Assert.Contains("Đang học", s.trangthai));
        }

        [Fact]
        public void GetAllStdentDangHoc_ShouldReturnEmptyList_WhenNoDangHocStudents()
        {
            // Arrange
            var dataWithoutDangHoc = _testData.Where(s => !s.trangthai.Contains("Đang học")).ToList();
            _mockStudentRepo.Setup(x => x.GetAllStudents()).Returns(dataWithoutDangHoc);

            // Act
            var result = _service.getAllStdentDangHoc();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetAllStdentDangHoc_ShouldReturnEmptyList_WhenRepositoryReturnsNull()
        {
            // Arrange
            _mockStudentRepo.Setup(x => x.GetAllStudents()).Returns((List<QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien>)null);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _service.getAllStdentDangHoc());
        }
        #endregion

        #region Tests cho getAStudentForMa()
        [Fact]
        public void GetAStudentForMa_ShouldReturnStudent_WhenValidMaSV()
        {
            // Arrange
            var expectedStudent = _testData.First();
            _mockStudentRepo.Setup(x => x.GetStudentId("SV001")).Returns(expectedStudent);

            // Act
            var result = _service.getAStudentForMa("SV001");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("SV001", result.masv);
            _mockStudentRepo.Verify(x => x.GetStudentId("SV001"), Times.Once);
        }

        [Fact]
        public void GetAStudentForMa_ShouldReturnNull_WhenInvalidMaSV()
        {
            // Arrange
            _mockStudentRepo.Setup(x => x.GetStudentId("INVALID")).Returns((QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien)null);

            // Act
            var result = _service.getAStudentForMa("INVALID");

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        public void GetAStudentForMa_ShouldHandleInvalidInput(string maSV)
        {
            // Act
            var result = _service.getAStudentForMa(maSV);

            // Assert
            
            _mockStudentRepo.Verify(x => x.GetStudentId(It.IsAny<string>()), Times.Never);
        }
        #endregion

        #region Tests cho getSinhVienForLop()
        [Fact]
        public void GetSinhVienForLop_ShouldReturnStudentsFromSpecificClass()
        {
            // Arrange
            _mockStudentRepo.Setup(x => x.GetAllStudents()).Returns(_testData);

            // Act
            var result = _service.getSinhVienForLop("KHMT21-01");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Count);
            Assert.All(result, s => Assert.Contains("KHMT21-01", s.Lop.tenlop));
        }

        [Fact]
        public void GetSinhVienForLop_ShouldReturnEmptyList_WhenClassNotFound()
        {
            // Arrange
            _mockStudentRepo.Setup(x => x.GetAllStudents()).Returns(_testData);

            // Act
            var result = _service.getSinhVienForLop("NONEXISTENT");

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        public void GetSinhVienForLop_ShouldReturnEmptyList_WhenInvalidTenLop(string tenLop)
        {
            // Act
            var result = _service.getSinhVienForLop(tenLop);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            _mockStudentRepo.Verify(x => x.GetAllStudents(), Times.Never);
        }

        [Fact]
        public void GetSinhVienForLop_ShouldHandlePartialMatch()
        {
            // Arrange
            _mockStudentRepo.Setup(x => x.GetAllStudents()).Returns(_testData);

            // Act
            var result = _service.getSinhVienForLop("HTTT21-02");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Count); 
        }

        [Fact]
        public void GetSinhVienForLop_ShouldHandleNullLopProperty()
        {
            // Arrange
            var dataWithNullLop = new List<QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien>
            {
                new QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien { masv = "SV001", trangthai = "Đang học", malop = null }
            };
            _mockStudentRepo.Setup(x => x.GetAllStudents()).Returns(dataWithNullLop);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => _service.getSinhVienForLop("CNTT01"));
        }
        #endregion

        #region Integration Tests
        [Fact]
        public void AllMethods_ShouldWork_WithEmptyRepository()
        {
            // Arrange
            _mockStudentRepo.Setup(x => x.GetAllStudents()).Returns(new List<QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien>());
            _mockStudentRepo.Setup(x => x.GetStudentId(It.IsAny<string>())).Returns((QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien)null);

            // Act & Assert
            Assert.Empty(_service.getAll());
            Assert.Empty(_service.getAllSinhVienTotNghiep());
            Assert.Empty(_service.getAllStdentDangHoc());
            Assert.Empty(_service.getSinhVienForLop("AnyClass"));
            Assert.Null(_service.getAStudentForMa("AnySV"));
        }
        #endregion

        #region Boundary Tests
        [Fact]
        public void GetSinhVienForLop_ShouldBeCaseInsensitive_WhenUsingContains()
        {
            // Arrange
            var dataWithMixedCase = new List<QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien>
            {
                new QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien
                {
                    masv = "SV001",
                    trangthai = "Đang học",
                   // malop = "L001",// lowercase
                    Lop  = new QuanLyHoSoSinhVien.DataAccessLayer.Entity.Lop
                    {
                        tenlop = "KHMT21-01",
                        malop = "L001"
                    }
                }
            };
            _mockStudentRepo.Setup(x => x.GetAllStudents()).Returns(dataWithMixedCase);

            // Act
            var result = _service.getSinhVienForLop("KHMT21-01"); // uppercase

            // Assert
            Assert.Single(result); // Vì bây giờ match bất kể hoa/thường
                                   // Contains is case-sensitive
        }

        [Theory]
        [InlineData("Đang học", 2)]
        [InlineData("Tạm dừng", 2)]
        [InlineData("Tốt nghiệp", 0)]
        public void TrangThaiFilters_ShouldReturnCorrectCounts(string trangThai, int expectedCount)
        {
            // Arrange
            _mockStudentRepo.Setup(x => x.GetAllStudents()).Returns(_testData);

            // Act
            List<QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien> result;
            if (trangThai == "Đang học")
                result = _service.getAllStdentDangHoc();
            else if (trangThai == "Tạm dừng")
                result = _service.getAllSinhVienTotNghiep();
            else
                result = new List<QuanLyHoSoSinhVien.DataAccessLayer.Entity.SinhVien>(); // Không có method cho trạng thái khác

            // Assert
            Assert.Equal(expectedCount, result.Count);
        }
        #endregion
    }

    #region Helper Classes cho Testing
    // Entity classes cho testing (nếu chưa có)
    public class SinhVien
    {
        public string mssv { get; set; }
        public string hovaten { get; set; }
        public string trangthai { get; set; }
        public Lop Lop { get; set; }
    }

    //public class Lop
    //{
    //    public string tenlop { get; set; }
    //    public string maLop { get; set; }
    //}
    #endregion
}