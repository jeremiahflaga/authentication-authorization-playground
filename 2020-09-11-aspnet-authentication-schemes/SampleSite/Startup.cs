using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SampleSite
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
            services.AddRazorPages();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "cookie1";
            })
            .AddCookie("cookie1", "cookie1", options =>
            {
                options.Cookie.Name = "cookie1";
                options.LoginPath = "/loginc1";
            })
            .AddCookie("cookie2", "cookie2", options =>
            {
                options.Cookie.Name = "cookie2";
                options.LoginPath = "/loginc2";
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.Use(next =>
            {
                return async ctx =>
                {
                    switch (ctx.Request.Path)
                    {
                        case "/loginc1":
                            var identity1 = new ClaimsIdentity("cookie111");
                            identity1.AddClaim(new Claim("name", "Alice-c1"));
                            await ctx.SignInAsync("cookie1", new ClaimsPrincipal(identity1));
                            break;
                        case "/loginc2":
                            var identity2 = new ClaimsIdentity("cookie222");
                            identity2.AddClaim(new Claim("name", "Alice-c2"));
                            await ctx.SignInAsync("cookie2", new ClaimsPrincipal(identity2));
                            break;
                        case "/logoutc1":
                            await ctx.SignOutAsync("cookie1");
                            break;
                        case "/logoutc2":
                            await ctx.SignOutAsync("cookie2");
                            break;
                        default:
                            await next(ctx);
                            break;
                    }
                };
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
