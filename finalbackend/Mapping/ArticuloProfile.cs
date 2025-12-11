using AlmacenMvc.Dtos;
using AlmacenMvc.Models;
using AutoMapper;

namespace AlmacenMvc.Mapping
{
    public class ArticuloProfile : Profile
    {
        public ArticuloProfile()
        {
            CreateMap<Articulo, ArticuloDto>().ReverseMap();
        }
    }
}
