using AutoMapper;
using MagicVilla_VillaAPI.DataStore;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MagicVilla_VillaAPI.Controllers;
[Route("api/[controller]")]
//instead of hard coding, we can use [controller], it'll dynamically points to corresponding controller
[ApiController]
public class VillaController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly AutoMapper.IMapper _mapper;
    public VillaController(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    //ActionResult to use and send what kind of response we're going to handle
    [HttpGet,ActionName("GetVilla")]
    public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVilla()
    {
        IEnumerable<Villa> villaList = await _db.Villas.ToListAsync();

        return Ok(_mapper.Map<List<VillaDTO>>(villaList));

    }
    [HttpGet("getByid", Name = "GetById")]
    //to work on the responses 
    [ProducesResponseType( StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<VillaDTO>> GetVillaById(int id)
    {
        //if no item, send BadRequest
        if (id == 0)
        {
            return BadRequest();
        }
        var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);
        if (villa == null)
        {
            return NotFound();
        } 
        return Ok(_mapper.Map<VillaDTO>(villa));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VillaDTO>> PostVilla([FromBody]VillaCreateDTO createDTO)
    {
        if (createDTO == null)
        {
            return BadRequest(createDTO);
        }
         Villa model = _mapper.Map<Villa>(createDTO);
        
        //Villa model = new()
        //{
            
        //    Name = createDTO.Name,
        //    Details = createDTO.Details,
        //    Rate = createDTO.Rate,
        //    Sqft = createDTO.Sqft,
        //    Occupancy = createDTO.Occupancy,
        //    ImageUrl = createDTO.ImageUrl,
        //    Amenity = createDTO.Amenity
        //};
        
        // Replace this line in PostVilla method:
        // await _db.SaveChanges();
        // With the correct async version:
        await _db.SaveChangesAsync();
        return  CreatedAtRoute("GetById",new { id = model.Id }, model);
    }

    [HttpDelete("villaId", Name = "DeleteById")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteVillaById(int villaId)
    {
        if (villaId == 0)
        {
            return BadRequest();
        }
        var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == villaId);
        if (villa == null)
        {
            return NotFound();
        }
        _db.Villas.Remove(villa);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
