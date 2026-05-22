using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Radius.API.Models;

[Table("CpanlAdminSite")]
public class CpanlAdminSite
{
    [Key]
    public int Level1CompanyID { get; set; }

    public int LevelID { get; set; }
    public int ParentCompanyID { get; set; }

    public string? CompanyID { get; set; }

    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? FullName { get; set; }
    public string? MobileNumber { get; set; }
    public string? Role { get; set; }
    public bool IsEnabled { get; set; }

    public string? SiteName { get; set; }
    public string? SiteEmail { get; set; }
    public string? SiteDomain { get; set; }
    public string? SiteMobileNo { get; set; }
    public bool UseOwnDomain { get; set; }

    public string? SiteAddress { get; set; }
    public string? SiteDescription { get; set; }

    public string? CompanyName { get; set; }
    public string? CompanyTagline { get; set; }

    public string? Country { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Zip { get; set; }

    public string? Latitude { get; set; }
    public string? Longitude { get; set; }

    public string? BusinessType { get; set; }

    public string? Currency { get; set; }
    public string? TimeZone { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Tax { get; set; }

    public bool IsNasLimit { get; set; }
    public bool IsSubscriberLimit { get; set; }
    public bool IsLicenseDays { get; set; }
    public bool IsDefaultSite { get; set; }

    public DateTime AddDate { get; set; }
    public DateTime? LastUpdate { get; set; }

    public int RoleId { get; set; }
}