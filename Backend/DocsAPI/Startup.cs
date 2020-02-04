using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Infrastructure;
using Docs.Infrastructure.Managers;
using Docs.Infrastructure.Repositories;
using Docs.MetadataDbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Services.Docs.Domain.Settings;


namespace DocsAPI
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
	        var settings = Configuration.Get<DocsApiSettings>();
			services.TryAddSingleton(settings);

			services.AddDbContext<UserDbContext>(options =>
			{
				options.UseSqlServer(settings.MetadataDbContextSettings.ConnectionString);
			});

			services.AddScoped<IAnswerManager, AnswerManager>();
			services.AddScoped<ICourseManager, CourseManager>();
			services.AddScoped<ICourseStageManager, CourseStageManager>();
			services.AddScoped<IEnrollmentManager, EnrollmentManager>();
			services.AddScoped<IQuestionManager, QuestionManager>();
			services.AddScoped<IRankManager, RankManager>();
			services.AddScoped<IRoleManager, RoleManager>();
			services.AddScoped<IUserManager, UserManager>();

            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseStageRepository, CourseStageRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IRankRepository, RankRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddSwaggerGen(c =>
            {
	            c.SwaggerDoc("v1", new OpenApiInfo { Title = "DocsAPI", Version = "v1" });
            });

            services.AddCors(options => options.AddPolicy("ManOfCultureCorsPolicy", new CorsPolicyBuilder()
                .SetIsOriginAllowed(origin => origin.Contains("//localhost:"))
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .Build()));

            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
	        if (env.IsDevelopment())
            {
                app.UseCors("ManOfCultureCorsPolicy");
                app.UseDeveloperExceptionPage();
            }

	        app.UseSwagger(c =>
	        {
		        c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
            });
	        app.UseSwaggerUI(c =>
            {
	            c.RoutePrefix = "api/swagger";
	            c.SwaggerEndpoint("v1/swagger.json", "DocsAPI V1");
            });

            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
