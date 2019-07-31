using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //DefaultFilesOptions _defaultFilesOptions = new DefaultFilesOptions();
            //_defaultFilesOptions.DefaultFileNames.Clear();
            //_defaultFilesOptions.DefaultFileNames.Add("foo.html");
            //app.UseDefaultFiles(_defaultFilesOptions);

            //app.UseStaticFiles();

            FileServerOptions _fileServerOptions = new FileServerOptions();
            _fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            _fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            app.UseFileServer(_fileServerOptions);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello world!");
            });
        }
    }
}
