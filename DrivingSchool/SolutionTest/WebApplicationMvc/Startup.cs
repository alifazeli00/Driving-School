using app;
using app.User.Command;

using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMvc
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
            services.AddMediatR(typeof(ForgetUserCommand).Assembly);
            services.AddMediatR(typeof(LoginUserCommand).Assembly);
            services.AddMediatR(typeof(RejesterUserCommand).Assembly);
            services.AddControllersWithViews();
            services.AddTransient<IDataBaceContext,DataBaceContext>();
            string contectionString = @"server=.; Initial Catalog=Bugeto_StoreDb; Integrated Security=True;";
            services.AddEntityFrameworkSqlServer().AddDbContext<DataBaceContext>(option => option.UseSqlServer(contectionString));

      
            services.AddMediatR(typeof(RejesterUserCommand).Assembly);
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(option =>
            {
                option.LoginPath = "/Auth/Login";
                option.LogoutPath = "/Auth/Logout";
                option.ExpireTimeSpan = TimeSpan.FromDays(30);
            });

            //     services.AddDbContext<DataBaceContextIdentity>(option => option.UseSqlServer(contectionString));
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
