using AutoMapper;
using EF = MovieRecommendation.Infrastructure.Entities;
using D = MovieRecommendation.Domain.Entities;

namespace MovieRecommendation.Infrastructure.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<EF.User, D.User>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles));
            //generate for all members

            CreateMap<D.User, EF.User>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles));
        }
    }

    public static class UserExtensions
    {
        public static D.User ToDomain(this EF.User user)
        {
            return Mapper.Map<EF.User, D.User>(user);
        }

        public static List<D.User> ToDomain(this List<EF.User> user)
        {
            return user.Select(m => m.ToDomain()).ToList();
        }

        public static EF.User ToEntity(this D.User user)
        {
            return Mapper.Map<D.User, EF.User>(user);
        }
    }
}
