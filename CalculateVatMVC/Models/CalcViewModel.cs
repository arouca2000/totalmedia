namespace CalculateVatMVC.Models
{
    public class CalcViewModel
    {
        public decimal? VatRate { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? VatAmount { get; set; }
        public decimal? GrossAmount { get; set; }
    }
}
