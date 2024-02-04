using AutoMapper;
using MovieRecommendation.Infrastructure.Mappings;

namespace MovieRecommendation.Presentation
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                // Add your mappings here
                cfg.AddProfile<MovieMapping>();
                cfg.AddProfile<UserMapping>();
            });

            // Initialize AutoMapper with the configuration
            configuration.AssertConfigurationIsValid();
            configuration.CompileMappings();

            IMapper mapper = configuration.CreateMapper();
            Mapper.Initialize(cfg => cfg.AddMaps(typeof(AutoMapperConfig).Assembly));
            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
