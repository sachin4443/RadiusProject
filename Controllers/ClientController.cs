using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Radius.API.Data;

namespace Radius.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("dashboard/{parentCompanyId}")]
        public async Task<IActionResult> Dashboard(int parentCompanyId)
        {
            // ✅ Sirf 3rd layer Sites count hongi
            var totalSites = await _context.CpanlAdminSites
                .CountAsync(x =>
                    x.ParentCompanyID == parentCompanyId &&
                    x.LevelID == 3
                );

            var activeSites = await _context.CpanlAdminSites
                .CountAsync(x =>
                    x.ParentCompanyID == parentCompanyId &&
                    x.LevelID == 3 &&
                    x.IsEnabled == true
                );

            return Ok(new
            {
                totalSites,
                activeSites,
                totalSubscribers = 0,
                onlineSubscribers = 0,
                activeSubscribers = 0,
                expiredSubscribers = 0,
                expiringTomorrow = 0,
                expiringToday = 0,
                accountUnverified = 0,
                pendingAdvanceRecharge = 0,
                activeOfflineSubscribers = 0
            });
        }

        [HttpGet("sites/{parentCompanyId}")]
        public async Task<IActionResult> Sites(int parentCompanyId)
        {
            // ✅ Sirf login client ke under wali sites aayengi
            var data = await _context.CpanlAdminSites
                .Where(x =>
                    x.ParentCompanyID == parentCompanyId &&
                    x.LevelID == 3
                )
                .OrderByDescending(x => x.Level1CompanyID)
                .ToListAsync();

            return Ok(data);
        }
    }
}