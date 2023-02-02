using AutoMapper;
using Udemy_Api.Model.Domain;
using Udemy_Api.Model.DTO;


namespace Udemy_Api.Profiles
{
    public class WalksProfile : Profile
    {

        public WalksProfile()
        {
            //Both ways are correct


            //CreateMap(typeof(Model.Domain.Walk), typeof(Model.DTO.Walk))
            //    .ReverseMap();


            CreateMap<Model.Domain.Walk, Model.DTO.Walk>()
                .ReverseMap();
        }
    }
}
