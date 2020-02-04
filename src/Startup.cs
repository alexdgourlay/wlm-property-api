using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using WlmPropertyAPI.DataAccess;
using WlmPropertyAPI.DataAccess.Contracts;
using WlmPropertyAPI.Models;
using WlmPropertyAPI.Queries;

namespace WlmPropertyAPI
{
    public class Startup
    {
        private readonly string corsPolicyName = "ApiCorsPolicy";

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(corsPolicyName,
                builder =>
                {
                    builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            services.AddDbContext<WLMPropertyContext>(opt => { }, ServiceLifetime.Transient);
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();


            //

            // Repositories
            services.AddTransient<IPpdTransactionRepository, PpdTransactionRepository>();
            services.AddTransient<IUkCountyRepository, UkCountyRepository>();
            services.AddTransient<ISummaryRepository, SummaryRepository>();

            // GraphQL Queries.
            services.AddSingleton<PpdTransactionQuery>();
            services.AddSingleton<UkCountyQuery>();
            services.AddSingleton<SummaryQuery>();

            // GraphQL Types
            services.AddSingleton<PpdTransactionType>();
            services.AddSingleton<UkCountyType>();
            services.AddSingleton<RegionSummary2019Type>();


            //


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

            app.UseCors(corsPolicyName);

            // Use GraphiQl, GraphQL testing tool.
            app.UseGraphiQl();

            // Use model view controller service.
            app.UseMvc();
        }
    }
}
