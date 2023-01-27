using AdPremiumService.Mapper;
using AutoMapper;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repositories.Implementation;
using Repositories.Interface;
using Service.Implementation;
using Service.Interface;

namespace AdPremiumService
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
			var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
			services.AddScoped<IAdPremiumRepository, AdPremiumRepository>();
			services.AddScoped<IAdPremiumManager, AdPremiumManager>();

			var sessionFactory = Fluently.Configure()
				.Database(
					MsSqlConfiguration.MsSql2008.ConnectionString(Configuration.GetConnectionString("AdPremiumConnectionString"))
				)
				.Mappings(m => m.FluentMappings
					.AddFromAssemblyOf<AdPremiumRepository>()
					.Conventions.Add(FluentNHibernate.Conventions.Helpers.ForeignKey.EndsWith("Id")))
				.BuildSessionFactory();

			services.AddSingleton(sessionFactory);
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "AdPremiumAPI",
				});
			});
			services.AddCors();
			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
				options.RoutePrefix = string.Empty;
			});

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(x => x
				.AllowAnyMethod()
				.AllowAnyHeader()
				.SetIsOriginAllowed(origin => true) // allow any origin
				.AllowCredentials());

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
