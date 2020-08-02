using System.Collections.Generic;

namespace AngularBlog.Domain.Models
{
    public class User : IdEntity<int>
    {
        public string Email { get; set; }
        public string Password { get; set; } // TODO secure somehow
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}