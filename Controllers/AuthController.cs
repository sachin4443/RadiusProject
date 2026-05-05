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
        if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
        {
            return BadRequest("Email and Password required");
        }

        var email = login.Email.ToLower();

        // 🔹 Admin Login (Email based)
        var adminUser = _context.AdminUsers
            .FirstOrDefault(x => x.Email.ToLower() == email && x.Password == login.Password);

        if (adminUser != null)
        {
            return Ok(new
            {
                type = "AdminUser",
                levelId = 1,
                companyName = "Admin",
                data = adminUser
            });
        }

        // 🔹 Site User Login (Email based)
        var siteUser = _context.CpanlAdminSites
            .FirstOrDefault(x => x.Email.ToLower() == email && x.Password == login.Password);

        if (siteUser != null)
        {
            return Ok(new
            {
                type = "SiteUser",
                levelId = siteUser.LevelID,
                companyName = siteUser.CompanyName,
                data = siteUser
            });
        }

        return Unauthorized("Invalid email or password");
    }

    [HttpGet("menu/{levelId}")]
    public IActionResult GetMenu(int levelId)
    {
        var menus = _context.AdminMenus
            .Where(m => m.IsActive && !m.IsDelete && m.LevelID == levelId)
            .OrderBy(m => m.Position)
            .ToList();

        // 🧠 Parent-child structure
        var parentMenus = menus
            .Where(m => m.ParentID == 0)
            .Select(p => new
            {
                menuID = p.MenuID,
                menuName = p.MenuName,
                controller = p.Controller,
                action = p.Action,
                @class = p.Class,
                children = menus
                    .Where(c => c.ParentID == p.MenuID)
                    .Select(c => new
                    {
                        menuID = c.MenuID,
                        menuName = c.MenuName,
                        controller = c.Controller,
                        action = c.Action,
                        @class = c.Class
                    }).ToList()
            })
            .ToList();

        return Ok(parentMenus);
    }
}