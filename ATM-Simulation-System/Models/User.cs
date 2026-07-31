namespace Models
{
    public class User
    {
        public string UserId { get; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public User(string userId,string name, string phone)
        {
            UserId = userId;
            Name = name;
            Phone = phone;
        }
    }
}