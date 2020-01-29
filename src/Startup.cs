using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using GraphiQl;
using GraphQL;
using WlmPropertyAPI.Models;
using WlmPropertyAPI.DataAccess;
using WlmPropertyAPI.DataAccess.Contracts;
using WlmPropertyAPI.Queries;
using GraphQL.Types;
using Newtonsoft.Json;

namespace WlmPropertyAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // CORS named policy.
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200",
                                        "http://ukproperty.azurewebsites.net");
                });
            });

            string connectionString = Configuration["Data:UKPropertyAPIConnection:ConnectionString"];

            services.AddTransient<IPpdTransactionRepository, PpdTransactionRepository>();

            services.AddDbContext<WLMPropertyContext>(opt =>
                                               opt.UseSqlServer(connectionString));

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddSingleton<PpdTransactionQuery>();

            services.AddSingleton<PpdTransactionType>();

            var sp = services.BuildServiceProvider();

            services.AddSingleton<ISchema>(new WlmPropertySchema(new FuncDependencyResolver(type => sp.GetService(type))));

            // Add model view controller service.
            // Avoid JSON Problems: https://stackoverflow.com/a/58084628/9572250.
            services.AddMvc(option => option.EnableEndpointRouting = false)
                  .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                  .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            // Use GraphiQl, GraphQL testing tool.
            app.UseGraphiQl();

            // Use model view controller service.
            app.UseMvc();
        }
    }
}
