using System.ComponentModel.DataAnnotations;

namespace Radius.API.Models;

public class Country
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string CountryName { get; set; } = string.Empty;

    [Required]
    [MaxLength(10)]
    public string CountryCode { get; set; } = string.Empty;

    // Optional (best practice)
    public string? CurrencyCode { get; set; }
}
