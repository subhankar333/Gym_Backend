using System.ComponentModel.DataAnnotations;

namespace Demo_Practice.Models
{
    public class User
    {
        [Key]
        public int UserId {  get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        public User()
        {
            UserId = 0;
        }

        public User(int userId,string username, string password, string email, bool isadmin)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Email = email;
            IsAdmin = isadmin;
        }

        
    }
}
