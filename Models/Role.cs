using System.ComponentModel.DataAnnotations;

namespace Radius.API.Models;

public class Role
{
    [Key]
    public int Id { get; set; }

    public string? RoleName { get; set; }

    public bool IsActive { get; set; }

    public DateTime AddDate { get; set; }
}