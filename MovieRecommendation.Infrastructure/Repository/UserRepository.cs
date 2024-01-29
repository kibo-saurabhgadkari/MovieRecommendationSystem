using D = MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Repository;

namespace MovieRecommendation.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieDbContext _context;
        public UserRepository(MovieDbContext context)
        {
            _context = context;
        }
        public void AddUser(D.User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(D.User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<D.User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public D.User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public D.User GetUserByName(string userName)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(D.User user)
        {
            throw new NotImplementedException();
        }
    }
}
