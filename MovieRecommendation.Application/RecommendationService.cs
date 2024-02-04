using MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Handlers;

namespace MovieRecommendation.Application
{
    public class RecommendationService
    {
        IRecommendationHandler _recommendationHandler;

        public RecommendationService(IRecommendationHandler recommendationHandler)
        {
            _recommendationHandler = recommendationHandler;
        }                

        public List<Recommendation> GetRecommendations(int userId)
        {
            return _recommendationHandler.GetRecommendations(userId);
        }
    }
}
