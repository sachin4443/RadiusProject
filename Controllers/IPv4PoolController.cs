using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Radius.API.Data;
using Radius.API.Models;

namespace Radius.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IPv4PoolController : ControllerBase
{
    private readonly AppDbContext _context;

    public IPv4PoolController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{companyId}")]
    public async Task<IActionResult> Get(int companyId)
    {
        var data = await _context.IPv4Pools
            .Where(x => x.CompanyID == companyId)
            .OrderByDescending(x => x.Id)
            .ToListAsync();

        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Save(IPv4Pool model)
    {
        if (model.CompanyID == 0)
            return BadRequest("CompanyID required");

        model.AddDate = DateTime.Now;
        model.Used = 0;
        model.Free = model.Total;

        _context.IPv4Pools.Add(model);
        await _context.SaveChangesAsync();

        return Ok(model);
    }
}