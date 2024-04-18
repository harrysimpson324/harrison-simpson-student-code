namespace TodosServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        public User(int id, string username, string passwordHash, string salt, string role)
        {
            Id = id;
            Username = username;
            PasswordHash = passwordHash;
            Salt = salt;
            Role = role;
        }
    }

    /// <summary>
    /// Contains just the properties to return for a logged in user
    /// </summary>
    public class ReturnUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }

    /// <summary>
    /// Contains the properties for a user to login
    /// </summary>
    public class LoginUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
