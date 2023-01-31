using AutoMapper;
using Udemy_Api.Model.Domain;
using Udemy_Api.Model.DTO;

namespace Udemy_Api.Profiles
{
    public class RegionsProfile : Profile
    {

        public RegionsProfile()
        {
            CreateMap<Model.Domain.Region, Model.DTO.Region>()
                .ReverseMap();
        }
    }
}
