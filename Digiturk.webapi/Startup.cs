using Digiturk.business.Abstract;
using Digiturk.business.Concrete;
using Digiturk.core.Abstract;
using Digiturk.core.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Digiturk.business.Helper;
using Digiturk.data.Context;
using Swashbuckle.AspNetCore.Swagger;

namespace Digiturk.webapi
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


            services.AddDbContext<LwContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IFilesService, FilesService>();
            services.AddScoped<ILanguagesService, LanguagesService>();
            services.AddScoped<IPostFilesService, PostFilesService>();
            services.AddScoped<IPostImagesService, PostImagesService>();
            services.AddScoped<IPostTagsService, PostTagsService>();


            services.AddScoped(typeof(ICrudHelper<>), typeof(CrudHelper<>));



            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("CoreSwagger", new Info
                {
                    Title = "Digiturk Asp.net Core",
                    Version = "1.0.0",
                    Description =
                        "Digiturk Asp.net Core Api Repository Design Pattern , Jwt ,Ef Core,Role Based Project",
                    Contact = new Contact()
                    {
                        Name = "Digiturk",
                        Url = "http://hakanguzel.com.tr",
                        Email = "hakan-guzel@outlook.com"
                    },
                    TermsOfService = "http://swagger.io/terms/"
                });
            });

            var key = Encoding.ASCII.GetBytes("EncryptionKey");
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    //TODO: Either use the SwaggerGen generated Swagger contract (generated from C# classes)
                    c.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json", "Swagger Test .Net Core");

                    //TODO: Or alternatively use the original Swagger contract that's included in the static files
                    // c.SwaggerEndpoint("/swagger-original.json", "Swagger Petstore Original");
                });

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
