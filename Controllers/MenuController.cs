using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Radius.API.Data;
using Radius.API.Models;

namespace Radius.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly AppDbContext _context;

    public MenuController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetMenus()
    {
        var menus = await _context.AdminMenus
            .Where(x => x.IsActive && !x.IsDelete)
            .OrderBy(x => x.Position)
            .ToListAsync();

        var result = menus
            .Where(x => x.ParentID == 0)
            .Select(parent => new
            {
                parent.MenuID,
                parent.MenuName,
                parent.Class,
                parent.Controller,
                parent.Action,
                parent.Section,
                parent.LevelID,

                Children = menus
                    .Where(c => c.ParentID == parent.MenuID)
                    .Select(c => new
                    {
                        c.MenuID,
                        c.MenuName,
                        c.Class,
                        c.Controller,
                        c.Action,
                        c.Section,
                        c.LevelID
                    })
                    .OrderBy(c => c.MenuID)
            });

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var menu = await _context.AdminMenus.FindAsync(id);

        if (menu == null || menu.IsDelete)
            return NotFound("Menu not found");

        return Ok(menu);
    }

    [HttpPost]
    public async Task<IActionResult> AddMenu([FromBody] AdminMenu menu)
    {
        if (string.IsNullOrEmpty(menu.MenuName))
            return BadRequest("Menu name is required");

        menu.AddDate = DateTime.Now;
        menu.IsActive = true;
        menu.IsDelete = false;

        _context.AdminMenus.Add(menu);
        await _context.SaveChangesAsync();

        return Ok(menu);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMenu(int id, [FromBody] AdminMenu menu)
    {
        var existing = await _context.AdminMenus.FindAsync(id);

        if (existing == null)
            return NotFound("Menu not found");

        existing.MenuName = menu.MenuName;
        existing.ParentID = menu.ParentID;
        existing.Controller = menu.Controller;
        existing.Action = menu.Action;
        existing.Class = menu.Class;
        existing.Position = menu.Position;
        existing.MenuLevel = menu.MenuLevel;
        existing.LevelID = menu.LevelID;

        await _context.SaveChangesAsync();

        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMenu(int id)
    {
        var menu = await _context.AdminMenus.FindAsync(id);

        if (menu == null)
            return NotFound("Menu not found");

        var hasChildren = await _context.AdminMenus
            .AnyAsync(x => x.ParentID == id && !x.IsDelete);

        if (hasChildren)
            return BadRequest("Cannot delete menu with submenus");

        menu.IsDelete = true;

        await _context.SaveChangesAsync();

        return Ok("Menu deleted successfully");
    }
}