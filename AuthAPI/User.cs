namespace AuthAPI
{
    public class User
    {

        public User(string username, string password, string role, string[] scope)
        {
            Username = username;
            Password = password;
            Role = role;
            Scope = scope;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string[] Scope { get; set; }
    }
}
