using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CalculateVatMVC.Models
{
    public class CountryVatViewModel
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Vat { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
