using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Radius.API.Models;

[Table("IPv4Pools")]
public class IPv4Pool
{
    [Key]
    public int Id { get; set; }

    public int CompanyID { get; set; }

    public string? PoolName { get; set; }
    public string? Description { get; set; }
    public string? FromIP { get; set; }
    public string? ToIP { get; set; }

    public int Total { get; set; }
    public int Used { get; set; }
    public int Free { get; set; }

    public DateTime AddDate { get; set; }
}