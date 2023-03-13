using CalculateVatMVC.Models;

namespace CalculateVatMVC.Services.Interfaces
{
    public interface ICalculateService
    {
        Task<CalcViewModel> Calc(CalcViewModel calcRequest);
    }
}
