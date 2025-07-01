using CARTER.ApiIntegration.Coaches;
using CARTER.ApiIntegration.Common;
using CARTER.ApiIntegration.Exercises;
using CARTER.ApiIntegration.Stripe;
using CARTER.ApiIntegration.User;
using CARTER.App.Helpers.Middleware;
using CARTER.Models.Common;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartBreadcrumbs.Extensions;
using System;

namespace CARTER.App
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
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddBreadcrumbs(GetType().Assembly);


            //services.AddBreadcrumbs(GetType().Assembly, options =>
            //{
            //    options.TagName = "nav";
            //    options.TagClasses = "";
            //    options.OlClasses = "breadcrumb";
            //    options.LiClasses = "breadcrumb-item";
            //    options.ActiveLiClasses = "breadcrumb-item active";
            //    options.SeparatorElement = "<li class=\"separator\">/</li>";
            //});

            services.AddHttpClient();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Login/Index";
                options.AccessDeniedPath = "/User/Forbidden/";
            });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(1);
            });

            services.Configure<ApiSettingModel>(Configuration.GetSection("ApiSettings"));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ICommonApiClient, CommonApiClient>();
            services.AddTransient<IUserApiClient, UserApiClient>();
            services.AddTransient<IExerciseApiClient, ExerciseApiClient>();
            services.AddTransient<ICoachApiClient, CoachApiClient>();
            services.AddTransient<IStripeApiClient, StripeApiClient>();
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
            app.UseAuthentication();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();
            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
