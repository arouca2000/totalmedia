using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CalculateVatAPI.DTOs.Request
{
    public class CalcRequest
    {
        public decimal? VatRate { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? VatAmount { get; set; }
        public decimal? GrossAmount { get; set; }
    }
}
