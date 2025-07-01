using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLyHoSoSinhVien.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khoas",
                columns: table => new
                {
                    makhoa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tenkhoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoas", x => x.makhoa);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Nganhs",
                columns: table => new
                {
                    manghanh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tennganh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    makhoa = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nganhs", x => x.manghanh);
                    table.ForeignKey(
                        name: "FK_Nganhs_Khoas_makhoa",
                        column: x => x.makhoa,
                        principalTable: "Khoas",
                        principalColumn: "makhoa");
                });

            migrationBuilder.CreateTable(
                name: "Lops",
                columns: table => new
                {
                    malop = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    manghanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tenlop = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    siso = table.Column<int>(type: "int", nullable: false),
                    nghanhmanghanh = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lops", x => x.malop);
                    table.ForeignKey(
                        name: "FK_Lops_Nganhs_nghanhmanghanh",
                        column: x => x.nghanhmanghanh,
                        principalTable: "Nganhs",
                        principalColumn: "manghanh");
                });

            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    masv = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tensv = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gt = table.Column<bool>(type: "bit", nullable: false),
                    dc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sdt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    malop = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.masv);
                    table.ForeignKey(
                        name: "FK_SinhViens_Lops_malop",
                        column: x => x.malop,
                        principalTable: "Lops",
                        principalColumn: "malop");
                });

            migrationBuilder.CreateTable(
                name: "HoSos",
                columns: table => new
                {
                    mahoso = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    msv = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    tensv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gt = table.Column<bool>(type: "bit", nullable: false),
                    dc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tenlop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tenkhoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tennghanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cccd = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    noisinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    tongiao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dantoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    trangthai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSos", x => x.mahoso);
                    table.ForeignKey(
                        name: "FK_HoSos_SinhViens_msv",
                        column: x => x.msv,
                        principalTable: "SinhViens",
                        principalColumn: "masv",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Khoas",
                columns: new[] { "makhoa", "tenkhoa" },
                values: new object[,]
                {
                    { "CK", "Khoa Cơ khí" },
                    { "CNTT", "Khoa Công nghệ Thông tin" },
                    { "DTVT", "Khoa Điện tử Viễn thông" },
                    { "KT", "Khoa Kinh tế" },
                    { "LUAT", "Khoa Luật" },
                    { "NN", "Khoa Ngoại ngữ" },
                    { "NN2", "Khoa Nông nghiệp" },
                    { "SP", "Khoa Sư phạm" },
                    { "XD", "Khoa Xây dựng" },
                    { "Y", "Khoa Y học" }
                });

            migrationBuilder.InsertData(
                table: "Lops",
                columns: new[] { "malop", "manghanh", "nghanhmanghanh", "siso", "tenlop" },
                values: new object[,]
                {
                    { "L001", "NG001", null, 26, "tính21-01" },
                    { "L002", "NG002", null, 27, "tin21-02" },
                    { "L003", "NG003", null, 28, "mềm21-03" },
                    { "L004", "NG004", null, 29, "tin21-04" },
                    { "L005", "NG005", null, 30, "tạo21-05" },
                    { "L006", "NG006", null, 31, "doanh21-01" },
                    { "L007", "NG007", null, 32, "toán21-02" },
                    { "L008", "NG008", null, 33, "hàng21-03" },
                    { "L009", "NG009", null, 34, "Marketing21-04" },
                    { "L010", "NG010", null, 25, "ngoại21-05" },
                    { "L011", "NG011", null, 26, "Anh21-01" },
                    { "L012", "NG012", null, 27, "Nhật21-02" },
                    { "L013", "NG013", null, 28, "Trung21-03" },
                    { "L014", "NG014", null, 29, "Hàn21-04" },
                    { "L015", "NG015", null, 30, "Pháp21-05" },
                    { "L016", "NG016", null, 31, "máy21-01" },
                    { "L017", "NG017", null, 32, "lực21-02" },
                    { "L018", "NG018", null, 33, "tô21-03" },
                    { "L019", "NG019", null, 34, "không21-04" },
                    { "L020", "NG020", null, 25, "hóa21-05" },
                    { "L021", "NG021", null, 26, "tử21-01" },
                    { "L022", "NG022", null, 27, "thông21-02" },
                    { "L023", "NG023", null, 28, "sinh21-03" },
                    { "L024", "NG024", null, 29, "khiển21-04" },
                    { "L025", "NG025", null, 30, "tính21-05" },
                    { "L026", "NG026", null, 31, "khoa21-01" },
                    { "L027", "NG027", null, 32, "mặt21-02" },
                    { "L028", "NG028", null, 33, "học21-03" },
                    { "L029", "NG029", null, 34, "cộng21-04" },
                    { "L030", "NG030", null, 25, "dưỡng21-05" },
                    { "L031", "NG031", null, 26, "tế21-01" },
                    { "L032", "NG032", null, 27, "chính21-02" },
                    { "L033", "NG033", null, 28, "sự21-03" },
                    { "L034", "NG034", null, 29, "sự21-04" },
                    { "L035", "NG035", null, 30, "tế21-05" },
                    { "L036", "NG036", null, 31, "Toán21-01" },
                    { "L037", "NG037", null, 32, "Lý21-02" },
                    { "L038", "NG038", null, 33, "Hóa21-03" },
                    { "L039", "NG039", null, 34, "Sinh21-04" },
                    { "L040", "NG040", null, 25, "Văn21-05" },
                    { "L041", "NG041", null, 26, "học21-01" },
                    { "L042", "NG042", null, 27, "nuôi21-02" },
                    { "L043", "NG043", null, 28, "y21-03" },
                    { "L044", "NG044", null, 29, "nghiệp21-04" },
                    { "L045", "NG045", null, 30, "sản21-05" },
                    { "L046", "NG046", null, 31, "dụng21-01" },
                    { "L047", "NG047", null, 32, "nghiệp21-02" },
                    { "L048", "NG048", null, 33, "tầng21-03" },
                    { "L049", "NG049", null, 34, "dựng21-04" },
                    { "L050", "NG050", null, 25, "dựng21-05" },
                    { "L051", "NG001", null, 26, "tính22-01" },
                    { "L052", "NG002", null, 27, "tin22-02" },
                    { "L053", "NG003", null, 28, "mềm22-03" },
                    { "L054", "NG004", null, 29, "tin22-04" },
                    { "L055", "NG005", null, 30, "tạo22-05" },
                    { "L056", "NG006", null, 31, "doanh22-01" },
                    { "L057", "NG007", null, 32, "toán22-02" },
                    { "L058", "NG008", null, 33, "hàng22-03" },
                    { "L059", "NG009", null, 34, "Marketing22-04" },
                    { "L060", "NG010", null, 25, "ngoại22-05" },
                    { "L061", "NG011", null, 26, "Anh22-01" },
                    { "L062", "NG012", null, 27, "Nhật22-02" },
                    { "L063", "NG013", null, 28, "Trung22-03" },
                    { "L064", "NG014", null, 29, "Hàn22-04" },
                    { "L065", "NG015", null, 30, "Pháp22-05" },
                    { "L066", "NG016", null, 31, "máy22-01" },
                    { "L067", "NG017", null, 32, "lực22-02" },
                    { "L068", "NG018", null, 33, "tô22-03" },
                    { "L069", "NG019", null, 34, "không22-04" },
                    { "L070", "NG020", null, 25, "hóa22-05" },
                    { "L071", "NG021", null, 26, "tử22-01" },
                    { "L072", "NG022", null, 27, "thông22-02" },
                    { "L073", "NG023", null, 28, "sinh22-03" },
                    { "L074", "NG024", null, 29, "khiển22-04" },
                    { "L075", "NG025", null, 30, "tính22-05" },
                    { "L076", "NG026", null, 31, "khoa22-01" },
                    { "L077", "NG027", null, 32, "mặt22-02" },
                    { "L078", "NG028", null, 33, "học22-03" },
                    { "L079", "NG029", null, 34, "cộng22-04" },
                    { "L080", "NG030", null, 25, "dưỡng22-05" },
                    { "L081", "NG031", null, 26, "tế22-01" },
                    { "L082", "NG032", null, 27, "chính22-02" },
                    { "L083", "NG033", null, 28, "sự22-03" },
                    { "L084", "NG034", null, 29, "sự22-04" },
                    { "L085", "NG035", null, 30, "tế22-05" },
                    { "L086", "NG036", null, 31, "Toán22-01" },
                    { "L087", "NG037", null, 32, "Lý22-02" },
                    { "L088", "NG038", null, 33, "Hóa22-03" },
                    { "L089", "NG039", null, 34, "Sinh22-04" },
                    { "L090", "NG040", null, 25, "Văn22-05" },
                    { "L091", "NG041", null, 26, "học22-01" },
                    { "L092", "NG042", null, 27, "nuôi22-02" },
                    { "L093", "NG043", null, 28, "y22-03" },
                    { "L094", "NG044", null, 29, "nghiệp22-04" },
                    { "L095", "NG045", null, 30, "sản22-05" },
                    { "L096", "NG046", null, 31, "dụng22-01" },
                    { "L097", "NG047", null, 32, "nghiệp22-02" },
                    { "L098", "NG048", null, 33, "tầng22-03" },
                    { "L099", "NG049", null, 34, "dựng22-04" },
                    { "L100", "NG050", null, 25, "dựng22-05" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "password", "userName" },
                values: new object[,]
                {
                    { 1, "pass001", "user001" },
                    { 2, "pass002", "user002" },
                    { 3, "pass003", "user003" },
                    { 4, "pass004", "user004" },
                    { 5, "pass005", "user005" },
                    { 6, "pass006", "user006" },
                    { 7, "pass007", "user007" },
                    { 8, "pass008", "user008" },
                    { 9, "pass009", "user009" },
                    { 10, "pass010", "user010" },
                    { 11, "pass011", "user011" },
                    { 12, "pass012", "user012" },
                    { 13, "pass013", "user013" },
                    { 14, "pass014", "user014" },
                    { 15, "pass015", "user015" },
                    { 16, "pass016", "user016" },
                    { 17, "pass017", "user017" },
                    { 18, "pass018", "user018" },
                    { 19, "pass019", "user019" },
                    { 20, "pass020", "user020" },
                    { 21, "pass021", "user021" },
                    { 22, "pass022", "user022" },
                    { 23, "pass023", "user023" },
                    { 24, "pass024", "user024" },
                    { 25, "pass025", "user025" },
                    { 26, "pass026", "user026" },
                    { 27, "pass027", "user027" },
                    { 28, "pass028", "user028" },
                    { 29, "pass029", "user029" },
                    { 30, "pass030", "user030" },
                    { 31, "pass031", "user031" },
                    { 32, "pass032", "user032" },
                    { 33, "pass033", "user033" },
                    { 34, "pass034", "user034" },
                    { 35, "pass035", "user035" },
                    { 36, "pass036", "user036" },
                    { 37, "pass037", "user037" },
                    { 38, "pass038", "user038" },
                    { 39, "pass039", "user039" },
                    { 40, "pass040", "user040" },
                    { 41, "pass041", "user041" },
                    { 42, "pass042", "user042" },
                    { 43, "pass043", "user043" },
                    { 44, "pass044", "user044" },
                    { 45, "pass045", "user045" },
                    { 46, "pass046", "user046" },
                    { 47, "pass047", "user047" },
                    { 48, "pass048", "user048" },
                    { 49, "pass049", "user049" },
                    { 50, "pass050", "user050" },
                    { 51, "pass051", "user051" },
                    { 52, "pass052", "user052" },
                    { 53, "pass053", "user053" },
                    { 54, "pass054", "user054" },
                    { 55, "pass055", "user055" },
                    { 56, "pass056", "user056" },
                    { 57, "pass057", "user057" },
                    { 58, "pass058", "user058" },
                    { 59, "pass059", "user059" },
                    { 60, "pass060", "user060" },
                    { 61, "pass061", "user061" },
                    { 62, "pass062", "user062" },
                    { 63, "pass063", "user063" },
                    { 64, "pass064", "user064" },
                    { 65, "pass065", "user065" },
                    { 66, "pass066", "user066" },
                    { 67, "pass067", "user067" },
                    { 68, "pass068", "user068" },
                    { 69, "pass069", "user069" },
                    { 70, "pass070", "user070" },
                    { 71, "pass071", "user071" },
                    { 72, "pass072", "user072" },
                    { 73, "pass073", "user073" },
                    { 74, "pass074", "user074" },
                    { 75, "pass075", "user075" },
                    { 76, "pass076", "user076" },
                    { 77, "pass077", "user077" },
                    { 78, "pass078", "user078" },
                    { 79, "pass079", "user079" },
                    { 80, "pass080", "user080" },
                    { 81, "pass081", "user081" },
                    { 82, "pass082", "user082" },
                    { 83, "pass083", "user083" },
                    { 84, "pass084", "user084" },
                    { 85, "pass085", "user085" },
                    { 86, "pass086", "user086" },
                    { 87, "pass087", "user087" },
                    { 88, "pass088", "user088" },
                    { 89, "pass089", "user089" },
                    { 90, "pass090", "user090" },
                    { 91, "pass091", "user091" },
                    { 92, "pass092", "user092" },
                    { 93, "pass093", "user093" },
                    { 94, "pass094", "user094" },
                    { 95, "pass095", "user095" },
                    { 96, "pass096", "user096" },
                    { 97, "pass097", "user097" },
                    { 98, "pass098", "user098" },
                    { 99, "pass099", "user099" },
                    { 100, "pass100", "user100" }
                });

            migrationBuilder.InsertData(
                table: "Nganhs",
                columns: new[] { "manghanh", "makhoa", "tennganh" },
                values: new object[,]
                {
                    { "NG001", "CNTT", "Khoa học máy tính" },
                    { "NG002", "CNTT", "Hệ thống thông tin" },
                    { "NG003", "CNTT", "Kỹ thuật phần mềm" },
                    { "NG004", "CNTT", "An toàn thông tin" },
                    { "NG005", "CNTT", "Trí tuệ nhân tạo" },
                    { "NG006", "KT", "Quản trị kinh doanh" },
                    { "NG007", "KT", "Kế toán" },
                    { "NG008", "KT", "Tài chính ngân hàng" },
                    { "NG009", "KT", "Marketing" },
                    { "NG010", "KT", "Kinh tế đối ngoại" },
                    { "NG011", "NN", "Tiếng Anh" },
                    { "NG012", "NN", "Tiếng Nhật" },
                    { "NG013", "NN", "Tiếng Trung" },
                    { "NG014", "NN", "Tiếng Hàn" },
                    { "NG015", "NN", "Tiếng Pháp" },
                    { "NG016", "CK", "Cơ khí chế tạo máy" },
                    { "NG017", "CK", "Cơ khí động lực" },
                    { "NG018", "CK", "Cơ khí ô tô" },
                    { "NG019", "CK", "Cơ khí hàng không" },
                    { "NG020", "CK", "Cơ khí tự động hóa" },
                    { "NG021", "DTVT", "Điện tử" },
                    { "NG022", "DTVT", "Viễn thông" },
                    { "NG023", "DTVT", "Điện tử y sinh" },
                    { "NG024", "DTVT", "Kỹ thuật điều khiển" },
                    { "NG025", "DTVT", "Mạng máy tính" },
                    { "NG026", "Y", "Y khoa" },
                    { "NG027", "Y", "Răng hàm mặt" },
                    { "NG028", "Y", "Dược học" },
                    { "NG029", "Y", "Y tế công cộng" },
                    { "NG030", "Y", "Điều dưỡng" },
                    { "NG031", "LUAT", "Luật kinh tế" },
                    { "NG032", "LUAT", "Luật hành chính" },
                    { "NG033", "LUAT", "Luật dân sự" },
                    { "NG034", "LUAT", "Luật hình sự" },
                    { "NG035", "LUAT", "Luật quốc tế" },
                    { "NG036", "SP", "Sư phạm Toán" },
                    { "NG037", "SP", "Sư phạm Lý" },
                    { "NG038", "SP", "Sư phạm Hóa" },
                    { "NG039", "SP", "Sư phạm Sinh" },
                    { "NG040", "SP", "Sư phạm Văn" },
                    { "NG041", "NN2", "Nông học" },
                    { "NG042", "NN2", "Chăn nuôi" },
                    { "NG043", "NN2", "Thú y" },
                    { "NG044", "NN2", "Lâm nghiệp" },
                    { "NG045", "NN2", "Thủy sản" },
                    { "NG046", "XD", "Xây dựng dân dụng" },
                    { "NG047", "XD", "Xây dựng công nghiệp" },
                    { "NG048", "XD", "Kỹ thuật hạ tầng" },
                    { "NG049", "XD", "Kinh tế xây dựng" },
                    { "NG050", "XD", "Quản lý xây dựng" }
                });

            migrationBuilder.InsertData(
                table: "SinhViens",
                columns: new[] { "masv", "NgaySinh", "dc", "gt", "malop", "sdt", "tensv" },
                values: new object[,]
                {
                    { "SV001", new DateTime(1999, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "62 Đường 25, Cao Bằng", false, "L001", "0962770359", "Nguyễn Văn An" },
                    { "SV002", new DateTime(2000, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "23 Đường 20, Bắc Kạn", true, "L002", "0729079105", "Trần Thị Bình" },
                    { "SV003", new DateTime(2001, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "8 Đường 22, Bình Thuận", false, "L003", "0357062809", "Lê Văn Cường" },
                    { "SV004", new DateTime(2002, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "60 Đường 18, Hưng Yên", true, "L004", "0737125529", "Phạm Thị Dung" },
                    { "SV005", new DateTime(2003, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "76 Đường 42, Yên Bái", false, "L005", "0640060097", "Hoàng Văn Em" },
                    { "SV006", new DateTime(1998, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "50 Đường 34, Bình Thuận", true, "L006", "0769555889", "Vũ Thị Ất" },
                    { "SV007", new DateTime(1999, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "10 Đường 16, Quảng Bình", false, "L007", "0759368909", "Đặng Văn Giang" },
                    { "SV008", new DateTime(2000, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "34 Đường 26, Hà Tĩnh", true, "L008", "0789841179", "Bùi Thị Hương" },
                    { "SV009", new DateTime(2001, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "15 Đường 40, Cao Bằng", false, "L009", "0482533046", "Lý Văn Nam" },
                    { "SV010", new DateTime(2002, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "56 Đường 7, Bắc Giang", true, "L010", "0967805037", "Trịnh Thị Kim" },
                    { "SV011", new DateTime(2003, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "76 Đường 49, Hưng Yên", false, "L011", "0956842277", "Ngô Văn Long" },
                    { "SV012", new DateTime(1998, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "5 Đường 38, Đà Nẵng", true, "L012", "0883904370", "Đinh Thị Mai" },
                    { "SV013", new DateTime(1999, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "33 Đường 29, Trà Vinh", false, "L013", "0693688152", "Tô Văn Nam" },
                    { "SV014", new DateTime(2000, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "88 Đường 48, Đắk Lắk", true, "L014", "0893023408", "Lưu Thị Oanh" },
                    { "SV015", new DateTime(2001, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "18 Đường 30, Quảng Bình", false, "L015", "0987100297", "Hồ Văn Phúc" },
                    { "SV016", new DateTime(2002, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "52 Đường 46, Quảng Ninh", true, "L016", "0586104069", "Đỗ Thị Quỳnh" },
                    { "SV017", new DateTime(2003, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "5 Đường 12, Kon Tum", false, "L017", "0961137163", "Cao Văn Rạng" },
                    { "SV018", new DateTime(1998, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "56 Đường 9, Hải Dương", true, "L018", "0767036481", "Phan Thị Sáng" },
                    { "SV019", new DateTime(1999, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "3 Đường 10, Hà Nội", false, "L019", "0713993346", "Võ Văn Tài" },
                    { "SV020", new DateTime(2000, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "15 Đường 16, Thái Bình", true, "L020", "0926462362", "Lại Thị Uyên" },
                    { "SV021", new DateTime(2001, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "64 Đường 8, An Giang", false, "L021", "0357176921", "Dương Văn Việt" },
                    { "SV022", new DateTime(2002, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "74 Đường 37, Thái Nguyên", true, "L022", "0599752866", "Chu Thị Xuân" },
                    { "SV023", new DateTime(2003, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "43 Đường 15, Bình Định", false, "L023", "0421275472", "Mã Văn Yên" },
                    { "SV024", new DateTime(1998, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "74 Đường 38, Quảng Ninh", true, "L024", "0860486470", "Ôn Thị Zung" },
                    { "SV025", new DateTime(1999, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "91 Đường 34, TP.Hồ Chí Minh", false, "L025", "0526917956", "Thái Văn Anh" },
                    { "SV026", new DateTime(2000, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "3 Đường 18, Nam Định", true, "L026", "0396342760", "Lâm Thị Bảo" },
                    { "SV027", new DateTime(2001, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "44 Đường 7, Bình Thuận", false, "L027", "0368431166", "Kiều Văn Cát" },
                    { "SV028", new DateTime(2002, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "3 Đường 32, Quảng Nam", true, "L028", "0322698659", "Ung Thị Đào" },
                    { "SV029", new DateTime(2003, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "39 Đường 16, Cao Bằng", false, "L029", "0914014003", "Từ Văn Béo" },
                    { "SV030", new DateTime(1998, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "7 Đường 42, Vĩnh Phúc", true, "L030", "0889280528", "Khúc Thị Phượng" },
                    { "SV031", new DateTime(1999, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "94 Đường 28, Bắc Giang", false, "L031", "0471151576", "Tạ Văn Gấu" },
                    { "SV032", new DateTime(2000, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "63 Đường 26, Quảng Ngãi", true, "L032", "0996343439", "Khổng Thị Hoa" },
                    { "SV033", new DateTime(2001, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "4 Đường 14, Điện Biên", false, "L033", "0320884146", "Triệu Văn Mịch" },
                    { "SV034", new DateTime(2002, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "4 Đường 17, Bạc Liêu", true, "L034", "0916968511", "Lục Thị Khuyên" },
                    { "SV035", new DateTime(2003, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "29 Đường 14, Bình Phước", false, "L035", "0860487561", "Mã Văn Lâm" },
                    { "SV036", new DateTime(1998, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "9 Đường 31, Thừa Thiên Huế", true, "L036", "0618346773", "Bạch Thị Mây" },
                    { "SV037", new DateTime(1999, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "78 Đường 26, Hải Phòng", false, "L037", "0379580545", "Quách Văn Ngọc" },
                    { "SV038", new DateTime(2000, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "57 Đường 32, Quảng Ninh", true, "L038", "0870757255", "Yên Thị Ong" },
                    { "SV039", new DateTime(2001, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "22 Đường 48, Bình Thuận", false, "L039", "0777808529", "Hà Văn Phong" },
                    { "SV040", new DateTime(2002, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "25 Đường 26, Bạc Liêu", true, "L040", "0587231783", "Sầm Thị Quế" },
                    { "SV041", new DateTime(2003, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "65 Đường 22, Lạng Sơn", false, "L041", "0348646936", "Tôn Văn Rùa" },
                    { "SV042", new DateTime(1998, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "81 Đường 5, Tây Ninh", true, "L042", "0557971788", "Ấu Thị Sen" },
                    { "SV043", new DateTime(1999, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "63 Đường 24, Hà Nội", false, "L043", "0960019091", "Mai Văn Tùng" },
                    { "SV044", new DateTime(2000, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "66 Đường 32, Thái Nguyên", true, "L044", "0569588129", "Tô Thị Uyển" },
                    { "SV045", new DateTime(2001, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "2 Đường 45, Phú Thọ", false, "L045", "0919757117", "Diêu Văn Vinh" },
                    { "SV046", new DateTime(2002, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "21 Đường 9, Quảng Nam", true, "L046", "0489072672", "Gia Thị Mai" },
                    { "SV047", new DateTime(2003, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "87 Đường 21, Đắk Lắk", false, "L047", "0463635818", "Nông Văn Xuân" },
                    { "SV048", new DateTime(1998, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "5 Đường 7, Kiên Giang", true, "L048", "0568127356", "Ứng Thị Yến" },
                    { "SV049", new DateTime(1999, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "79 Đường 36, Phú Thọ", false, "L049", "0853123078", "Lương Văn Lượng" },
                    { "SV050", new DateTime(2000, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "19 Đường 7, Hà Giang", true, "L050", "0532030117", "Mạc Thị Ánh" },
                    { "SV051", new DateTime(2001, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "30 Đường 14, Nghệ An", false, "L051", "0756979140", "Dương Văn Bách" },
                    { "SV052", new DateTime(2002, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "22 Đường 28, Bắc Giang", true, "L052", "0378953179", "Lương Thị Cúc" },
                    { "SV053", new DateTime(2003, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "77 Đường 9, Long An", false, "L053", "0610997977", "Châu Văn Dũng" },
                    { "SV054", new DateTime(1998, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "45 Đường 3, Hưng Yên", true, "L054", "0594127405", "Ân Thị Êm" },
                    { "SV055", new DateTime(1999, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "28 Đường 45, Sóc Trăng", false, "L055", "0586370968", "Tống Văn Phát" },
                    { "SV056", new DateTime(2000, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "85 Đường 43, Nam Định", true, "L056", "0365562890", "Mùa Thị Gió" },
                    { "SV057", new DateTime(2001, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "17 Đường 28, Phú Yên", false, "L057", "0781743444", "Sơn Văn Hải" },
                    { "SV058", new DateTime(2002, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "96 Đường 39, Vĩnh Long", true, "L058", "0487208890", "Mông Thị Ỉn" },
                    { "SV059", new DateTime(2003, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "24 Đường 8, Cao Bằng", false, "L059", "0787497875", "Khuất Văn Khang" },
                    { "SV060", new DateTime(1998, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "65 Đường 16, Quảng Bình", true, "L060", "0975717005", "Bế Thị Lan" },
                    { "SV061", new DateTime(1999, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "30 Đường 49, Đồng Nai", false, "L061", "0575841543", "Tiêu Văn Minh" },
                    { "SV062", new DateTime(2000, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "47 Đường 39, Phú Thọ", true, "L062", "0379226364", "Chu Thị Ngần" },
                    { "SV063", new DateTime(2001, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "14 Đường 41, Bắc Giang", false, "L063", "0925419194", "Âu Văn Ồn" },
                    { "SV064", new DateTime(2002, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "71 Đường 18, Kon Tum", true, "L064", "0818745862", "Đàm Thị Phiến" },
                    { "SV065", new DateTime(2003, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "25 Đường 49, Sóc Trăng", false, "L065", "0364218615", "Hứa Văn Quang" },
                    { "SV066", new DateTime(1998, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "79 Đường 31, Tây Ninh", true, "L066", "0326574289", "Đoàn Văn Lực" },
                    { "SV067", new DateTime(1999, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "39 Đường 29, Hậu Giang", false, "L067", "0384827674", "Khiếu Văn Sáu" },
                    { "SV068", new DateTime(2000, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "49 Đường 30, Trà Vinh", true, "L068", "0640018737", "Tiếp Thị Tám" },
                    { "SV069", new DateTime(2001, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "64 Đường 40, Nghệ An", false, "L069", "0727750436", "Trinh Huyền Trình" },
                    { "SV070", new DateTime(2002, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "79 Đường 44, Cần Thơ", true, "L070", "0479575779", "Yếu Thị Vân" },
                    { "SV071", new DateTime(2003, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "21 Đường 14, Thái Nguyên", false, "L071", "0940301389", "Lê Huyền Nhi" },
                    { "SV072", new DateTime(1998, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "75 Đường 5, Ninh Bình", true, "L072", "0410622460", "Lê Thị Yêu" },
                    { "SV073", new DateTime(1999, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "39 Đường 43, Kiên Giang", false, "L073", "0428793399", "Lãnh Văn An" },
                    { "SV074", new DateTime(2000, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "82 Đường 10, Hưng Yên", true, "L074", "0980345753", "Cung Thị Anh" },
                    { "SV075", new DateTime(2001, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "70 Đường 19, Trà Vinh", false, "L075", "0398677375", "Từ Văn Băng" },
                    { "SV076", new DateTime(2002, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "32 Đường 4, Lạng Sơn", true, "L076", "0948358433", "Nùng Thị Cầm" },
                    { "SV077", new DateTime(2003, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "71 Đường 48, Gia Lai", false, "L077", "0481003673", "Cầm Văn Đỉnh" },
                    { "SV078", new DateTime(1998, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "3 Đường 28, Thừa Thiên Huế", true, "L078", "0661252533", "Lô Thị Eo" },
                    { "SV079", new DateTime(1999, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "8 Đường 19, Hà Nội", false, "L079", "0639617604", "Thạch Văn Phòng" },
                    { "SV080", new DateTime(2000, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "71 Đường 37, Bình Dương", true, "L080", "0382825165", "Sinh Thị Giọt" },
                    { "SV081", new DateTime(2001, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "80 Đường 46, Cao Bằng", false, "L081", "0882791685", "Thi Văn Hùng" },
                    { "SV082", new DateTime(2002, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "23 Đường 7, Sóc Trăng", true, "L082", "0915960950", "Ngô Văn Minh" },
                    { "SV083", new DateTime(2003, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "81 Đường 2, Khánh Hòa", false, "L083", "0598754385", "Đan Văn Kẻ" },
                    { "SV084", new DateTime(1998, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "69 Đường 29, Hải Dương", true, "L084", "0358057441", "Nguyễn Thị Mừng" },
                    { "SV085", new DateTime(1999, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "24 Đường 8, Bắc Ninh", false, "L085", "0999100661", "Múa Văn Mồm" },
                    { "SV086", new DateTime(2000, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "62 Đường 31, Quảng Trị", true, "L086", "0893501485", "Đình Thị Nghi" },
                    { "SV087", new DateTime(2001, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "25 Đường 10, Lâm Đồng", false, "L087", "0458635282", "Đinh Văn Ông" },
                    { "SV088", new DateTime(2002, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "71 Đường 35, Long An", true, "L088", "0862974478", "Hai Thị Phấn" },
                    { "SV089", new DateTime(2003, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "37 Đường 41, Phú Thọ", false, "L089", "0449364129", "Ba Văn Quặp" },
                    { "SV090", new DateTime(1998, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "96 Đường 31, Hà Nội", true, "L090", "0387232053", "Đỗ Văn Dũng" },
                    { "SV091", new DateTime(1999, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "40 Đường 35, Ninh Bình", false, "L091", "0364639433", "Nguyễn Văn Năm" },
                    { "SV092", new DateTime(2000, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "37 Đường 44, Tây Ninh", true, "L092", "0950494283", "Nguyễn Thị Tô" },
                    { "SV093", new DateTime(2001, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "45 Đường 28, Bạc Liêu", false, "L093", "0555864691", "Vũ Văn Bảy" },
                    { "SV094", new DateTime(2002, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "79 Đường 5, Hưng Yên", true, "L094", "0626529487", "Vũ Thị Út" },
                    { "SV095", new DateTime(2003, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "57 Đường 27, Bến Tre", false, "L095", "0792508190", "Tào Nhọc Nhi" },
                    { "SV096", new DateTime(1998, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "1 Đường 47, Quảng Ninh", true, "L096", "0948195397", "Nguyễn Văn Mười" },
                    { "SV097", new DateTime(1999, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "95 Đường 42, Cao Bằng", false, "L097", "0998523268", "Lê Văn An" },
                    { "SV098", new DateTime(2000, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "7 Đường 42, Ninh Thuận", true, "L098", "0542475848", "Ngọ Thị Áp" },
                    { "SV099", new DateTime(2001, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "62 Đường 9, Lâm Đồng", false, "L099", "0559452370", "Vạn Văn Bọt" },
                    { "SV100", new DateTime(2002, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "33 Đường 32, Đắk Nông", true, "L100", "0647291856", "Triệu Thị Trinh" }
                });

            migrationBuilder.InsertData(
                table: "HoSos",
                columns: new[] { "mahoso", "Ngaysinh", "cccd", "dantoc", "dc", "email", "gt", "msv", "noisinh", "sdt", "tenkhoa", "tenlop", "tennghanh", "tensv", "tongiao", "trangthai" },
                values: new object[,]
                {
                    { "HS001", new DateTime(1999, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "3377212548", "Ê Đê", "61 Đường 20, Hà Tĩnh", "nguyenvanan1@student.edu.vn", false, "SV001", "Bình Thuận", "0348276140", "Khoa Công nghệ Thông tin", "tính21-01", "Khoa học máy tính", "Nguyễn Văn An", "Không", "Đang học" },
                    { "HS002", new DateTime(2000, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "4003586505", "Phù Lá", "38 Đường 38, Kiên Giang", "tranthibinh2@student.edu.vn", true, "SV002", "Quảng Ninh", "0756062261", "Khoa Công nghệ Thông tin", "tin21-02", "Hệ thống thông tin", "Trần Thị Bình", "Không", "Đang học" },
                    { "HS003", new DateTime(2001, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "6587448012", "Giáy", "20 Đường 28, Thanh Hóa", "levancuong3@student.edu.vn", false, "SV003", "Vĩnh Phúc", "0628442698", "Khoa Công nghệ Thông tin", "mềm21-03", "Kỹ thuật phần mềm", "Lê Văn Cường", "Không", "Đang học" },
                    { "HS004", new DateTime(2002, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "9419970756", "Ra Glai", "7 Đường 23, Hòa Bình", "phamthidung4@student.edu.vn", true, "SV004", "Quảng Ngãi", "0433698068", "Khoa Công nghệ Thông tin", "tin21-04", "An toàn thông tin", "Phạm Thị Dung", "Không", "Đang học" },
                    { "HS005", new DateTime(2003, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "2222554579", "Chu Ru", "23 Đường 9, Gia Lai", "hoangvanem5@student.edu.vn", false, "SV005", "Vĩnh Phúc", "0467304041", "Khoa Công nghệ Thông tin", "tạo21-05", "Trí tuệ nhân tạo", "Hoàng Văn Em", "Không", "Đang học" },
                    { "HS006", new DateTime(1998, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "1532942692", "Ba Na", "83 Đường 10, Thái Nguyên", "vuthiat6@student.edu.vn", true, "SV006", "Đà Nẵng", "0491337299", "Khoa Kinh tế", "doanh21-01", "Quản trị kinh doanh", "Vũ Thị Ất", "Không", "Đang học" },
                    { "HS007", new DateTime(1999, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "1633779646", "Ro Mam", "12 Đường 35, Hải Phòng", "đangvangiang7@student.edu.vn", false, "SV007", "Bà Rịa-Vũng Tàu", "0433119295", "Khoa Kinh tế", "toán21-02", "Kế toán", "Đặng Văn Giang", "Không", "Đang học" },
                    { "HS008", new DateTime(2000, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "9857043840", "Cơ Tu", "14 Đường 17, Phú Yên", "buithihuong8@student.edu.vn", true, "SV008", "Yên Bái", "0393110068", "Khoa Kinh tế", "hàng21-03", "Tài chính ngân hàng", "Bùi Thị Hương", "Không", "Đang học" },
                    { "HS009", new DateTime(2001, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "1286240766", "Sán Dìu", "1 Đường 31, Cà Mau", "lyvannam9@student.edu.vn", false, "SV009", "Kon Tum", "0514771802", "Khoa Kinh tế", "Marketing21-04", "Marketing", "Lý Văn Nam", "Không", "Đang học" },
                    { "HS010", new DateTime(2002, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8910624999", "Co", "59 Đường 3, Ninh Thuận", "trinhthikim10@student.edu.vn", true, "SV010", "Đồng Tháp", "0446675902", "Khoa Kinh tế", "ngoại21-05", "Kinh tế đối ngoại", "Trịnh Thị Kim", "Không", "Đang học" },
                    { "HS011", new DateTime(2003, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "2221935772", "Xơ Đăng", "2 Đường 4, Kon Tum", "ngovanlong11@student.edu.vn", false, "SV011", "Vĩnh Phúc", "0678648596", "Khoa Ngoại ngữ", "Anh21-01", "Tiếng Anh", "Ngô Văn Long", "Không", "Đang học" },
                    { "HS012", new DateTime(1998, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "1156599435", "Xtiêng", "36 Đường 35, Hải Dương", "đinhthimai12@student.edu.vn", true, "SV012", "Khánh Hòa", "0987742369", "Khoa Ngoại ngữ", "Nhật21-02", "Tiếng Nhật", "Đinh Thị Mai", "Không", "Đang học" },
                    { "HS013", new DateTime(1999, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "6189453601", "Nùng", "12 Đường 37, Nghệ An", "tovannam13@student.edu.vn", false, "SV013", "An Giang", "0672995364", "Khoa Ngoại ngữ", "Trung21-03", "Tiếng Trung", "Tô Văn Nam", "Không", "Đang học" },
                    { "HS014", new DateTime(2000, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "3421381054", "Mnông", "95 Đường 30, Bình Định", "luuthioanh14@student.edu.vn", true, "SV014", "Đắk Lắk", "0959001097", "Khoa Ngoại ngữ", "Hàn21-04", "Tiếng Hàn", "Lưu Thị Oanh", "Không", "Đang học" },
                    { "HS015", new DateTime(2001, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "1136387948", "Tày", "88 Đường 35, Vĩnh Phúc", "hovanphuc15@student.edu.vn", false, "SV015", "Quảng Ninh", "0850226247", "Khoa Ngoại ngữ", "Pháp21-05", "Tiếng Pháp", "Hồ Văn Phúc", "Không", "Đang học" },
                    { "HS016", new DateTime(2002, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "4922399226", "Dao", "92 Đường 47, Quảng Trị", "đothiquynh16@student.edu.vn", true, "SV016", "Quảng Trị", "0936661445", "Khoa Cơ khí", "máy21-01", "Cơ khí chế tạo máy", "Đỗ Thị Quỳnh", "Không", "Đang học" },
                    { "HS017", new DateTime(2003, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "5256489583", "Mường", "17 Đường 37, Tây Ninh", "caovanrang17@student.edu.vn", false, "SV017", "TP.Hồ Chí Minh", "0899810115", "Khoa Cơ khí", "lực21-02", "Cơ khí động lực", "Cao Văn Rạng", "Không", "Đang học" },
                    { "HS018", new DateTime(1998, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "2166828761", "Hrê", "67 Đường 42, Tuyên Quang", "phanthisang18@student.edu.vn", true, "SV018", "Bình Định", "0692142197", "Khoa Cơ khí", "tô21-03", "Cơ khí ô tô", "Phan Thị Sáng", "Không", "Đang học" },
                    { "HS019", new DateTime(1999, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9755236440", "Chơ Ro", "59 Đường 34, Cà Mau", "vovantai19@student.edu.vn", false, "SV019", "Nam Định", "0371062444", "Khoa Cơ khí", "không21-04", "Cơ khí hàng không", "Võ Văn Tài", "Không", "Đang học" },
                    { "HS020", new DateTime(2000, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "1155376304", "Kinh", "58 Đường 27, Bình Phước", "laithiuyen20@student.edu.vn", true, "SV020", "Hậu Giang", "0972221869", "Khoa Cơ khí", "hóa21-05", "Cơ khí tự động hóa", "Lại Thị Uyên", "Không", "Tạm dừng" },
                    { "HS021", new DateTime(2001, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "5708179355", "Si La", "33 Đường 14, Trà Vinh", "duongvanviet21@student.edu.vn", false, "SV021", "Long An", "0982222170", "Khoa Điện tử Viễn thông", "tử21-01", "Điện tử", "Dương Văn Việt", "Không", "Đang học" },
                    { "HS022", new DateTime(2002, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "8150245043", "Cơ Tu", "13 Đường 8, Bạc Liêu", "chuthixuan22@student.edu.vn", true, "SV022", "Yên Bái", "0692530085", "Khoa Điện tử Viễn thông", "thông21-02", "Viễn thông", "Chu Thị Xuân", "Không", "Đang học" },
                    { "HS023", new DateTime(2003, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "4944641751", "Rơ Măm", "68 Đường 14, Hà Nam", "mavanyen23@student.edu.vn", false, "SV023", "Quảng Trị", "0495885734", "Khoa Điện tử Viễn thông", "sinh21-03", "Điện tử y sinh", "Mã Văn Yên", "Không", "Đang học" },
                    { "HS024", new DateTime(1998, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "2533019285", "Si La", "55 Đường 18, Vĩnh Phúc", "onthizung24@student.edu.vn", true, "SV024", "Bà Rịa-Vũng Tàu", "0477907709", "Khoa Điện tử Viễn thông", "khiển21-04", "Kỹ thuật điều khiển", "Ôn Thị Zung", "Không", "Đang học" },
                    { "HS025", new DateTime(1999, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "1902367686", "Kinh", "62 Đường 20, Cần Thơ", "thaivananh25@student.edu.vn", false, "SV025", "Bà Rịa-Vũng Tàu", "0827319584", "Khoa Điện tử Viễn thông", "tính21-05", "Mạng máy tính", "Thái Văn Anh", "Không", "Đang học" },
                    { "HS026", new DateTime(2000, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "6119605760", "Gia Rai", "6 Đường 30, Ninh Bình", "lamthibao26@student.edu.vn", true, "SV026", "Hậu Giang", "0658118476", "Khoa Y học", "khoa21-01", "Y khoa", "Lâm Thị Bảo", "Không", "Đang học" },
                    { "HS027", new DateTime(2001, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "1359474011", "Ra Glai", "15 Đường 30, Sóc Trăng", "kieuvancat27@student.edu.vn", false, "SV027", "Hưng Yên", "0679093567", "Khoa Y học", "mặt21-02", "Răng hàm mặt", "Kiều Văn Cát", "Không", "Đang học" },
                    { "HS028", new DateTime(2002, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "3212683300", "Mảng", "78 Đường 33, Hà Nội", "ungthiđao28@student.edu.vn", true, "SV028", "Bạc Liêu", "0423058219", "Khoa Y học", "học21-03", "Dược học", "Ung Thị Đào", "Không", "Đang học" },
                    { "HS029", new DateTime(2003, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "6721171629", "Mạ", "27 Đường 15, Gia Lai", "tuvanbeo29@student.edu.vn", false, "SV029", "Hà Nội", "0631464826", "Khoa Y học", "cộng21-04", "Y tế công cộng", "Từ Văn Béo", "Không", "Đang học" },
                    { "HS030", new DateTime(1998, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "3993010805", "Co", "3 Đường 13, Hậu Giang", "khucthiphuong30@student.edu.vn", true, "SV030", "Trà Vinh", "0370555709", "Khoa Y học", "dưỡng21-05", "Điều dưỡng", "Khúc Thị Phượng", "Không", "Tốt nghiệp" },
                    { "HS031", new DateTime(1999, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "4813783798", "Tày", "16 Đường 40, Hà Nội", "tavangau31@student.edu.vn", false, "SV031", "Hà Nam", "0640101922", "Khoa Luật", "tế21-01", "Luật kinh tế", "Tạ Văn Gấu", "Không", "Đang học" },
                    { "HS032", new DateTime(2000, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "8212991315", "Mnông", "72 Đường 17, Khánh Hòa", "khongthihoa32@student.edu.vn", true, "SV032", "Lai Châu", "0334601552", "Khoa Luật", "chính21-02", "Luật hành chính", "Khổng Thị Hoa", "Không", "Đang học" },
                    { "HS033", new DateTime(2001, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "6157112307", "Ơ Đu", "9 Đường 31, Quảng Nam", "trieuvanmich33@student.edu.vn", false, "SV033", "Lạng Sơn", "0822084717", "Khoa Luật", "sự21-03", "Luật dân sự", "Triệu Văn Mịch", "Không", "Đang học" },
                    { "HS034", new DateTime(2002, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "3710979355", "Mường", "77 Đường 7, Lâm Đồng", "lucthikhuyen34@student.edu.vn", true, "SV034", "Bạc Liêu", "0675441384", "Khoa Luật", "sự21-04", "Luật hình sự", "Lục Thị Khuyên", "Không", "Đang học" },
                    { "HS035", new DateTime(2003, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "1532855477", "Pu Péo", "78 Đường 27, Bắc Giang", "mavanlam35@student.edu.vn", false, "SV035", "Hà Giang", "0657980401", "Khoa Luật", "tế21-05", "Luật quốc tế", "Mã Văn Lâm", "Không", "Đang học" },
                    { "HS036", new DateTime(1998, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "3605312022", "Giáy", "45 Đường 36, Gia Lai", "bachthimay36@student.edu.vn", true, "SV036", "Ninh Thuận", "0863306631", "Khoa Sư phạm", "Toán21-01", "Sư phạm Toán", "Bạch Thị Mây", "Không", "Đang học" },
                    { "HS037", new DateTime(1999, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "1668852832", "Ê Đê", "51 Đường 29, Gia Lai", "quachvanngoc37@student.edu.vn", false, "SV037", "TP.Hồ Chí Minh", "0780229383", "Khoa Sư phạm", "Lý21-02", "Sư phạm Lý", "Quách Văn Ngọc", "Không", "Đang học" },
                    { "HS038", new DateTime(2000, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "1359072066", "Gié Triêng", "79 Đường 42, Bình Dương", "yenthiong38@student.edu.vn", true, "SV038", "Quảng Trị", "0766822637", "Khoa Sư phạm", "Hóa21-03", "Sư phạm Hóa", "Yên Thị Ong", "Không", "Đang học" },
                    { "HS039", new DateTime(2001, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "7380316112", "Thổ", "57 Đường 34, Tây Ninh", "havanphong39@student.edu.vn", false, "SV039", "Thanh Hóa", "0396394596", "Khoa Sư phạm", "Sinh21-04", "Sư phạm Sinh", "Hà Văn Phong", "Không", "Đang học" },
                    { "HS040", new DateTime(2002, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "3509917037", "Si La", "37 Đường 2, Lai Châu", "samthique40@student.edu.vn", true, "SV040", "Bạc Liêu", "0396278848", "Khoa Sư phạm", "Văn21-05", "Sư phạm Văn", "Sầm Thị Quế", "Không", "Tạm dừng" },
                    { "HS041", new DateTime(2003, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6923048212", "Lào", "89 Đường 46, Kiên Giang", "tonvanrua41@student.edu.vn", false, "SV041", "Hà Nội", "0696618611", "Khoa Nông nghiệp", "học21-01", "Nông học", "Tôn Văn Rùa", "Không", "Đang học" },
                    { "HS042", new DateTime(1998, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "2029393045", "Hrê", "12 Đường 49, Phú Thọ", "authisen42@student.edu.vn", true, "SV042", "Sóc Trăng", "0869425705", "Khoa Nông nghiệp", "nuôi21-02", "Chăn nuôi", "Ấu Thị Sen", "Không", "Đang học" },
                    { "HS043", new DateTime(1999, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "1731187123", "Hrê", "1 Đường 24, Bến Tre", "maivantung43@student.edu.vn", false, "SV043", "An Giang", "0355584097", "Khoa Nông nghiệp", "y21-03", "Thú y", "Mai Văn Tùng", "Không", "Đang học" },
                    { "HS044", new DateTime(2000, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "7718454845", "Bru-Vân Kiều", "55 Đường 39, Thừa Thiên Huế", "tothiuyen44@student.edu.vn", true, "SV044", "Nghệ An", "0746288532", "Khoa Nông nghiệp", "nghiệp21-04", "Lâm nghiệp", "Tô Thị Uyển", "Không", "Đang học" },
                    { "HS045", new DateTime(2001, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "6567346405", "Dao", "80 Đường 45, Lai Châu", "dieuvanvinh45@student.edu.vn", false, "SV045", "Long An", "0630115782", "Khoa Nông nghiệp", "sản21-05", "Thủy sản", "Diêu Văn Vinh", "Không", "Đang học" },
                    { "HS046", new DateTime(2002, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "2364638371", "Kháng", "4 Đường 46, Đà Nẵng", "giathimai46@student.edu.vn", true, "SV046", "Nam Định", "0588557816", "Khoa Xây dựng", "dụng21-01", "Xây dựng dân dụng", "Gia Thị Mai", "Không", "Đang học" },
                    { "HS047", new DateTime(2003, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "7400539717", "La Ha", "34 Đường 22, Thừa Thiên Huế", "nongvanxuan47@student.edu.vn", false, "SV047", "Bình Phước", "0815695381", "Khoa Xây dựng", "nghiệp21-02", "Xây dựng công nghiệp", "Nông Văn Xuân", "Không", "Đang học" },
                    { "HS048", new DateTime(1998, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "8719608797", "La Hủ", "26 Đường 34, Cao Bằng", "ungthiyen48@student.edu.vn", true, "SV048", "Khánh Hòa", "0616851385", "Khoa Xây dựng", "tầng21-03", "Kỹ thuật hạ tầng", "Ứng Thị Yến", "Không", "Đang học" },
                    { "HS049", new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "8862673104", "Chứt", "29 Đường 37, Vĩnh Phúc", "luongvanluong49@student.edu.vn", false, "SV049", "Hưng Yên", "0612792775", "Khoa Xây dựng", "dựng21-04", "Kinh tế xây dựng", "Lương Văn Lượng", "Không", "Đang học" },
                    { "HS050", new DateTime(2000, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "5997808218", "Ro Mam", "16 Đường 29, An Giang", "macthianh50@student.edu.vn", true, "SV050", "Tây Ninh", "0645130193", "Khoa Xây dựng", "dựng21-05", "Quản lý xây dựng", "Mạc Thị Ánh", "Không", "Đang học" },
                    { "HS051", new DateTime(2001, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "1679499832", "Khmer", "24 Đường 33, Đồng Tháp", "duongvanbach51@student.edu.vn", false, "SV051", "Thái Nguyên", "0339170057", "Khoa Công nghệ Thông tin", "tính22-01", "Khoa học máy tính", "Dương Văn Bách", "Không", "Đang học" },
                    { "HS052", new DateTime(2002, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "7121262169", "Ê Đê", "83 Đường 8, Bạc Liêu", "luongthicuc52@student.edu.vn", true, "SV052", "Sóc Trăng", "0955278002", "Khoa Công nghệ Thông tin", "tin22-02", "Hệ thống thông tin", "Lương Thị Cúc", "Không", "Đang học" },
                    { "HS053", new DateTime(2003, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "5206589372", "Rơ Măm", "20 Đường 26, Phú Yên", "chauvandung53@student.edu.vn", false, "SV053", "Long An", "0659254985", "Khoa Công nghệ Thông tin", "mềm22-03", "Kỹ thuật phần mềm", "Châu Văn Dũng", "Không", "Đang học" },
                    { "HS054", new DateTime(1998, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "5945667333", "Ro Mam", "35 Đường 26, Đắk Nông", "anthiem54@student.edu.vn", true, "SV054", "Bến Tre", "0494032285", "Khoa Công nghệ Thông tin", "tin22-04", "An toàn thông tin", "Ân Thị Êm", "Không", "Đang học" },
                    { "HS055", new DateTime(1999, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "1470007942", "Nùng", "27 Đường 37, Trà Vinh", "tongvanphat55@student.edu.vn", false, "SV055", "Tiền Giang", "0557823681", "Khoa Công nghệ Thông tin", "tạo22-05", "Trí tuệ nhân tạo", "Tống Văn Phát", "Không", "Đang học" },
                    { "HS056", new DateTime(2000, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "5754001208", "Cơ Tu", "90 Đường 23, Tây Ninh", "muathigio56@student.edu.vn", true, "SV056", "Nghệ An", "0588311827", "Khoa Kinh tế", "doanh22-01", "Quản trị kinh doanh", "Mùa Thị Gió", "Không", "Đang học" },
                    { "HS057", new DateTime(2001, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "7718033473", "Kinh", "92 Đường 40, Nam Định", "sonvanhai57@student.edu.vn", false, "SV057", "Hòa Bình", "0636999405", "Khoa Kinh tế", "toán22-02", "Kế toán", "Sơn Văn Hải", "Không", "Đang học" },
                    { "HS058", new DateTime(2002, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "9424221171", "Pu Péo", "10 Đường 13, Vĩnh Long", "mongthiin58@student.edu.vn", true, "SV058", "Hà Nam", "0625025709", "Khoa Kinh tế", "hàng22-03", "Tài chính ngân hàng", "Mông Thị Ỉn", "Không", "Đang học" },
                    { "HS059", new DateTime(2003, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "7114484458", "Cơ Ho", "94 Đường 31, Thái Bình", "khuatvankhang59@student.edu.vn", false, "SV059", "Đồng Tháp", "0558502929", "Khoa Kinh tế", "Marketing22-04", "Marketing", "Khuất Văn Khang", "Không", "Đang học" },
                    { "HS060", new DateTime(1998, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "7770067344", "Lào", "20 Đường 40, Bắc Giang", "bethilan60@student.edu.vn", true, "SV060", "Lâm Đồng", "0898240287", "Khoa Kinh tế", "ngoại22-05", "Kinh tế đối ngoại", "Bế Thị Lan", "Không", "Tạm dừng" },
                    { "HS061", new DateTime(1999, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "4251430278", "Hoa", "95 Đường 19, Lạng Sơn", "tieuvanminh61@student.edu.vn", false, "SV061", "Hưng Yên", "0541478143", "Khoa Ngoại ngữ", "Anh22-01", "Tiếng Anh", "Tiêu Văn Minh", "Không", "Đang học" },
                    { "HS062", new DateTime(2000, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "2867740496", "Lào", "39 Đường 43, Hà Nội", "chuthingan62@student.edu.vn", true, "SV062", "Nghệ An", "0793881160", "Khoa Ngoại ngữ", "Nhật22-02", "Tiếng Nhật", "Chu Thị Ngần", "Không", "Đang học" },
                    { "HS063", new DateTime(2001, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9600192324", "Bru-Vân Kiều", "5 Đường 3, Bạc Liêu", "auvanon63@student.edu.vn", false, "SV063", "Vĩnh Long", "0547487184", "Khoa Ngoại ngữ", "Trung22-03", "Tiếng Trung", "Âu Văn Ồn", "Không", "Đang học" },
                    { "HS064", new DateTime(2002, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "3966670064", "Mảng", "14 Đường 33, Hòa Bình", "đamthiphien64@student.edu.vn", true, "SV064", "Hòa Bình", "0819992083", "Khoa Ngoại ngữ", "Hàn22-04", "Tiếng Hàn", "Đàm Thị Phiến", "Không", "Đang học" },
                    { "HS065", new DateTime(2003, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "8381951142", "Kinh", "84 Đường 22, Bình Thuận", "huavanquang65@student.edu.vn", false, "SV065", "Thanh Hóa", "0834437730", "Khoa Ngoại ngữ", "Pháp22-05", "Tiếng Pháp", "Hứa Văn Quang", "Không", "Đang học" },
                    { "HS066", new DateTime(1998, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "9502711759", "Mường", "93 Đường 16, Kiên Giang", "đoanvanluc66@student.edu.vn", true, "SV066", "An Giang", "0495300118", "Khoa Cơ khí", "máy22-01", "Cơ khí chế tạo máy", "Đoàn Văn Lực", "Không", "Đang học" },
                    { "HS067", new DateTime(1999, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "1868532153", "Ngái", "22 Đường 37, Đồng Nai", "khieuvansau67@student.edu.vn", false, "SV067", "Bình Định", "0422795372", "Khoa Cơ khí", "lực22-02", "Cơ khí động lực", "Khiếu Văn Sáu", "Không", "Đang học" },
                    { "HS068", new DateTime(2000, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "7156419285", "Tà Ôi", "9 Đường 11, Quảng Bình", "tiepthitam68@student.edu.vn", true, "SV068", "Phú Yên", "0470911052", "Khoa Cơ khí", "tô22-03", "Cơ khí ô tô", "Tiếp Thị Tám", "Không", "Đang học" },
                    { "HS069", new DateTime(2001, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "4436658155", "Phù Lá", "63 Đường 36, Bạc Liêu", "trinhhuyentrinh69@student.edu.vn", false, "SV069", "Kon Tum", "0485179715", "Khoa Cơ khí", "không22-04", "Cơ khí hàng không", "Trinh Huyền Trình", "Không", "Đang học" },
                    { "HS070", new DateTime(2002, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "7102413901", "Pà Thẻn", "55 Đường 11, Khánh Hòa", "yeuthivan70@student.edu.vn", true, "SV070", "Kon Tum", "0513102809", "Khoa Cơ khí", "hóa22-05", "Cơ khí tự động hóa", "Yếu Thị Vân", "Không", "Đang học" },
                    { "HS071", new DateTime(2003, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "3411606442", "Ra Glai", "78 Đường 12, Đắk Nông", "lehuyennhi71@student.edu.vn", false, "SV071", "Khánh Hòa", "0681124483", "Khoa Điện tử Viễn thông", "tử22-01", "Điện tử", "Lê Huyền Nhi", "Không", "Đang học" },
                    { "HS072", new DateTime(1998, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "3350560519", "Lào", "75 Đường 6, Long An", "lethiyeu72@student.edu.vn", true, "SV072", "Phú Thọ", "0388779834", "Khoa Điện tử Viễn thông", "thông22-02", "Viễn thông", "Lê Thị Yêu", "Không", "Đang học" },
                    { "HS073", new DateTime(1999, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "6846138309", "Kinh", "78 Đường 33, Kiên Giang", "lanhvanan73@student.edu.vn", false, "SV073", "Lâm Đồng", "0735508351", "Khoa Điện tử Viễn thông", "sinh22-03", "Điện tử y sinh", "Lãnh Văn An", "Không", "Đang học" },
                    { "HS074", new DateTime(2000, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "6324209732", "Ba Na", "64 Đường 47, Tiền Giang", "cungthianh74@student.edu.vn", true, "SV074", "Cao Bằng", "0935454051", "Khoa Điện tử Viễn thông", "khiển22-04", "Kỹ thuật điều khiển", "Cung Thị Anh", "Không", "Đang học" },
                    { "HS075", new DateTime(2001, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "8224430388", "Hmong", "29 Đường 23, Hà Nam", "tuvanbang75@student.edu.vn", false, "SV075", "Lâm Đồng", "0895452028", "Khoa Điện tử Viễn thông", "tính22-05", "Mạng máy tính", "Từ Văn Băng", "Không", "Đang học" },
                    { "HS076", new DateTime(2002, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "9860771226", "Pà Thẻn", "39 Đường 23, Ninh Bình", "nungthicam76@student.edu.vn", true, "SV076", "Lạng Sơn", "0322354907", "Khoa Y học", "khoa22-01", "Y khoa", "Nùng Thị Cầm", "Không", "Đang học" },
                    { "HS077", new DateTime(2003, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9805155353", "Xtiêng", "81 Đường 23, Ninh Bình", "camvanđinh77@student.edu.vn", false, "SV077", "Hải Dương", "0493228051", "Khoa Y học", "mặt22-02", "Răng hàm mặt", "Cầm Văn Đỉnh", "Không", "Đang học" },
                    { "HS078", new DateTime(1998, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7300935321", "Giáy", "60 Đường 19, Hải Phòng", "lothieo78@student.edu.vn", true, "SV078", "Ninh Thuận", "0455482405", "Khoa Y học", "học22-03", "Dược học", "Lô Thị Eo", "Không", "Đang học" },
                    { "HS079", new DateTime(1999, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "5088719012", "Chu Ru", "43 Đường 28, Hòa Bình", "thachvanphong79@student.edu.vn", false, "SV079", "Ninh Thuận", "0531553665", "Khoa Y học", "cộng22-04", "Y tế công cộng", "Thạch Văn Phòng", "Không", "Đang học" },
                    { "HS080", new DateTime(2000, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "8901625169", "La Ha", "26 Đường 32, Trà Vinh", "sinhthigiot80@student.edu.vn", true, "SV080", "Bến Tre", "0380408751", "Khoa Y học", "dưỡng22-05", "Điều dưỡng", "Sinh Thị Giọt", "Không", "Tạm dừng" },
                    { "HS081", new DateTime(2001, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "5312530659", "Dao", "39 Đường 42, Đắk Lắk", "thivanhung81@student.edu.vn", false, "SV081", "Hưng Yên", "0989463042", "Khoa Luật", "tế22-01", "Luật kinh tế", "Thi Văn Hùng", "Không", "Đang học" },
                    { "HS082", new DateTime(2002, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "7649788749", "La Hủ", "72 Đường 2, Bà Rịa-Vũng Tàu", "ngovanminh82@student.edu.vn", true, "SV082", "Bến Tre", "0766834698", "Khoa Luật", "chính22-02", "Luật hành chính", "Ngô Văn Minh", "Không", "Đang học" },
                    { "HS083", new DateTime(2003, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "9260060102", "Cơ Ho", "53 Đường 6, Hà Nam", "đanvanke83@student.edu.vn", false, "SV083", "Quảng Ngãi", "0545133490", "Khoa Luật", "sự22-03", "Luật dân sự", "Đan Văn Kẻ", "Không", "Đang học" },
                    { "HS084", new DateTime(1998, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "6142414677", "Dao", "77 Đường 9, Nam Định", "nguyenthimung84@student.edu.vn", true, "SV084", "Quảng Ninh", "0332010392", "Khoa Luật", "sự22-04", "Luật hình sự", "Nguyễn Thị Mừng", "Không", "Đang học" },
                    { "HS085", new DateTime(1999, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "3218155261", "Mạ", "33 Đường 46, Thừa Thiên Huế", "muavanmom85@student.edu.vn", false, "SV085", "Bình Thuận", "0317417337", "Khoa Luật", "tế22-05", "Luật quốc tế", "Múa Văn Mồm", "Không", "Đang học" },
                    { "HS086", new DateTime(2000, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "1799181599", "Xtiêng", "93 Đường 16, Bến Tre", "đinhthinghi86@student.edu.vn", true, "SV086", "Bình Thuận", "0760465690", "Khoa Sư phạm", "Toán22-01", "Sư phạm Toán", "Đình Thị Nghi", "Không", "Đang học" },
                    { "HS087", new DateTime(2001, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "5448749443", "Si La", "10 Đường 14, Trà Vinh", "đinhvanong87@student.edu.vn", false, "SV087", "Hà Nam", "0366450025", "Khoa Sư phạm", "Lý22-02", "Sư phạm Lý", "Đinh Văn Ông", "Không", "Đang học" },
                    { "HS088", new DateTime(2002, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "8518326379", "Tày", "12 Đường 39, Hòa Bình", "haithiphan88@student.edu.vn", true, "SV088", "Lào Cai", "0544164089", "Khoa Sư phạm", "Hóa22-03", "Sư phạm Hóa", "Hai Thị Phấn", "Không", "Đang học" },
                    { "HS089", new DateTime(2003, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "1095845556", "Brâu", "3 Đường 12, Đắk Nông", "bavanquap89@student.edu.vn", false, "SV089", "Quảng Ninh", "0868256960", "Khoa Sư phạm", "Sinh22-04", "Sư phạm Sinh", "Ba Văn Quặp", "Không", "Đang học" },
                    { "HS090", new DateTime(1998, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "6573152666", "Mường", "79 Đường 41, Nam Định", "đovandung90@student.edu.vn", true, "SV090", "Thừa Thiên Huế", "0310287394", "Khoa Sư phạm", "Văn22-05", "Sư phạm Văn", "Đỗ Văn Dũng", "Không", "Tốt nghiệp" },
                    { "HS091", new DateTime(1999, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "7382772601", "Mảng", "88 Đường 10, Hà Nam", "nguyenvannam91@student.edu.vn", false, "SV091", "Cà Mau", "0321913976", "Khoa Nông nghiệp", "học22-01", "Nông học", "Nguyễn Văn Năm", "Không", "Đang học" },
                    { "HS092", new DateTime(2000, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "8623053293", "Ngái", "22 Đường 12, Phú Yên", "nguyenthito92@student.edu.vn", true, "SV092", "Quảng Bình", "0882390548", "Khoa Nông nghiệp", "nuôi22-02", "Chăn nuôi", "Nguyễn Thị Tô", "Không", "Đang học" },
                    { "HS093", new DateTime(2001, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "8489586953", "Nùng", "7 Đường 49, Nghệ An", "vuvanbay93@student.edu.vn", false, "SV093", "Tiền Giang", "0837263001", "Khoa Nông nghiệp", "y22-03", "Thú y", "Vũ Văn Bảy", "Không", "Đang học" },
                    { "HS094", new DateTime(2002, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "8904447879", "Chu Ru", "4 Đường 18, Bà Rịa-Vũng Tàu", "vuthiut94@student.edu.vn", true, "SV094", "Nam Định", "0556681832", "Khoa Nông nghiệp", "nghiệp22-04", "Lâm nghiệp", "Vũ Thị Út", "Không", "Đang học" },
                    { "HS095", new DateTime(2003, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "8334097728", "Ra Glai", "17 Đường 31, Hà Giang", "taonhocnhi95@student.edu.vn", false, "SV095", "Lâm Đồng", "0530824281", "Khoa Nông nghiệp", "sản22-05", "Thủy sản", "Tào Nhọc Nhi", "Không", "Đang học" },
                    { "HS096", new DateTime(1998, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "4656472443", "Rơ Măm", "82 Đường 7, Hà Tĩnh", "nguyenvanmuoi96@student.edu.vn", true, "SV096", "Tiền Giang", "0639870651", "Khoa Xây dựng", "dụng22-01", "Xây dựng dân dụng", "Nguyễn Văn Mười", "Không", "Đang học" },
                    { "HS097", new DateTime(1999, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "3954869974", "Chơ Ro", "11 Đường 11, Đồng Nai", "levanan97@student.edu.vn", false, "SV097", "Quảng Nam", "0744295418", "Khoa Xây dựng", "nghiệp22-02", "Xây dựng công nghiệp", "Lê Văn An", "Không", "Đang học" },
                    { "HS098", new DateTime(2000, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "6407158765", "Chơ Ro", "36 Đường 41, TP.Hồ Chí Minh", "ngothiap98@student.edu.vn", true, "SV098", "Cần Thơ", "0593432302", "Khoa Xây dựng", "tầng22-03", "Kỹ thuật hạ tầng", "Ngọ Thị Áp", "Không", "Đang học" },
                    { "HS099", new DateTime(2001, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "5917382715", "La Hủ", "87 Đường 27, Vĩnh Phúc", "vanvanbot99@student.edu.vn", false, "SV099", "Đắk Nông", "0312425367", "Khoa Xây dựng", "dựng22-04", "Kinh tế xây dựng", "Vạn Văn Bọt", "Không", "Đang học" },
                    { "HS100", new DateTime(2002, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "4904555825", "Chu Ru", "34 Đường 26, Bến Tre", "trieuthitrinh100@student.edu.vn", true, "SV100", "An Giang", "0361061903", "Khoa Xây dựng", "dựng22-05", "Quản lý xây dựng", "Triệu Thị Trinh", "Không", "Tạm dừng" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoSos_msv",
                table: "HoSos",
                column: "msv",
                unique: true,
                filter: "[msv] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Lops_nghanhmanghanh",
                table: "Lops",
                column: "nghanhmanghanh");

            migrationBuilder.CreateIndex(
                name: "IX_Nganhs_makhoa",
                table: "Nganhs",
                column: "makhoa");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_malop",
                table: "SinhViens",
                column: "malop");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoSos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SinhViens");

            migrationBuilder.DropTable(
                name: "Lops");

            migrationBuilder.DropTable(
                name: "Nganhs");

            migrationBuilder.DropTable(
                name: "Khoas");
        }
    }
}
