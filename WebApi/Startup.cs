using Application.ChekEmtehan;
using Application.Coach;
using Application.Context;
using Application.DatesDrivig;
using Application.User.Commands;
using Application.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var Key = "{57971982-D114-4E43-9FE5-B34BF4E1DCE9}";
            // migim chetor bashe auti mishod to contoroler hamzad
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            { // ona to hederi mifrastan va ma miam  valideshon mikonim
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = "ShowroomAmetis",
                    ValidAudience = "ShowroomAmetis",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key)),
                    ValidateIssuerSigningKey = true, // ema chek mishe khodesh anjam dade bashe va motabar bashe ejaze mide
                    ValidateLifetime = true,  // age zaman nadashte bashe estefade nemiseh

                };
                options.SaveToken = true;  // ba in mishe token karbar mifreste  ro bedaast avord httpcontext.gettoken
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        // masan log koni
                        //etebar nadare
                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                    {
                        // khata hii mokhtalef
                        return Task.CompletedTask;
                    },
                    OnForbidden = context =>
                    {
                        return Task.CompletedTask;

                    },
                    OnMessageReceived = context =>
                    {
                        // zamani ke token aryaft mishe  masan ghab l az harci mikhai masna sakhtaresh avaz koni
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        // validate shode va ejaze dast resi mikhad in mishe masan ekhtesasi kard

                        return Task.CompletedTask;
                    }

                };


            });
///////////////////////////////////////////
            services.AddControllers();
            ////mediatr
            services.AddMediatR(typeof(RejesterUserCommand).Assembly);
            services.AddMediatR(typeof(LoginUserHandler).Assembly);

            ///
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

            app.UseAuthentication();
             app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
