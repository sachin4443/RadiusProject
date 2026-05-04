using Microsoft.AspNetCore.Mvc;
using Radius.API.Data;
using Radius.API.Models;

namespace Radius.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login(AdminUser login)
    {
        var user = _context.AdminUsers
            .FirstOrDefault(x => x.Username == login.Username && x.Password == login.Password);

        if (user == null)
            return Unauthorized("Invalid username or password");

        return Ok(user);
    }
}