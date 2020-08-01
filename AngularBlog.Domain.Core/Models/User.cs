namespace AngularBlog.Domain.Models
{
    public class User : IdEntity<int>
    {
        public string Email { get; set; }
        public string Password { get; set; } // TODO secure somehow
    }
}