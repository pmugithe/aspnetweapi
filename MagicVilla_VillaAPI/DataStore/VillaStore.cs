using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI.DataStore;

public static class VillaStore
{
    public static List<VillaDTO> Villas = new List<VillaDTO>()
    {
        new VillaDTO{Id = 1, Name = "Villa", Email = "villa@gmail.com", Phone = "123456432", Address = "111 Main Street"},
        new VillaDTO{Id = 2, Name = "Villa2", Email = "villa2@gmail.com", Phone = "1232456432", Address = "222 Main Street"}
    };
}