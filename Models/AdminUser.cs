using System.ComponentModel.DataAnnotations;

namespace Radius.API.Models;

public class AdminUser
{
    [Key]
    public int Id { get; set; }
    public int LevelID { get; set; }
    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}