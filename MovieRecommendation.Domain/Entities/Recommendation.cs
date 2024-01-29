namespace MovieRecommendation.Domain.Entities
{
    public class Recommendation
    {
        public Recommendation(Movie movie, double relevanceScore)
        {
            Movie = movie;
            RelevanceScore = relevanceScore;
        }

        public Movie Movie { get; set; }
        public double RelevanceScore { get; set; }
    }
}
