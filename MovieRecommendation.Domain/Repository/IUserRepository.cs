using MovieRecommendation.Domain.Entities;

namespace MovieRecommendation.Domain.Repository
{
    public interface IUserRepository
    {
        int AddUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
        User GetUserById(int userId);
        User GetUserByUserName(string userName);
        IEnumerable<User> GetAllUsers();
        bool IsUsernameTaken(string username);
    }
}
