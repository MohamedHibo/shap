using Microsoft.EntityFrameworkCore;
using shap.context;
using shap.Repository;
using Microsoft.AspNetCore.Identity;
using shap.Models;


namespace shap
{
    
        public class Program
        {
            public static void Main(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.
                builder.Services.AddControllersWithViews();

                
                builder.Services.AddDbContext<appContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


                
                builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<appContext>()
    .AddDefaultTokenProviders();


            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

            var app = builder.Build();

                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                }
                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthorization();
                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                app.Run();
            }
        }
   
}

