using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using PruebaIngresoBibliotecario.Entities.Inteface;
using PruebaIngresoBibliotecario.Presenters.Loan;
using PruebaIngresoBibliotecario.Repositories.InMemory.Context;
using PruebaIngresoBibliotecario.Repositories.InMemory.Repositories;
using PruebaIngresoBibliotecario.UseCases.CreateLoan;
using PruebaIngresoBibliotecario.UseCases.GetLoanById;
using PruebaIngresoBibliotecario.UseCasesPorts.CreateLoan;
using PruebaIngresoBibliotecario.UseCasesPorts.GetLoanById;
using FluentValidation;
using System.Reflection;
using PruebaIngresoBibliotecario.WebExceptionsPresenter;

namespace PruebaIngresoBibliotecario.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            Trace.Indent();
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSwaggerDocument();

            services.AddDbContext<Infrastructure.PersistenceContext>(opt =>
            {
                opt.UseInMemoryDatabase("PruebaIngreso");
            });

            //Base de Datos 
            services.AddDbContext<PersistenceContext>(options =>
                options.UseInMemoryDatabase("PruebaIngreso"));

            //Controladores
            services.AddControllers(Filters.Register);

            //repositorio
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Validate
            services.AddValidatorsFromAssembly(Assembly.Load("PruebaIngresoBibliotecario.UseCases"));

            //Puertos
            services.AddScoped<ICreateLoanInputPort, CreateLoanInteractor>();
            services.AddScoped<ICreateLoanOutputPort, CreateLoanPresenter>();
            services.AddScoped<IGetLoanByIdInputPort, GetLoanByIdInteractor>();
            services.AddScoped<IGetLoanByIdOutputPort, GetLoanByIdPresenter>();

            services.AddControllers(mvcOpts =>
            {
            });

        }


        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();

        }
    }


}
