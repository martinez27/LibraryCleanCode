using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaIngresoBibliotecario.UseCasesDTOs.GetLoanById;
using PruebaIngresoBibliotecario.UseCasesPorts.GetLoanById;

namespace PruebaIngresoBibliotecario.Presenters.Loan
{
    public class GetLoanByIdPresenter : IGetLoanByIdOutputPort
    {
        public GetLoanByIdDTO Content;
        public Task Handle(GetLoanByIdDTO loanByIdDTO)
        {
            Content = loanByIdDTO;   
            return Task.CompletedTask;
        }
    }
}
