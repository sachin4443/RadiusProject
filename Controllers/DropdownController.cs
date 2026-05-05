using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Radius.API.Data;

namespace Radius.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropdownController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DropdownController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/dropdown/countries
        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _context.Countries
                .OrderBy(x => x.CountryName)
                .Select(x => new
                {
                    x.Id,
                    x.CountryName,
                    x.CountryCode,
                    x.CurrencyCode
                })
                .ToListAsync();

            return Ok(countries);
        }

        // GET: api/dropdown/currencies
        [HttpGet("currencies")]
        public async Task<IActionResult> GetCurrencies()
        {
            var currencies = await _context.Currencies
                .OrderBy(x => x.CurrencyName)
                .Select(x => new
                {
                    x.Id,
                    x.CurrencyName,
                    x.CurrencyCode
                })
                .ToListAsync();

            return Ok(currencies);
        }

        // GET: api/dropdown/timezones
        [HttpGet("timezones")]
        public async Task<IActionResult> GetTimeZones()
        {
            var timeZones = await _context.CountryTimeZones
                .OrderBy(x => x.CountryName)
                .Select(x => new
                {
                    x.Id,
                    x.CountryName,
                    x.CountryCode,
                    x.TimeZoneId,
                    x.TimeZoneName,
                    x.UtcOffset
                })
                .ToListAsync();

            return Ok(timeZones);
        }

        // GET: api/dropdown/timezones/IN
        [HttpGet("timezones/{countryCode}")]
        public async Task<IActionResult> GetTimeZonesByCountry(string countryCode)
        {
            var timeZones = await _context.CountryTimeZones
                .Where(x => x.CountryCode == countryCode)
                .OrderBy(x => x.TimeZoneName)
                .Select(x => new
                {
                    x.Id,
                    x.TimeZoneId,
                    x.TimeZoneName,
                    x.UtcOffset
                })
                .ToListAsync();

            return Ok(timeZones);
        }
    }
}