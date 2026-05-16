using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Radius.API.Models;

[Table("Nas")]
public class Nas
{
    [Key]
    public int Id { get; set; }

    public int CompanyID { get; set; }

    public string? IpAddress { get; set; }
    public string? ShortName { get; set; }
    public string? Secret { get; set; }
    public string? NasType { get; set; }

    public int CoaPort { get; set; }
    public int TTL { get; set; }

    public bool IsEnabled { get; set; }

    public DateTime AddDate { get; set; }
}
