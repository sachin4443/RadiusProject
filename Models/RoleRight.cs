using System.ComponentModel.DataAnnotations;

namespace Radius.API.Models;

public class RoleRight
{
    [Key]
    public int Id { get; set; }

    public int RoleId { get; set; }

    public int MenuId { get; set; }

    public bool CanView { get; set; }

    public bool CanAdd { get; set; }

    public bool CanEdit { get; set; }

    public bool CanDelete { get; set; }
}