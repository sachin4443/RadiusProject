using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Radius.API.Data;

namespace Radius.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var now = DateTime.Now;

        var totalSites = await _context.CpanlAdminSites.CountAsync();

        var currentMonthSites = await _context.CpanlAdminSites
            .Where(x => x.AddDate.Month == now.Month && x.AddDate.Year == now.Year)
            .CountAsync();

        return Ok(new
        {
            activeSites = totalSites,
            liveSites = totalSites,
            currentMonthSites = currentMonthSites,

            onlineSubscribers = currentMonthSites
        });
    }
}