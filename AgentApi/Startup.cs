using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.Swagger;

namespace AgentApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }
        private IHostingEnvironment _hostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(swag =>
            {
                swag.SwaggerDoc("v2", new Info { Title = "Agent Api", Version = "v2" });
                swag.IncludeXmlComments(Path.Combine(_hostingEnvironment.ContentRootPath, "AgentApi.xml"));
                swag.OperationFilter<ExamplesOperationFilter>(); // [SwaggerRequestExample] & [SwaggerResponseExample]
                swag.OperationFilter<DescriptionOperationFilter>(); // [Description] on Response properties
                swag.OperationFilter<AddFileParamTypesOperationFilter>(); // Adds an Upload button to endpoints which have [AddSwaggerFileUploadButton]
                swag.OperationFilter<AddResponseHeadersFilter>(); // [SwaggerResponseHeader]
                swag.OperationFilter<AppendAuthorizeToSummaryOperationFilter>(); // Adds "(Auth)" to the summary so that you can see which endpoints have Authorization
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //app.UseMvc();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Config}/{action=Get}/{id?}");
            });

            app.UseSwagger(swag =>
            {
                swag.RouteTemplate = "api-docs/swagger/{documentName}/swagger.json";
                swag.PreSerializeFilters.Add((swaggerDoc, httpreq) => swaggerDoc.Host = httpreq.Host.Value);
            });

            app.UseSwaggerUI(swagUi =>
            {
                swagUi.SwaggerEndpoint("/api-docs/swagger/v2/swagger.json", "Agent Api v2");
                swagUi.RoutePrefix = "api-docs";
            });
        }
    }
}
