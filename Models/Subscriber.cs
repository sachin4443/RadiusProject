using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Radius.API.Models;

[Table("Subscribers")]
public class Subscriber
{
    [Key]
    public int Id { get; set; }

    public int CompanyID { get; set; }
    public int SiteID { get; set; }

    public string? Username { get; set; }
    public string? FullName { get; set; }
    public string? CompanyName { get; set; }
    public string? Email { get; set; }
    public string? MobileNo { get; set; }
    public string? PhoneNo { get; set; }

    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Zip { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }

    public string? TaxNo { get; set; }
    public string? PortalUsername { get; set; }
    public string? Comment { get; set; }
    public string? MacAddress { get; set; }

    public string? SubscriberType { get; set; }
    public string? SubscriberGroup { get; set; }
    public string? Nas { get; set; }
    public string? Package { get; set; }
    public string? BillingType { get; set; }

    public bool IsEnabled { get; set; }
    public bool AutoRenew { get; set; }
    public bool ClosedConnection { get; set; }

    public string? IPv4Mode { get; set; }
    public string? StaticIPv4Address { get; set; }
    public string? IPv4Pool { get; set; }
    public string? IPv6Prefix { get; set; }
    public string? IPv6Delegation { get; set; }

    public string? Zone { get; set; }
    public string? Node { get; set; }
    public string? NasPortID { get; set; }

    public string? Status { get; set; }

    public DateTime? DateExpired { get; set; }
    public DateTime AddDate { get; set; }
    public DateTime? LastUpdate { get; set; }
}
