using Microsoft.Extensions.DependencyInjection;
using QuanLyHoSoSinhVien.view;
using QuanLyHoSoSinhVien.BusinessLayer.Services.UserServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.UserRepository;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.UserControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.StudentControl;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.StudentRepository;
using QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices;
using QuanLyHoSoSinhVien.PresentationLayer;
using QuanLyHoSoSinhVien.BusinessLayer.Services.NganhServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.NganhRepository;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.NganhControl;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.LopRepository;
using QuanLyHoSoSinhVien.BusinessLayer.Services.LopServices;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.LopControl;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.KhoaRepository;
using QuanLyHoSoSinhVien.BusinessLayer.Services.KhoaServices;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.KhoaControl;
using QuanLyHoSoSinhVien.PresentationLayer.view;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.HoSoRepository;
using QuanLyHoSoSinhVien.BusinessLayer.Services.ProfileServices;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.HoSoController;
using QuanLyHoSoSinhVien.DataAccessLayer.Entity;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.DetailsProfileRepository;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.DetailsProfileController;
using QuanLyHoSoSinhVien.BusinessLayer.Services.DetailsProefileServices;
using QuanLyHoSoSinhVien.PresentationLayer.DTO.UserDTO;

namespace QuanLyHoSoSinhVien
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
           // services.AddSingleton<UserDAO>();
            services.AddTransient<ManagerServicesFacade>();
            services.AddSingleton<DataContext>();
            //user DI
            services.AddTransient<IUserController, UserControllerImpl>();
            services.AddTransient<IUserDAO,UserDAO>();
            services.AddTransient<IUserService,UserServicesImpl>();
            services.AddSingleton<UserDto>();
            //student DI
            services.AddTransient<IStudentController, StudentControllerImpl>();
            services.AddTransient<IStudentRepository, StudentRepositoryImpl>();
            services.AddTransient<IGetAllStudent,SinhVienQueryImpl>();
            services.AddTransient<IGetAStudentWithMa, SinhVienQueryImpl>();
            services.AddTransient<IGetAStudentController, StudentControllerImpl>();
            //nganh DI
            services.AddTransient<INganhRepository, NganhRepositoryImpl>();
            services.AddTransient<IGetAllNganhService,NganhQueryServiceImpl>();
            services.AddTransient<INganhControllers, NganhQueryControllerImpl>();
            services.AddTransient<IAddNganhService, NganhCommandServiceImpl>();
            services.AddTransient<IAddNganhController, NganhComandControllerImpl>();
            services.AddTransient<IDeleteNganhService, NganhCommandServiceImpl>();
            services.AddTransient<IDeleteNganhController,NganhComandControllerImpl>();
            services.AddTransient<IEditNganhService, NganhCommandServiceImpl>();   
            services.AddTransient<IEditNganhController, NganhComandControllerImpl>();   
            //lop DI
            services.AddTransient<ILopRepository, LopRepositoryImpl>();
            services.AddTransient<IGetAllLop, LopQueryIServicempl>();
            services.AddTransient<ILopController, LopQueryControllerImpl>();
            services.AddTransient<IAddLopService,LopComandServiceImpl>();
            services.AddTransient<IAddLopController, LopComandControllerImpl>();
            services.AddTransient<IDeleteLopService, LopComandServiceImpl>();
            services.AddTransient<IDeleteLopController,LopComandControllerImpl>();
            services.AddTransient<IEditLopService, LopComandServiceImpl>();
            services.AddTransient<IEditLopController, LopComandControllerImpl>();
            //khoa DI
            services.AddTransient<IKhoaRepository, KhoaRepositoryImpl>();
            services.AddTransient<IGetAllKhoa, KhoaQueryServicesImpl>();
            services.AddTransient<IKhoaController,KhoaQueryControllerImpl>();
            services.AddTransient<IAddNewKhoaService,KhoaComandServicesImpl>();
            services.AddTransient<IGetKhoaForId, KhoaQueryServicesImpl>();
            services.AddTransient<IAddKhoaController, KhoaComandImpl>();
            services.AddTransient<IDeleteKhoaService, KhoaComandServicesImpl>();
            services.AddTransient<IDeleteKhoaController, KhoaComandImpl>();
            services.AddTransient<IEditKhoaService, KhoaComandServicesImpl>();
            services.AddTransient<IEditKhoaController, KhoaComandImpl>();
            //HoSo DI
            services.AddTransient<IHoSoRepository, HoSoRepositoryImpl>();
            services.AddTransient<IGetAllHoSoServices, ProfileQueryServicesImpl>();
            services.AddTransient<IProfileController, ProfileControllerImpl>();
            services.AddTransient<IEditProfileController, ProfileComandControllerImpl>();
            services.AddTransient<IDeleteProfileController, ProfileComandControllerImpl>();
            services.AddTransient<IEditProfileServices, ProfileComandServicesImpl>();
            services.AddTransient<IDeleteProfileServices, ProfileComandServicesImpl>();
            //Chi tiet ho so DI
            services.AddTransient<IDetailsProfileRepository, DetailsProfileRepositoryImpl>();
            services.AddTransient<IDetailsProfileController, DetailsProfileControllerImpl>();
            services.AddTransient<ITakeADetailsProfileOfTheStudentServices, DetailsProfileQueryImpl>();


            services.AddTransient<ThemNganhFrm>();
            services.AddTransient<LoginFrm>();
            services.AddTransient<MenuManagement>();
            services.AddTransient<ThemKhoa>();

            services.AddTransient<ChiTietHoSo>();

            services.AddTransient<ThemLopFrm>();
            services.AddTransient<MenuStudent>();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var serviceProvider = services.BuildServiceProvider();

            // Lấy LoginFrm từ container (có inject UserControllers)
            var loginForm = serviceProvider.GetRequiredService<LoginFrm>();
            Application.Run(loginForm);
        }
    }
}


