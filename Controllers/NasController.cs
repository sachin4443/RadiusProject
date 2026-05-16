using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Radius.API.Data;
using Radius.API.Models;

namespace Radius.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NasController : ControllerBase
{
    private readonly AppDbContext _context;

    public NasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{companyId}")]
    public async Task<IActionResult> Get(int companyId)
    {
        var data = await _context.Nas
            .Where(x => x.CompanyID == companyId)
            .OrderByDescending(x => x.Id)
            .ToListAsync();

        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Save(Nas model)
    {
        if (model.CompanyID == 0)
            return BadRequest("CompanyID required");

        model.AddDate = DateTime.Now;

        if (model.CoaPort == 0)
            model.CoaPort = 3799;

        if (model.TTL == 0)
            model.TTL = 0;

        _context.Nas.Add(model);
        await _context.SaveChangesAsync();

        return Ok(model);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _context.Nas.FindAsync(id);

        if (data == null)
            return NotFound();

        _context.Nas.Remove(data);
        await _context.SaveChangesAsync();

        return Ok();
    }
}