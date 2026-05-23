using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Radius.API.Data;
using Radius.API.Models;

namespace Radius.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscribersController : ControllerBase
{
    private readonly AppDbContext _context;

    public SubscribersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{companyId}")]
    public async Task<IActionResult> Get(int companyId)
    {
        var data = await _context.Subscribers
            .Where(x => x.CompanyID == companyId)
            .OrderByDescending(x => x.Id)
            .ToListAsync();

        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Save(Subscriber model)
    {
        if (model.CompanyID == 0)
            return BadRequest("CompanyID required");

        if (string.IsNullOrWhiteSpace(model.Username))
            return BadRequest("Username required");

        model.Status ??= "Active";
        model.AddDate = DateTime.Now;
        model.LastUpdate = DateTime.Now;

        _context.Subscribers.Add(model);
        await _context.SaveChangesAsync();

        return Ok(model);
    }

    [HttpPost("search")]
    public async Task<IActionResult> Search(Subscriber model)
    {
        var query = _context.Subscribers.AsQueryable();

        if (model.CompanyID > 0)
            query = query.Where(x => x.CompanyID == model.CompanyID);

        if (!string.IsNullOrWhiteSpace(model.Username))
            query = query.Where(x => x.Username!.Contains(model.Username));

        if (!string.IsNullOrWhiteSpace(model.FullName))
            query = query.Where(x => x.FullName!.Contains(model.FullName));

        if (!string.IsNullOrWhiteSpace(model.Email))
            query = query.Where(x => x.Email!.Contains(model.Email));

        if (!string.IsNullOrWhiteSpace(model.MobileNo))
            query = query.Where(x => x.MobileNo!.Contains(model.MobileNo));

        if (!string.IsNullOrWhiteSpace(model.Status) && model.Status != "All")
            query = query.Where(x => x.Status == model.Status);

        if (!string.IsNullOrWhiteSpace(model.Package) && model.Package != "All")
            query = query.Where(x => x.Package == model.Package);

        if (!string.IsNullOrWhiteSpace(model.Nas) && model.Nas != "All")
            query = query.Where(x => x.Nas == model.Nas);

        var data = await query
            .OrderByDescending(x => x.Id)
            .ToListAsync();

        return Ok(data);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _context.Subscribers.FindAsync(id);

        if (data == null)
            return NotFound();

        _context.Subscribers.Remove(data);
        await _context.SaveChangesAsync();

        return Ok();
    }
}