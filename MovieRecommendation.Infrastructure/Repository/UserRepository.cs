using D = MovieRecommendation.Domain.Entities;
using MovieRecommendation.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using MovieRecommendation.Infrastructure.Mappings;

namespace MovieRecommendation.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieDbContext _context;
        public UserRepository(MovieDbContext context)
        {
            _context = context;
        }
        public int AddUser(D.User user)
        {
            var entity = user.ToEntity();
            _context.Users.Add(entity);
            _context.SaveChanges();

            return entity.UserId;
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

        public D.User GetUserByUserName(string userName)
        {
            //var user = _dbContext.Users.Include(u => u.Password).FirstOrDefault(u => u.UserName == userName);
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            
            if (user == null)
            {
                throw new Exception("No such user");
            }

            return user.ToDomain();
        }

        public bool IsUsernameTaken(string username)
        {
            return _context.Users.Count(u=> u.UserName == username) > 0;
        }

        public void UpdateUser(D.User user)
        {
            throw new NotImplementedException();
        }
    }
}
