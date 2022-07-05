using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using OngProject.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Amazon.S3;
using OngProject.Core.Helper;

using System.Collections.Generic;

using Microsoft.AspNetCore.Http;


namespace OngProject
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
            services.AddDbContext<OngDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OngConnectionString")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OngProject", Version = "v1" });

            });
        

            //declaro un servicio para hacerlo funcionar en todo el proyecto

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IActivitiesBusiness, ActivitiesBusiness>();
            services.AddScoped<ITestimonialsBusiness, TestimonialsBusiness>();
            services.AddHttpContextAccessor();
            services.AddAWSService<IAmazonS3>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ICommentsBusiness, CommentsBusiness>();
            services.AddScoped<IMembersBusiness, MembersBusiness>();
            services.AddScoped<INewsBusiness, NewsBusiness>();
            services.AddScoped<ICategoriesBusiness, CategoriesBusiness>();
            services.AddScoped<IOrganizationsBusiness, OrganizationsBusiness>();
            services.AddScoped<IUsersBusiness, UsersBusiness>();
            services.AddScoped<IAuthenticationBusiness, AuthenticationBusiness>();
            services.AddScoped<IContactsBusiness, ContactsBusiness>();
            services.AddScoped<ISlidesBusiness, SlidesBusiness>();

            //JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(jwt =>
                {
                    var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);

                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false,
                        ValidateLifetime = true
                    };
                });

            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OngProject v1"));
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
