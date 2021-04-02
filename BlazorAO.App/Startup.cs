using BlazorAO.App.Areas.Identity;
using BlazorAO.App.Data;
using BlazorAO.App.Extensions;
using BlazorAO.App.Models;
using BlazorAO.App.Services;
using BlazorAO.Models;
using Dapper.CX.SqlServer.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelSync.Models;
using System;
using System.Net.Http;
using System.Reflection;

namespace BlazorAO.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services
                .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDapperCX(
                connectionString,
                sp => sp.GetAspNetUserWithRoles<UserProfile>(connectionString),
                (id) => Convert.ToInt32(id));

            services.AddScoped((sp) => new DbCreator(
                connectionString,
                DataModel.FromAssembly(Assembly.GetExecutingAssembly().GetReferencedAssembly("BlazorAO.Models")),
                sp.GetRequiredService<IWebHostEnvironment>()));

            services.AddSingleton((sp) => new StateDictionary(connectionString));
            services.AddSingleton<HttpClient>();

            services.Configure<RoleCheckerOptions>(Configuration.GetSection(nameof(RoleChecker)));
            services.AddScoped<RoleChecker>();

            services.Configure<GitHubLinkOptions>(Configuration.GetSection("GitHubLink"));
            services.AddSingleton<AzureTester>();
            
            try { services.AddChangeTracking(connectionString, new DataModel()); } catch { /* do nothing, database might not exist */}            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
