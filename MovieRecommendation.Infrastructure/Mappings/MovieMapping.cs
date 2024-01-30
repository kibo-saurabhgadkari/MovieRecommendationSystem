using AutoMapper;
using EF = MovieRecommendation.Infrastructure.Entities;
using D = MovieRecommendation.Domain.Entities;

namespace MovieRecommendation.Infrastructure.Mappings
{
    public class MovieMapping : Profile
    {
        public MovieMapping()
        {
            CreateMap<EF.Movie, D.Movie>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genres))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Directors));

            CreateMap<D.Movie, EF.Movie>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Director));
        }        
    }

    public static class MovieExtensions
    {
        public static D.Movie ToDomain(this EF.Movie movie)
        {
            return Mapper.Map<EF.Movie, D.Movie>(movie);
        }

        public static List<D.Movie> ToDomain(this List<EF.Movie> movie)
        {
            return movie.Select(m => m.ToDomain()).ToList();
        }

        public static EF.Movie ToEntity(this D.Movie movie)
        {
            return Mapper.Map<D.Movie, EF.Movie>(movie);
        }
    }
}
