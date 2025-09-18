using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI
{
    public class MappingConfig : AutoMapper.Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDTO>().ReverseMap();
            //CreateMap<VillaDTO, Villa>().ReverseMap();
            CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa, VillaUpdateDTO >().ReverseMap();
            // Add this line to support mapping collections
            //CreateMap<List<Villa>, List<VillaDTO>>().ReverseMap();
        }
            // Add other mappings as
            //public MappingConfig()
            //{
            //    CreateMap<Villa, VillaDTO>();
            //    CreateMap<VillaDTO, Villa>();

            //    CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            //    CreateMap<Villa, VillaUpdateDTO>().ReverseMap();
            //}
        }
    }
