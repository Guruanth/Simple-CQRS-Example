using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleApp.Cqrs.Command.Companies;
using SampleApp.Cqrs.Command.People;
using SampleApp.Cqrs.CommandHandler;
using SampleApp.Cqrs.CommandHandler.Companies;
using SampleApp.Cqrs.CommandHandler.People;
using SampleApp.Cqrs.Dispatchers;
using SampleApp.Cqrs.QueryHandler;
using SampleApp.Cqrs.QueryHandler.Companies;
using SampleApp.Cqrs.QueryHandler.People;
using SampleApp.Cqrs.QueryResult;
using SampleApp.Dal.Infrastructure;
using System.Collections.Generic;

namespace SampleApp.Web
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
            services.AddDbContextPool<SampleAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();

            // TODO: The handlers should be extracted to a different file for organizational purposes

            services
                .AddScoped<ICommandHandler<AddCompanyCommand>, AddCompanyCommandHandler>()
                .AddScoped<ICommandHandler<UpdateCompanyCommand>, UpdateCompanyCommandHandler>()
                .AddScoped<ICommandHandler<DeleteCompanyCommand>, DeleteCompanyCommandHandler>();

            services
                .AddScoped<ICommandHandler<AddPersonCommand>, AddPersonCommandHandler>()
                .AddScoped<ICommandHandler<UpdatePersonCommand>, UpdatePersonCommandHandler>()
                .AddScoped<ICommandHandler<DeletePersonCommand>, DeletePersonCommandHandler>();

            services
                .AddScoped<IQueryHandler<List<CompanyQueryResult>>, AllCompaniesQueryHandler>()
                .AddScoped<IQueryHandler<CompanyQueryResult>, CompanyByIdQueryHandler>();

            services
                .AddScoped<IQueryHandler<List<PersonQueryResult>>, AllPeopleQueryHandler>()
                .AddScoped<IQueryHandler<PersonQueryResult>, PersonByIdQueryHandler>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}