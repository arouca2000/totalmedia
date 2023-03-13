using CalculateVatMVC.Models;
using CalculateVatMVC.Services;
using CalculateVatMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculateVatMVC.Controllers
{
    public class CalculateController : Controller
    {
        private readonly ICalculateService _calculateService;

        public CalculateController(ICalculateService calculateService)
        {
            _calculateService = calculateService;
        }

        [HttpPost]
        public async Task<ActionResult<CalcViewModel>> Index(CalcViewModel calcRequest)
        {
            var result = await _calculateService.Calc(calcRequest);

            if (result == null)
            {
                return View("Error");
            }
            return View(result);
        }
    }
}
