using AngularWebAPIProject.DataDB;
using AngularWebAPIProject.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AngularWebAPIProject
{
    public class Startup
    {
        private IConfiguration config;
        public Startup(IConfiguration _config)
        {
            config = _config;
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
           
            // app.UseCors("EnableCORS");
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(
               endpoint =>
               {
                   endpoint.MapControllerRoute(
                   name: "default",
                   pattern: "{controller}/{action=Index}/{id?}");
                  
               });
          
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("EnableCORS", builder =>
            //    {
            //        builder.AllowAnyOrigin()
            //        .AllowAnyHeader()
            //        .AllowCredentials()
            //        .AllowAnyMethod();
            //    });
            //});
            string connectionstring = this.config.GetConnectionString("TestWebAPIContext");
            services.AddDbContext<EmployeeDBContext>(options => options.UseSqlServer(connectionstring));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddCors();
            services.AddControllersWithViews();
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "http://localhost:44440/",
                    ValidAudience = "http://localhost:44440/",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))


                };
            });








        }
    }
}
