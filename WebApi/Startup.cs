using Application.ChekEmtehan;
using Application.Coach;
using Application.Context;
using Application.DatesDrivig;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
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

            services.AddControllers();
            services.AddTransient<IDataBaceContext, DataBaceContext>();
    
            services.AddTransient<ICreateCoachs,CreateCoachs>();
            services.AddTransient<IReportCoach,ReportCoach>();
            services.AddTransient<ISetCoachForUsers,SetCoachForUsers>();
            services.AddTransient<IUserManaGementByCoach,UserManaGementByCoach>();
            services.AddTransient<IchekAiname,chekAiname>();
            services.AddTransient<IChekAmali,ChekAmali>();
            services.AddTransient<IDatesDrivigs,DatesDrivig>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
            });


            string contectionString = @"server=.; Initial Catalog=Bugeto_StoreDb; Integrated Security=True;";
            services.AddEntityFrameworkSqlServer().AddDbContext<DataBaceContext>(option => option.UseSqlServer(contectionString));



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
