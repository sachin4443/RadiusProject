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
        if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
        {
            return BadRequest("Email and Password required");
        }

        var email = login.Email.Trim().ToLower();
        var password = login.Password.Trim();

        var adminUser = _context.AdminUsers
            .FirstOrDefault(x =>
                x.Email != null &&
                x.Email.Trim().ToLower() == email &&
                x.Password != null &&
                x.Password.Trim() == password
            );

        if (adminUser != null)
        {
            return Ok(new
            {
                type = "AdminUser",
                levelId = 1,
                parentCompanyId = 0,
                currentCompanyId = 1,

                roleId = 1,
                roleName = "Super Admin",

                rights = new
                {
                    canView = true,
                    canAdd = true,
                    canEdit = true,
                    canDelete = true
                },

                companyName = "Admin",
                fullName = "Admin",
                data = adminUser
            });
        }

        var siteUser = _context.CpanlAdminSites
            .FirstOrDefault(x =>
                x.Email != null &&
                x.Email.Trim().ToLower() == email &&
                x.Password != null &&
                x.Password.Trim() == password
            );

        if (siteUser != null)
        {
            var roleName =
                siteUser.LevelID == 1 ? "Super Admin" :
                siteUser.LevelID == 2 ? "Client" :
                siteUser.LevelID == 3 ? "Site Admin" :
                siteUser.Role ?? "User";

            var roleId =
                siteUser.LevelID == 1 ? 1 :
                siteUser.LevelID == 2 ? 2 :
                siteUser.LevelID == 3 ? 3 : 4;

            return Ok(new
            {
                type = siteUser.LevelID == 1 ? "AdminUser" : "SiteUser",

                levelId = siteUser.LevelID,
                parentCompanyId = siteUser.ParentCompanyID,
                currentCompanyId = siteUser.Level1CompanyID,

                roleId = roleId,
                roleName = roleName,

                rights = new
                {
                    canView = true,
                    canAdd = siteUser.LevelID != 3,
                    canEdit = siteUser.LevelID != 3,
                    canDelete = siteUser.LevelID == 1
                },

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