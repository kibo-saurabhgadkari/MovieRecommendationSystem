using MovieRecommendation.Domain.Entities;

namespace MovieRecommendation.Domain.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
        User GetUserById(int userId);
        User GetUserByName(string userName);
        IEnumerable<User> GetAllUsers();
    }
}
