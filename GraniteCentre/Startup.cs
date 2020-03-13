using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace GraniteCentre
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
            services.AddMvc();

            //services.Configure<MvcOptions>(options =>
            //{
            //    options.Filters.Add(new RequireHttpsAttribute());
            //});

            //services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
            //    options.HttpsPort = 443;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler("/En/Error");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else// if (env.IsProduction())
            {
                //var options = new RewriteOptions();
                //options.AddRedirectToWww();
                //options.AddRedirectToHttps();
                //app.UseRewriter(options);

                app.UseHsts();
                //app.UseHttpsRedirection();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=En}/{action=Index}/{id?}");
            });
        }
    }

    //public class RedirectToWwwRule : IRule
    //{
    //    public virtual void ApplyRule(RewriteContext context)
    //    {
    //        var req = context.HttpContext.Request;

    //        if (req.Host.Host.Equals("granitecentremoncton.com", StringComparison.OrdinalIgnoreCase) && !req.Host.Value.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
    //        {
    //            var wwwHost = new HostString($"www.{req.Host.Value}");
    //            var newUrl = UriHelper.BuildAbsolute(req.Scheme, wwwHost, req.PathBase, req.Path, req.QueryString);
    //            var response = context.HttpContext.Response;
    //            response.StatusCode = 301;
    //            response.Headers[HeaderNames.Location] = newUrl;
    //            context.Result = RuleResult.EndResponse;
    //        }

    //        context.Result = RuleResult.ContinueRules;
    //        return;
    //    }
    //}

    //public static class RewriteOptionsExtensions
    //{
    //    public static RewriteOptions AddRedirectToWww(this RewriteOptions options)
    //    {
    //        options.Rules.Add(new RedirectToWwwRule());
    //        return options;
    //    }
    //}
}
