using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Radius.API.Models;

[Table("Packages")]
public class Package
{
    [Key]
    public int Id { get; set; }

    public int CompanyID { get; set; }

    public string? PackageName { get; set; }
    public string? PackageDescription { get; set; }
    public string? PackageGroup { get; set; }

    public decimal Price { get; set; }

    public string? DownSpeed { get; set; }
    public string? UpSpeed { get; set; }

    public string? DataLimit { get; set; }
    public string? UptimeLimit { get; set; }
    public string? ExpirationLimit { get; set; }

    public bool Enabled { get; set; }
    public bool PublishToWeb { get; set; }
    public bool TaxIncluded { get; set; }
    public bool ShowInUcp { get; set; }

    public string? Type { get; set; }

    public DateTime AddDate { get; set; }
}