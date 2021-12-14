using IRestaurantManageBLL;
using IRestaurantManageDAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestaurantManageBLL;
using RestaurantManageDAL;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement
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
            services.AddControllersWithViews();
            //注册session
            services.AddSession();

            //注入上下文类对象
            services.AddDbContext<ManegeDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            //配置Dal
            services.AddScoped<IDepartmentInfoDal, DepartmentInfoDal>();
            services.AddScoped<IRoleInfoDal, RoleInfoDal>();
            services.AddScoped<IStaffInfoDal, StaffInfoDal>();
            services.AddScoped<IUserInfoDal, UserInfoDal>();
            services.AddScoped<IStasff_RoleInfoDal, Stasff_RoleInfoDal>();
            services.AddScoped<IMenuInfoDal, MenuInfoDal>();
            services.AddScoped<IMenu_RoleInfoDal, Menu_RoleInfoDal>();


            //配置Bll
            services.AddScoped<IDepartmentInfoBll, DepartmentInfoBll>();
            services.AddScoped<IRoleInfoBll, RoleInfoBll>();
            services.AddScoped<IStaffInfoBll, StaffInfoBll>();
            services.AddScoped<IUserInfoBll, UserInfoBll>();
            services.AddScoped<IMenuInfoBll, MenuInfoBll>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //使用session
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
