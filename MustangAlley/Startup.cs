using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MustangAlley.Models;
using MustangAlley.Repositories;
using MustangAlley.Services;
using MustangAlley.Services.Interfaces;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace MustangAlley
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddUserSecrets<Startup>()
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var dbUserName = Configuration["dbUserName"];
            var dbPassword = Configuration["dbPassword"];

            string connection =
                $@"Server=tcp:mustangalley.database.windows.net,1433;Database=MustangAlley;User ID={dbUserName};Password={dbPassword};Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
            services.AddEntityFrameworkSqlServer().AddDbContext<RegistrationContext>(options => options.UseSqlServer(connection));

            services.AddMvc();
            
            services.AddRecaptcha(new RecaptchaOptions
            {
                SiteKey = Configuration["SiteKey"],
                SecretKey = Configuration["SecretKey"],
                ValidationMessage = "Are you a robot?"
            });

            // Add application services.
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddTransient<IEmailSender, MessageService>();
            services.AddTransient<IRegistrationRepository, RegistrationRepository>();
            services.AddTransient<IRegistrationService, RegistrationService>();
            services.AddTransient<IDocumentService, DocumentService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}