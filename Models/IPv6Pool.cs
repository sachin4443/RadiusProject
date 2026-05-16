using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Radius.API.Models;

[Table("IPv6Pools")]
public class IPv6Pool
{
    [Key]
    public int Id { get; set; }

    public int CompanyID { get; set; }

    public string? PoolName { get; set; }
    public string? Description { get; set; }
    public string? Network { get; set; }
    public int PrefixLength { get; set; }

    public long Total { get; set; }
    public long Used { get; set; }
    public long Free { get; set; }

    public DateTime AddDate { get; set; }
}