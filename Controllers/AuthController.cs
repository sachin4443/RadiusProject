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

        var email = login.Email.Trim().ToLower();

        // 🔹 Admin Login
        var adminUser = _context.AdminUsers
            .FirstOrDefault(x =>
                x.Email != null &&
                x.Email.ToLower() == email &&
                x.Password == login.Password
            );

        if (adminUser != null)
        {
            return Ok(new
            {
                type = "AdminUser",
                levelId = 1,
                parentCompanyId = 0,
                currentCompanyId = 1,
                companyName = "Admin",
                fullName = "Admin",
                data = adminUser
            });
        }

        // 🔹 Client / Site User Login
        var siteUser = _context.CpanlAdminSites
            .FirstOrDefault(x =>
                x.Email != null &&
                x.Email.ToLower() == email &&
                x.Password == login.Password
            );

        if (siteUser != null)
        {
            return Ok(new
            {
                type = "SiteUser",
                levelId = siteUser.LevelID,
                parentCompanyId = siteUser.ParentCompanyID,

                // ✅ Important: logged-in user's own ID
                currentCompanyId = siteUser.Level1CompanyID,

                companyName = siteUser.CompanyName,
                fullName = siteUser.FullName,
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

        var parentMenus = menus
            .Where(m => m.ParentID == 0)
            .Select(p => new
            {
                menuID = p.MenuID,
                menuName = p.MenuName,
                controller = p.Controller,
                action = p.Action,
                menuStr = p.MenuStr,
                section = p.Section,
                @class = p.Class,

                children = menus
                    .Where(c => c.ParentID == p.MenuID)
                    .OrderBy(c => c.Position)
                    .Select(c => new
                    {
                        menuID = c.MenuID,
                        menuName = c.MenuName,
                        controller = c.Controller,
                        action = c.Action,
                        menuStr = c.MenuStr,
                        section = c.Section,
                        @class = c.Class
                    })
                    .ToList()
            })
            .ToList();

        return Ok(parentMenus);
    }
}