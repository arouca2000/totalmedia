using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CalculateVatAPI.Models
{
    [Table("CountriesVats")]
    public class CountryVat
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")] 
        public decimal Vat { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
