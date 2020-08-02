using System;

namespace AngularBlog.Infrastructure.Data.DTO
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; } // TODO NodaTime instead of DateTime
        public AuthorDto Author { get; set; }
        public string Content { get; set; }
    }
}