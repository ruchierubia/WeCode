using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WeCode.Models;

namespace WeCode
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDBContext>(
                options => options.UseSqlServer(_config.GetConnectionString("WeCodeDBConnection")));


            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                //options.Password.RequiredLength = 10; // restore default config so we can put shorter user passwords
                //options.Password.RequiredUniqueChars = 3;
            })
            .AddEntityFrameworkStores<AppDBContext>();

            //services.Configure<IdentityOptions>(options => same as above no make prevent duplicate
            //{
            //    options.Password.RequiredLength = 10;
            //    options.Password.RequiredUniqueChars = 3;
            //    options.Password.RequireNonAlphanumeric = false;
            //});

            //services.AddMvcCore(); not complete, only core services
            services.AddMvc(option => 
            {
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
                option.Filters.Add(new AuthorizeFilter(policy)); // apply authorize attribute globally just put [allowanonymous] to needed enty action

            }).AddXmlSerializerFormatters();// to return xml

            //services.AddAuthentication( options => { // diable social authentication
            //    options.DefaultChallengeScheme = FacebookDefaults.AuthenticationScheme;
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //}).AddFacebook(options => {

            //    options.AppId = "";
            //    options.AppSecret = "";
            //}).AddCookie();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("DeleteRolePolicy",
                policy => policy.RequireClaim("Delete Role"));
                // role based is just a claim with role type

                options.AddPolicy("EditRolePolicy",
                policy => policy.RequireClaim("Edit Role"));


                options.AddPolicy("AdminRolePolicy",
                policy => policy.RequireRole("Admin"));
            });

            services.AddScoped<ITalentRepository, TalentRepository>();// switch implementations perfect to unit testing , dependency injection at its finest
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            }); //conventional routing
        }
    }
}
