namespace Entities
{
    public class LoginInfo
    {
        public int ID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}