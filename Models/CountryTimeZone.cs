using System.ComponentModel.DataAnnotations;

namespace Radius.API.Models;

public class CountryTimeZone
{
    [Key]
    public int Id { get; set; }

    [MaxLength(150)]
    public string? TimeZoneName { get; set; }
    public string? CountryName { get; set; }
    public string? CountryCode { get; set; }
    public string? TimeZoneId { get; set; }

    [MaxLength(20)]
    public string? UtcOffset { get; set; }
}