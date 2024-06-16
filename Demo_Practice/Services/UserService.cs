using Demo_Practice.Interfaces;
using Demo_Practice.Models;
using Demo_Practice.Repository;
using System.Diagnostics.Metrics;

namespace Demo_Practice.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task<User> AddUser(User user)
        {
            return await _userRepository.Add(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _userRepository.GetAsync(userId);
        }

        public async Task<User> RemoveUser(int userId)
        {
            var member = await _userRepository.GetAsync(userId);
            if (member != null)
            {
                await _userRepository.Delete(userId);
                return member;
            }

            return null;
        }

        public async Task<User> Updateuser(User user)
        {
            var _user = await _userRepository.GetAsync(user.UserId);
            if (_user != null)
            {
                _user = await _userRepository.Update(user);
                return _user;
            }

            return null;
        }

        public async Task<User> LoginUser(string username, string password)
        {
            return await _userRepository.Login(username, password);
        }
    }
}
