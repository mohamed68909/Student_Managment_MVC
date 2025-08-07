using Microsoft.EntityFrameworkCore;
using Student_Managmet_MVC.Data;
using Student_Managmet_MVC.Middleware;
using Student_Managmet_MVC.Service.Interface;
using Student_Managmet_MVC.Service;

namespace Student_Managmet_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppsContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseMiddleware<RequestLogsURLMaddleware>();
            
            app.UseAuthorization();

            app.MapStaticAssets();
            app.UseRouting();

          
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Students}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
