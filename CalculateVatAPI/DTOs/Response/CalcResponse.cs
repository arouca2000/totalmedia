using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculateVatAPI.DTOs.Response
{
    public class CalcResponse
    {
        [Column(TypeName = "decimal(8,2)")]
        public decimal NetAmount { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal VatAmount { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal GrossAmount { get; set; }
    }
}
