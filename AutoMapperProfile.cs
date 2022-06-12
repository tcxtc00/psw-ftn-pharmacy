using AutoMapper;
using psw_ftn_pharmacy.Dtos;
using psw_ftn_pharmacy.Model;

namespace psw_ftn_pharmacy
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Recipe, RecipeDto>();
            CreateMap<RecipeDto, Recipe>();
        }
    }
}