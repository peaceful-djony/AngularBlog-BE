using System;

namespace AngularBlog.Infrastructure.Data.DTO
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // TODO rename to CratedAt
        // TODO NodaTime instead of DateTime
        public DateTime DateTime { get; set; }
        public AuthorDto Author { get; set; }
        public string Content { get; set; }
    }
}