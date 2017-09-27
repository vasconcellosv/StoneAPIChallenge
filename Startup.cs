using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DependencyInjectionSample.Interfaces;
using DependencyInjectionSample.Data;
using APIChallenge.Data.Data;
using DependencyInjectionSample.Models;
using APIChallenge;
using APIChallengeCmd.Data.Data.DataBase;
using Microsoft.EntityFrameworkCore;

namespace APIChallengeCmd
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["ConexaoMySql:MySqlConnectionString"];
            services.AddDbContext<MyContext>(options => options.UseMySql(connection));

            // Add framework services.
            services.AddMvc();
			
			services.AddScoped<IServicosDeCliente,ServicosDeCliente>();
            services.AddScoped<IServicosDeEstabelecimento,ServicosDeEstabelecimento>();
            services.AddScoped<IServicosDePagamento,ServicosDePagamento>();
            services.AddSingleton<IDataBase, DataBase>();
            services.AddScoped<IClienteDados,ClienteDados>();
            services.AddScoped<IEstabelecimentoDados, EstabelecimentoDados>();
            services.AddScoped<IPagamentoDados, PagamentoDados>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
