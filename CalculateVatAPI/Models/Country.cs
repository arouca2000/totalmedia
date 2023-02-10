using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculateVatAPI.Models
{
    [Table("Countries")]
    public class Country
    {
        public Country()
        {
            CountriesVats = new List<CountryVat>();
        }
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<CountryVat> CountriesVats { get; set; }
    }
}
