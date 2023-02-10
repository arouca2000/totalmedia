using CalculateVatAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CalculateVatAPI.DTOs.Response
{
    public class CountryVatResponse
    {
        public int Id { get; set; }
        public decimal Vat { get; set; }
        public int CountryId { get; set; }
    }
}
