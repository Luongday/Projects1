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
            services.AddSingleton<UserDAO>();
            services.AddSingleton<ManagerServicesFacade>();
            services.AddTransient<ManagerServicesFacade>();
            services.AddTransient<IUserController, UserControllerImpl>();
            services.AddTransient<IUserDAO,UserDAO>();
            services.AddTransient<IUserService,UserServicesImpl>();
            services.AddTransient<IStudentController, StudentControllerImpl>();
            services.AddTransient<IStudentRepository, StudentRepositoryImpl>();
            services.AddTransient<IGetAllStudent,GetAllStudentImpl>();
            services.AddTransient<INganhRepository, NganhRepositoryImpl>();
            services.AddTransient<IGetAllNganh,GetAllNganh>();
            services.AddTransient<INganhControllers, NganhControllerImpl>();
            services.AddTransient<ILopRepository, LopRepositoryImpl>();
            services.AddTransient<IGetAllLop, GetAllLop>();
            services.AddTransient<ILopController, LopControllerImpl>();
            services.AddTransient<IKhoaRepository, KhoaRepositoryImpl>();
            services.AddTransient<IGetAllKhoa, GetAllKhoa>();
            services.AddTransient<IKhoaController,KhoaControllerImpl>();
            services.AddTransient<LoginFrm>();
            services.AddTransient<MenuManagement>();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var serviceProvider = services.BuildServiceProvider();

            // Lấy LoginFrm từ container (có inject UserControllers)
            var loginForm = serviceProvider.GetRequiredService<MenuManagement>();
            
            Application.Run(loginForm);

           
        }
    }
}


