using System.ComponentModel.DataAnnotations;

namespace Radius.API.Models;

public class Right
{
    [Key]
    public int Id { get; set; }

    public string? RightName { get; set; }

    public bool IsActive { get; set; }

    public DateTime AddDate { get; set; }
}