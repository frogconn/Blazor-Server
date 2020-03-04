namespace Blazor {

    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Syncfusion.EJ2.Blazor;

    public class Startup {

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment) {
            this.Configuration = configuration;
            this.WebHostEnvironment = webHostEnvironment;
        }

        public void Configure(IApplicationBuilder app) {
            if (this.WebHostEnvironment.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        public void ConfigureServices(IServiceCollection services) {
            
            services.AddHttpClient();
            services.AddRazorPages();
            services.AddServerSideBlazor().AddCircuitOptions(o => {
                if (this.WebHostEnvironment.IsDevelopment()) {
                    o.DetailedErrors = true;
                }
            });
            services.AddMediatR(typeof(Startup));
            services.AddSyncfusionBlazor();
        }
    }
}
