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

    // ✅ CLIENT WISE SITES
    [HttpGet("manage/{parentCompanyId}")]
    public async Task<IActionResult> GetSitesByParent(int parentCompanyId)
    {
        var data = await _context.CpanlAdminSites
            .Where(x =>
                x.ParentCompanyID == parentCompanyId &&
                x.LevelID == 3
            )
            .OrderByDescending(x => x.Level1CompanyID)
            .ToListAsync();

        return Ok(data);
    }

    // ✅ ADMIN: GET ALL SITES ONLY
    [HttpGet("manage")]
    public async Task<IActionResult> GetSites()
    {
        var data = await _context.CpanlAdminSites
            .Where(x => x.LevelID == 3)
            .OrderByDescending(x => x.Level1CompanyID)
            .ToListAsync();

        return Ok(data);
    }

    // ✅ REGISTER SITE
    [HttpPost("register")]
    public async Task<IActionResult> Register(CpanlAdminSite model)
    {
        // ✅ Site hamesha 3rd layer hogi
        model.LevelID = 3;

        // ✅ ParentCompanyID frontend se currentCompanyId aani chahiye
        if (model.ParentCompanyID == 0)
        {
            model.ParentCompanyID = 1;
        }

        model.AddDate = DateTime.Now;
        model.LastUpdate = DateTime.Now;

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