using DocumentFormat.OpenXml.Drawing.Charts;
using Moq;
using QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.HoSoRepository;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.StudentRepository;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.UserRepository;
using System;
using System.Collections.Generic;
using Xunit;

namespace QuanLyHoSoSinhVien.Tests
{
    public class StudentComandServicesTests
    { 
        private readonly Mock<IStudentRepository> _studentRepositoryMock;
        private readonly Mock<IHoSoRepository> _hoSoRepositoryMock;
        private readonly Mock<IUserDAO> _userDAOMock;
        private readonly StudentComandServicesImpl _studentComandServices;

        public StudentComandServicesTests()
        {
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _hoSoRepositoryMock = new Mock<IHoSoRepository>();
            _userDAOMock = new Mock<IUserDAO>();
            _studentComandServices = new StudentComandServicesImpl(_studentRepositoryMock.Object, _hoSoRepositoryMock.Object, _userDAOMock.Object);
        }
        private SinhVien CreateTestStudent()
        {
            return new SinhVien
            {
                masv = "SV001",
                tensv = "Nguyen Van A",
                malop = "L01",
                NgaySinh = new DateTime(2000, 1, 1),
                gt = true,
                dc = "Hà Nội",
                sdt = "0123456789",
                email = "a@gmail.com",
                cccd = "123456789",
                noisinh = "Hà Nội",
                dantoc = "Kinh",
                tongiao = "Không",
                trangthai = "Đang học"
            };
        }

        [Fact]
        public void addStudent_SinhVienNull_ReturnFalse() {
            // Arrange
            SinhVien sv = null;

            // Act
            var result = _studentComandServices.addStudent(sv);

            // Assert
            Assert.False(result);
            _studentRepositoryMock.Verify(repo => repo.addStudent(It.IsAny<SinhVien>()), Times.Never);
            _hoSoRepositoryMock.Verify(hs => hs.AddHoSo(It.IsAny<HoSo>()), Times.Never);
            _userDAOMock.Verify(dao => dao.addRegister(It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public void addStudent_ValidInput_ReturnTrue() {
            //Arrange
            SinhVien sv = CreateTestStudent();

            //Act
            var result = _studentComandServices.addStudent(sv);

            //Assert
            Assert.True(result);
            _hoSoRepositoryMock.Verify(repo => repo.AddHoSo(It.Is<HoSo>(h =>
                h.mahoso == "HS" + sv.masv &&
                h.masv == sv.masv &&
                h.trangthaihoso == (sv.trangthai == "Tốt nghiệp")
            )), Times.Once);
            _userDAOMock.Verify(dao => dao.addRegister(It.Is<User>(user =>
                user.userId == sv.masv + "register" &&
                user.userName == "SV" + sv.masv &&
                user.password == "1111" &&
                user.isAdmin == false
            )), Times.Once);
        }
        [Fact]
        public void addStudent_RepoThrowException_ReturnFalse() {
            //Arrange
            _studentRepositoryMock.Setup(repo=>repo.addStudent(It.IsAny<SinhVien>())).Throws(new Exception("SaveChange Error"));
            SinhVien sv = CreateTestStudent();

            //Act
            var result = _studentComandServices.addStudent(sv);

            //Assert
            Assert.False(result);
            _hoSoRepositoryMock.Verify(repo => repo.AddHoSo(It.IsAny<HoSo>()), Times.Never);
            _userDAOMock.Verify(dao => dao.addRegister(It.IsAny<User>()), Times.Never);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void delete_InValidMa_ReturnFalse(string ma) {
            //Arrange
            string studentId = ma;

            //Act
            var result = _studentComandServices.delete(studentId);

            //Asert
            Assert.False(result);
            _studentRepositoryMock.Verify(repo => repo.GetStudentId(It.IsAny<string>()), Times.Never);
            _studentRepositoryMock.Verify(repo => repo.deleteSinhVien(It.IsAny<SinhVien>()), Times.Never);
        }
    }
}