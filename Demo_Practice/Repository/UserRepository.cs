using Demo_Practice.Context;
using Demo_Practice.Interfaces;
using Demo_Practice.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_Practice.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly GymDbContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(GymDbContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<User> Add(User user)
        {
            var users = _context.Users.ToList();
            var _user = users.FirstOrDefault(u => u.Username == user.Username);

            if(_user == null)
            {
                _context.Add(user);
                _context.SaveChanges();
                _logger.LogInformation("User added with UserId " + user.UserId);
                return user;
            }

            throw new Exception();
        }

        public async Task<User> Delete(int userId)
        {
            var user = await GetAsync(userId);
            if (user != null)
            {
                _context.Remove(user);
                _context.SaveChanges();
                _logger.LogInformation($"User removed with userId {userId}");
                return user;
            }
            throw new Exception();
        }

        public async Task<User> GetAsync(int userId)
        {
            var users = await GetAsync();
            var user = users.FirstOrDefault(e => e.UserId == userId);
            if (user != null)
            {
                return user;
            }
            throw new Exception();
        }

        public async Task<List<User>> GetAsync()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public async Task<User> Update(User item)
        {
            var user = await GetAsync(item.UserId);
            if (user != null)
            {
                _context.Entry(user).CurrentValues.SetValues(item);
                _context.SaveChanges();
                _logger.LogInformation($"User updated with UserId {item.UserId}");
                return user;
            }
            throw new Exception();
        }

        public async Task<User> Login(string username, string password)
        {
            var users = _context.Users.ToList();
            var user1 = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            var user2 = users.FirstOrDefault(u => u.Email == username && u.Password == password);

            if (user1 != null && user2 == null)
            {
                return user1;
            }
            else if (user1 == null && user2 != null)
            {
                return user2;
            }
            
            throw new Exception();
        }
    }
}

