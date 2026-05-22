using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Radius.API.Data;
using Radius.API.Models;

namespace Radius.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PackagesController : ControllerBase
{
    private readonly AppDbContext _context;

    public PackagesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{companyId}")]
    public async Task<IActionResult> Get(int companyId)
    {
        var data = await _context.Packages
            .Where(x => x.CompanyID == companyId)
            .OrderByDescending(x => x.Id)
            .ToListAsync();

        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Save(Package model)
    {
        if (model.CompanyID == 0)
            return BadRequest("CompanyID required");

        if (string.IsNullOrWhiteSpace(model.PackageName))
            return BadRequest("Package Name required");

        model.Type = "Regular";
        model.AddDate = DateTime.Now;

        _context.Packages.Add(model);
        await _context.SaveChangesAsync();

        return Ok(model);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _context.Packages.FindAsync(id);

        if (data == null)
            return NotFound();

        _context.Packages.Remove(data);
        await _context.SaveChangesAsync();

        return Ok();
    }
}