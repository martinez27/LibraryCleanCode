using FluentValidation;
using PruebaIngresoBibliotecario.Entities.Inteface;
using PruebaIngresoBibliotecario.Presenters.Loan;
using PruebaIngresoBibliotecario.Repositories.InMemory.Context;
using PruebaIngresoBibliotecario.Repositories.InMemory.Repositories;
using PruebaIngresoBibliotecario.UseCases.CreateLoan;
using PruebaIngresoBibliotecario.UseCases.GetLoanById;
using PruebaIngresoBibliotecario.UseCasesPorts.CreateLoan;
using PruebaIngresoBibliotecario.UseCasesPorts.GetLoanById;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PruebaIngresoBibliotecario.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddLibraryServices(this IServiceCollection services) 
        {
            //Base de Datos 
            services.AddDbContext<PersistenceContext>(options =>
                options.UseInMemoryDatabase("PruebaIngreso"));

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
            return services;

        }
    }
}
