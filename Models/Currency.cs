using System.ComponentModel.DataAnnotations;

namespace Radius.API.Models;

public class Currency
{
    [Key]
    public int Id { get; set; }

    public string? CurrencyCode { get; set; }

    public string? CurrencyName { get; set; }
}