using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.UseCasesPorts.GetLoanById
{
    public interface IGetLoanByIdInputPort
    {
        Task Handle(string id);
    }
}
