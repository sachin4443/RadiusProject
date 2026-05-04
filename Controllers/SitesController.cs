using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Radius.API.Data;
using Radius.API.Models;

namespace Radius.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SitesController : ControllerBase
{
    private readonly AppDbContext _context;

    public SitesController(AppDbContext context)
    {
        _context = context;
    }

    // ✅ GET ALL
    [HttpGet("manage")]
    public async Task<IActionResult> GetSites()
    {
        var data = await _context.CpanlAdminSites
            .OrderByDescending(x => x.Level1CompanyID)
            .ToListAsync();

        return Ok(data);
    }

    // ✅ REGISTER
    [HttpPost("register")]
    public async Task<IActionResult> Register(CpanlAdminSite model)
    {
        model.AddDate = DateTime.Now;

        _context.CpanlAdminSites.Add(model);
        await _context.SaveChangesAsync();

        return Ok(model);
    }

    // ✅ DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _context.CpanlAdminSites.FindAsync(id);

        if (data == null)
            return NotFound();

        _context.CpanlAdminSites.Remove(data);
        await _context.SaveChangesAsync();

        return Ok();
    }
}