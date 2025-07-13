using Microsoft.Extensions.DependencyInjection;
using QuanLyHoSoSinhVien.view;
using QuanLyHoSoSinhVien.BusinessLayer.Services.UserServices;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.UserRepository;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.UserControl;
using QuanLyHoSoSinhVien.PresentationLayer.Controller.StudentControl;
using QuanLyHoSoSinhVien.DataAccessLayer.Repository.StudentRepository;
using QuanLyHoSoSinhVien.BusinessLayer.Services.StudentServices;

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
            services.AddTransient<IUserController, UserControllerImpl>();
            services.AddTransient<IUserDAO,UserDAO>();
            services.AddTransient<IUserService,UserServicesImpl>();
            services.AddTransient<IStudentController, StudentControllerImpl>();
            services.AddTransient<IStudentRepository, GetAllStudent>();
            services.AddTransient<IGetAllStudent,GetAllStudentImpl>();
            services.AddTransient<LoginFrm>();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var serviceProvider = services.BuildServiceProvider();

            // Lấy LoginFrm từ container (có inject UserControllers)
            var loginForm = serviceProvider.GetRequiredService<LoginFrm>();
            Application.Run(loginForm);
            
            //Application.Run(new view.LoginFrm());
        }
    }
}


