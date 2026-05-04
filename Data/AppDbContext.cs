using Microsoft.EntityFrameworkCore;
using Radius.API.Models;

namespace Radius.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<AdminUser> AdminUsers { get; set; }  
    public DbSet<AdminMenu> AdminMenus { get; set; }
    public DbSet<CpanlAdminSite> CpanlAdminSites { get; set; }
}