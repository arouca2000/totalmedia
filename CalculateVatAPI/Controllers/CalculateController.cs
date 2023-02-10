using CalculateVatAPI.DTOs.Request;
using CalculateVatAPI.DTOs.Response;
using CalculateVatAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace CalculateVatAPI.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly ICalculateService _cs;

        public CalculateController(ICalculateService cs)
        {
            _cs = cs;
        }

        [HttpPost]
        public ActionResult<CalcResponse> Calc(CalcRequest calcRequest)
        {
            if (calcRequest.VatRate <= 0 || calcRequest.VatRate == null)
            {
                return BadRequest("Vat Rate must be greather than 0!");
            }
            if ((calcRequest.NetAmount <= 0 || calcRequest.NetAmount == null) && (calcRequest.VatAmount <= 0 || calcRequest.VatAmount == null) && (calcRequest.GrossAmount <= 0 || calcRequest.GrossAmount == null))
            {
                return BadRequest("Invalid Values!");
            }
            var calcResponse = _cs.Calc(calcRequest);
            return Ok(calcResponse);
        }
    }
}
