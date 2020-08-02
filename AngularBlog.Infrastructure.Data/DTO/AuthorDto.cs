using System.Collections.Generic;

namespace AngularBlog.Infrastructure.Data.DTO
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<PostDto> Posts { get; set; } = new List<PostDto>();
    }
}