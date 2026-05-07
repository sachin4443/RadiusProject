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
    [HttpGet("manage/{parentCompanyId}")]
    public async Task<IActionResult> GetSitesByParent(int parentCompanyId)
    {
        var data = await _context.CpanlAdminSites
            .Where(x => x.ParentCompanyID == parentCompanyId)
            .OrderByDescending(x => x.Level1CompanyID)
            .ToListAsync();

        return Ok(data);
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

    [HttpPost("register")]
    public async Task<IActionResult> Register(CpanlAdminSite model)
    {
        model.AddDate = DateTime.Now;

        // agar frontend se ParentCompanyID nahi aa rahi
        if (model.ParentCompanyID == 0)
        {
            model.ParentCompanyID = 1;
        }

        _context.CpanlAdminSites.Add(model);
        await _context.SaveChangesAsync();

        // site create hone ke baad uska LevelID set kar do
        if (model.LevelID == 0)
        {
            model.LevelID = model.Level1CompanyID;
            await _context.SaveChangesAsync();
        }

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