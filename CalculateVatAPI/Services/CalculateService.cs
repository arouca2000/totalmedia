using CalculateVatAPI.DTOs.Request;
using CalculateVatAPI.DTOs.Response;
using CalculateVatAPI.Services.Interfaces;

namespace CalculateVatAPI.Services
{
    public class CalculateService : ICalculateService
    {
        public CalcResponse Calc(CalcRequest calcRequest)
        {
            var calcResponse = new CalcResponse();
            if (calcRequest.VatRate > 0)
            {
                if (calcRequest.NetAmount > 0)
                {
                    calcResponse.NetAmount = calcRequest.NetAmount.Value;
                    calcResponse.VatAmount = Math.Round(calcRequest.NetAmount.Value * calcRequest.VatRate.Value / 100, 2);
                    calcResponse.GrossAmount = calcResponse.NetAmount + calcResponse.VatAmount;
                }
                else if (calcRequest.VatAmount > 0)
                {
                    calcResponse.VatAmount = calcRequest.VatAmount.Value;
                    calcResponse.NetAmount = Math.Round(calcRequest.VatAmount.Value * 100 / calcRequest.VatRate.Value, 2);
                    calcResponse.GrossAmount = calcResponse.NetAmount + calcResponse.VatAmount;
                }
                else if (calcRequest.GrossAmount > 0)
                {
                    calcResponse.GrossAmount = calcRequest.GrossAmount.Value;
                    calcResponse.VatAmount = Math.Round(calcRequest.GrossAmount.Value - (calcRequest.GrossAmount.Value / (1 + calcRequest.VatRate.Value / 100)), 2);
                    calcResponse.NetAmount = calcResponse.GrossAmount - calcResponse.VatAmount;
                }
            }
            return calcResponse;
        }
    }
}
