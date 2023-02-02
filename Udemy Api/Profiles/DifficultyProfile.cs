using AutoMapper;

namespace Udemy_Api.Profiles
{
    public class DifficultyProfile : Profile
    {
        public DifficultyProfile()
        {
            CreateMap<Model.Domain.WalkDifficulty, Model.DTO.WalkDifficulty>();
        }
    }
}
