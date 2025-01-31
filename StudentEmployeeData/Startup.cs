using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentEmployeeData.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentEmployeeData
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());

            services.AddControllersWithViews();

            services.AddDbContext<EmployeeDbContext>(options =>
            {
                options.UseMySql(Configuration["ConnectionStrings:StudentEmployeeDataDBConnection"]);
            });

            services.AddScoped<IStudentEmployeeDataRepository, EFStudentEmployeeDataRepository>();
            services.AddScoped<INotificationRepository, EFNotificationRepository>();

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=ViewEmployees}/{id?}");
            });
        }
    }
}
