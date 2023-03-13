using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CalculateVatMVC.Models
{
    public class CountryVatNameViewModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public IEnumerable<CountryVatViewModel> countriesVats { get; set; }
    }
}
