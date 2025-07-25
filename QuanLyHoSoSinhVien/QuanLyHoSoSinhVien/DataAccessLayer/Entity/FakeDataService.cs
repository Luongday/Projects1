﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace QuanLyHoSoSinhVien.DataAccessLayer.Entity
{
    public static class FakeDataService
    {
        private static readonly Random random = new Random(42);

        public static readonly string[] TenSinhVien = new string[]
        {
            "Nguyễn Văn An", "Trần Thị Bình", "Lê Văn Cường", "Phạm Thị Dung", "Hoàng Văn Em",
            "Vũ Thị Ất", "Đặng Văn Giang", "Bùi Thị Hương", "Lý Văn Nam", "Trịnh Thị Kim",
            "Ngô Văn Long", "Đinh Thị Mai", "Tô Văn Nam", "Lưu Thị Oanh", "Hồ Văn Phúc",
            "Đỗ Thị Quỳnh", "Cao Văn Rạng", "Phan Thị Sáng", "Võ Văn Tài", "Lại Thị Uyên",
            "Dương Văn Việt", "Chu Thị Xuân", "Mã Văn Yên", "Ôn Thị Zung", "Thái Văn Anh",
            "Lâm Thị Bảo", "Kiều Văn Cát", "Ung Thị Đào", "Từ Văn Béo", "Khúc Thị Phượng",
            "Tạ Văn Gấu", "Khổng Thị Hoa", "Triệu Văn Mịch", "Lục Thị Khuyên", "Mã Văn Lâm",
            "Bạch Thị Mây", "Quách Văn Ngọc", "Yên Thị Ong", "Hà Văn Phong", "Sầm Thị Quế",
            "Tôn Văn Rùa", "Ấu Thị Sen", "Mai Văn Tùng", "Tô Thị Uyển", "Diêu Văn Vinh",
            "Gia Thị Mai", "Nông Văn Xuân", "Ứng Thị Yến", "Lương Văn Lượng", "Mạc Thị Ánh",
            "Dương Văn Bách", "Lương Thị Cúc", "Châu Văn Dũng", "Ân Thị Êm", "Tống Văn Phát",
            "Mùa Thị Gió", "Sơn Văn Hải", "Mông Thị Ỉn", "Khuất Văn Khang", "Bế Thị Lan",
            "Tiêu Văn Minh", "Chu Thị Ngần", "Âu Văn Ồn", "Đàm Thị Phiến", "Hứa Văn Quang",
            "Đoàn Văn Lực", "Khiếu Văn Sáu", "Tiếp Thị Tám", "Trinh Huyền Trình", "Yếu Thị Vân",
            "Lê Huyền Nhi", "Lê Thị Yêu", "Lãnh Văn An", "Cung Thị Anh", "Từ Văn Băng",
            "Nùng Thị Cầm", "Cầm Văn Đỉnh", "Lô Thị Eo", "Thạch Văn Phòng", "Sinh Thị Giọt",
            "Thi Văn Hùng", "Ngô Văn Minh", "Đan Văn Kẻ", "Nguyễn Thị Mừng", "Múa Văn Mồm",
            "Đình Thị Nghi", "Đinh Văn Ông", "Hai Thị Phấn", "Ba Văn Quặp", "Đỗ Văn Dũng",
            "Nguyễn Văn Năm", "Nguyễn Thị Tô", "Vũ Văn Bảy", "Vũ Thị Út", "Tào Nhọc Nhi",
            "Nguyễn Văn Mười", "Lê Văn An", "Ngọ Thị Áp", "Vạn Văn Bọt", "Triệu Thị Trinh"
        };

        public static readonly string[] DanhSachTinh = new string[]
        {
            "Hà Nội", "TP.Hồ Chí Minh", "Đà Nẵng", "Hải Phòng", "Cần Thơ", "An Giang", "Bà Rịa-Vũng Tàu",
            "Bắc Giang", "Bắc Kạn", "Bạc Liêu", "Bắc Ninh", "Bến Tre", "Bình Định", "Bình Dương",
            "Bình Phước", "Bình Thuận", "Cà Mau", "Cao Bằng", "Đắk Lắk", "Đắk Nông", "Điện Biên",
            "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang", "Hà Nam", "Hà Tĩnh", "Hải Dương",
            "Hậu Giang", "Hòa Bình", "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu",
            "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Nghệ An", "Ninh Bình",
            "Ninh Thuận", "Phú Thọ", "Phú Yên", "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh",
            "Quảng Trị", "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa",
            "Thừa Thiên Huế", "Tiền Giang", "Trà Vinh", "Tuyên Quang", "Vĩnh Long", "Vĩnh Phúc", "Yên Bái"
        };

        public static readonly string[] DanhSachDanToc = new string[]
        {
            "Kinh", "Tày", "Thái", "Hoa", "Khmer", "Mường", "Nùng", "Hmong", "Dao", "Gia Rai",
            "Ngái", "Ê Đê", "Ba Na", "Xơ Đăng", "Sán Chay", "Cơ Ho", "Chăm", "Sán Dìu", "Hrê", "Mnông",
            "Ra Glai", "Xtiêng", "Bru-Vân Kiều", "Thổ", "Giáy", "Cơ Tu", "Gié Triêng", "Mạ", "Co", "Tà Ôi",
            "Chơ Ro", "Kháng", "Xinh Mun", "Hà Nhì", "Chu Ru", "Lào", "La Chí", "La Ha", "Phù Lá", "La Hủ",
            "Lự", "Lô Lô", "Chứt", "Mảng", "Pà Thẻn", "Lu", "Ngư", "Ơ Đu", "Rơ Măm", "Brâu",
            "Ro Mam", "Si La", "Pu Péo", "Cống"
        };

        public static readonly (string Ten, string Ma)[] DanhSachKhoa = new (string, string)[]
        {
            ("Khoa Công nghệ Thông tin", "CNTT"),
            ("Khoa Kinh tế", "KT"),
            ("Khoa Ngoại ngữ", "NN"),
            ("Khoa Cơ khí", "CK"),
            ("Khoa Điện tử Viễn thông", "DTVT"),
            ("Khoa Y học", "Y"),
            ("Khoa Luật", "LUAT"),
            ("Khoa Sư phạm", "SP"),
            ("Khoa Nông nghiệp", "NN2"),
            ("Khoa Xây dựng", "XD")
        };

        public static readonly (string Ten, string MaKhoa)[] DanhSachNganh = new (string, string)[]
        {
            ("Khoa học máy tính", "CNTT"), ("Hệ thống thông tin", "CNTT"), ("Kỹ thuật phần mềm", "CNTT"),
            ("An toàn thông tin", "CNTT"), ("Trí tuệ nhân tạo", "CNTT"),
            ("Quản trị kinh doanh", "KT"), ("Kế toán", "KT"), ("Tài chính ngân hàng", "KT"),
            ("Marketing", "KT"), ("Kinh tế đối ngoại", "KT"),
            ("Tiếng Anh", "NN"), ("Tiếng Nhật", "NN"), ("Tiếng Trung", "NN"),
            ("Tiếng Hàn", "NN"), ("Tiếng Pháp", "NN"),
            ("Cơ khí chế tạo máy", "CK"), ("Cơ khí động lực", "CK"), ("Cơ khí ô tô", "CK"),
            ("Cơ khí hàng không", "CK"), ("Cơ khí tự động hóa", "CK"),
            ("Điện tử", "DTVT"), ("Viễn thông", "DTVT"), ("Điện tử y sinh", "DTVT"),
            ("Kỹ thuật điều khiển", "DTVT"), ("Mạng máy tính", "DTVT"),
            ("Y khoa", "Y"), ("Răng hàm mặt", "Y"), ("Dược học", "Y"),
            ("Y tế công cộng", "Y"), ("Điều dưỡng", "Y"),
            ("Luật kinh tế", "LUAT"), ("Luật hành chính", "LUAT"), ("Luật dân sự", "LUAT"),
            ("Luật hình sự", "LUAT"), ("Luật quốc tế", "LUAT"),
            ("Sư phạm Toán", "SP"), ("Sư phạm Lý", "SP"), ("Sư phạm Hóa", "SP"),
            ("Sư phạm Sinh", "SP"), ("Sư phạm Văn", "SP"),
            ("Nông học", "NN2"), ("Chăn nuôi", "NN2"), ("Thú y", "NN2"),
            ("Lâm nghiệp", "NN2"), ("Thủy sản", "NN2"),
            ("Xây dựng dân dụng", "XD"), ("Xây dựng công nghiệp", "XD"), ("Kỹ thuật hạ tầng", "XD"),
            ("Kinh tế xây dựng", "XD"), ("Quản lý xây dựng", "XD")
        };

        public static User[] GenerateUsers(int count = 100)
        {
            var sinhViens = GenerateSinhViens(count); // Tạo danh sách sinh viên trước
            return Enumerable.Range(0, count).Select(i => new User
            {
                userId = $"{sinhViens[i].masv}register", // Sử dụng masv + "register" (ví dụ: SV001register)
                userName = $"user{i + 1:D3}", // Giữ định dạng userName
                password = $"pass{i + 1:D3}", // Giữ định dạng password
                isAdmin = false
            }).ToArray();
        }

        public static Khoa[] GenerateKhoas()
        {
            return Enumerable.Range(1, DanhSachKhoa.Length).Select(i => new Khoa
            {
                makhoa = DanhSachKhoa[i - 1].Ma,
                tenkhoa = DanhSachKhoa[i - 1].Ten,
                //manghanh = $"NG{i:D3}"
            }).ToArray();
        }

        public static Nganh[] GenerateNganhs()
        {
            return Enumerable.Range(1, DanhSachNganh.Length).Select(i => new Nganh
            {
                manganh = $"NG{i:D3}",
                tennganh = DanhSachNganh[i - 1].Ten,
                makhoa = DanhSachNganh[i - 1].MaKhoa,
                //malop = $"L{i:D3}"
            }).ToArray();
        }

        public static Lop[] GenerateLops(int count = 100)
        {
            return Enumerable.Range(1, count).Select(i =>
            {
                var nganh = DanhSachNganh[(i - 1) % DanhSachNganh.Length];
                var vietTat = string.Concat(nganh.Ten.Split(' ').Select(t => t[0])).ToUpper();

                return new Lop
                {
                    malop = $"L{i:D3}",
                    manganh = $"NG{(i - 1) % DanhSachNganh.Length + 1:D3}",
                    tenlop = $"{vietTat}{21 + (i - 1) / 50}-{(i - 1) % 5 + 1:D2}",
                };
            }).ToArray();
        }

        public static SinhVien[] GenerateSinhViens(int count = 100)
        {
            return Enumerable.Range(1, count).Select(i =>
            {
                var hoTen = TenSinhVien[i - 1];
                var emailBase = RemoveDiacritics(hoTen.ToLower().Replace(" ", ""));

                return new SinhVien
                {
                    masv = $"SV{i:D3}",
                    tensv = hoTen,
                    NgaySinh = new DateTime(1998 + i % 6, random.Next(1, 13), random.Next(1, 29)),
                    gt = i % 2 == 0,
                    dc = $"{random.Next(1, 100)} Đường {random.Next(1, 50)}, {DanhSachTinh[random.Next(DanhSachTinh.Length)]}",
                    sdt = $"0{random.Next(3, 10)}{random.Next(10000000, 99999999)}",
                    malop = $"L{(i - 1) % 100 + 1:D3}",
                    email = $"{emailBase}{i}@student.edu.vn",
                    cccd = $"{random.Next(100000000, 999999999)}{random.Next(0, 10)}",
                    noisinh = DanhSachTinh[random.Next(DanhSachTinh.Length)],
                    tongiao = "Không",
                    dantoc = DanhSachDanToc[random.Next(DanhSachDanToc.Length)],
                    trangthai = i % 70 == 0 ? "Tốt nghiệp" : "Đang học"
                };
            }).ToArray();
        }

        public static HoSo[] GenerateHoSos(int count = 100)
        {
            var ngayTao = DateTime.Now.AddDays(-random.Next(30, 300));
            var ngayCapNhat = ngayTao.AddDays(random.Next(0, 60));
            var sinhViens = GenerateSinhViens(count);

            return Enumerable.Range(0, count).Select(i =>
            {
                bool hoSoTrangThai = sinhViens[i].trangthai == "Tốt nghiệp";

                return new HoSo
                {
                    mahoso = $"HS{i + 1:D3}",
                    masv = sinhViens[i].masv,
                    NgayTao = ngayTao,
                    NgayCapNhat = ngayCapNhat,
                    trangthaihoso = hoSoTrangThai
                };
            }).ToArray();
        }

        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
