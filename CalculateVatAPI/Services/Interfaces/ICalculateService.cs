using CalculateVatAPI.DTOs.Request;
using CalculateVatAPI.DTOs.Response;

namespace CalculateVatAPI.Services.Interfaces
{
    public interface ICalculateService
    {
        CalcResponse Calc(CalcRequest calcRequest);
    }
}
