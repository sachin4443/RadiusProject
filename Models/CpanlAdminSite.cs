using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Radius.API.Models;

[Table("CpanlAdminSite")]
public class CpanlAdminSite
{
    [Key]
    public int Level1CompanyID { get; set; }
    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? FullName { get; set; }
    public string? MobileNumber { get; set; }

    public string? SiteName { get; set; }
    public string? SiteAddress { get; set; }
    public string? CompanyName { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Zip { get; set; }
    public string? Currency { get; set; }
    public string? Country { get; set; }
    public string? TimeZone { get; set; }
    public decimal Tax { get; set; }

    public bool IsNasLimit { get; set; }
    public bool IsSubscriberLimit { get; set; }
    public bool IsLicenseDays { get; set; }
    public bool IsDefaultSite { get; set; }

    public DateTime AddDate { get; set; }
    public DateTime? LastUpdate { get; set; }
}