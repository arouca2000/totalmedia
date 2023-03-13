using System.ComponentModel.DataAnnotations;

namespace CalculateVatMVC.Models
{
    public class CountryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="O nome do COUNTRY é obrigatório!")]
        public string Name { get; set; }
        public List<CountryVatViewModel> CountriesVats { get; set; }
    }
}
