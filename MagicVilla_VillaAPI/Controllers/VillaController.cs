using MagicVilla_VillaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers;
[Route("api/[controller]")]
//instead of hard coding, we can use [controller], it'll dynamically points to corresponding controller
[ApiController]
public class VillaController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Villa> GetVilla()
    {
        return new Villa[]
        {
            new Villa { Id = 1, Name = "Villa", Phone = "12345678" , Email = "villa@example.com" , Address = "123 Main"},
        };

    }
}