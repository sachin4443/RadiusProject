using Microsoft.AspNetCore.Mvc;
using Radius.API.Data;
using Radius.API.Models;

namespace Radius.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login(AdminUser login)
    {
        // 🔹 Check in AdminUsers
        var adminUser = _context.AdminUsers
            .FirstOrDefault(x => x.Username == login.Username && x.Password == login.Password);

        if (adminUser != null)
        {
            return Ok(new
            {
                type = "AdminUser",
                data = adminUser
            });
        }

        // 🔹 Check in CpanlAdminSites (Email + Password)
        var siteUser = _context.CpanlAdminSites
            .FirstOrDefault(x => x.Email == login.Username && x.Password == login.Password);

        if (siteUser != null)
        {
            return Ok(new
            {
                type = "SiteUser",
                data = siteUser
            });
        }

        // ❌ If both fail
        return Unauthorized("Invalid username/email or password");
    }
}