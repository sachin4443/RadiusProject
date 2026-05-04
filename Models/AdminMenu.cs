using System.ComponentModel.DataAnnotations;

namespace Radius.API.Models;

public class AdminMenu
{
    [Key]
    public int MenuID { get; set; }
    public string? MenuName { get; set; }
    public string? Controller { get; set; }
    public string? Action { get; set; }
    public int MenuLevel { get; set; }
    public int ParentID { get; set; }
    public string? MenuStr { get; set; }
    public int Position { get; set; }
    public string? Class { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
    public DateTime AddDate { get; set; }
    public DateTime? LastUpdate { get; set; }
    public string? Section { get; set; } 

}