using MagicVilla_VillaAPI.DataStore;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers;
[Route("api/[controller]")]
//instead of hard coding, we can use [controller], it'll dynamically points to corresponding controller
[ApiController]
public class VillaController : ControllerBase
{
    //ActionResult to use and send what kind of response we're going to handle
    [HttpGet,ActionName("GetVilla")]
    public ActionResult<IEnumerable<VillaDTO>> GetVilla()
    {
        return Ok(VillaStore.Villas);

    }
    [HttpGet("getByid", Name = "GetById")]
    //to work on the responses 
    [ProducesResponseType( StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult< VillaDTO> GetVillaById(int id)
    {
        //if no item, send BadRequest
        if (id == 0)
        {
            return BadRequest();
        }
        var villa = VillaStore.Villas.FirstOrDefault(v=>v.Id==id);
        if (villa == null)
        {
            return NotFound();
        } 
        return Ok(villa);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<VillaDTO> PostVilla([FromBody]VillaDTO villa)
    {
        villa.Id = VillaStore.Villas.OrderByDescending(v => v.Id).FirstOrDefault().Id+1;
        System.Console.WriteLine(villa.Id);
        VillaStore.Villas.Add(villa);
        return  CreatedAtRoute("GetById",new { id = villa.Id }, villa);
    }

    [HttpDelete("villaId", Name = "DeleteById")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeleteVillaById(int villaId)
    {
        if (villaId == 0)
        {
            return BadRequest();
        }
        var villa = VillaStore.Villas.FirstOrDefault(v => v.Id == villaId);
        if (villa == null)
        {
            return NotFound();
        }
        VillaStore.Villas.Remove(villa);
        return NoContent();
    }
}
