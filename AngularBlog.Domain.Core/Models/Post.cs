using System;

namespace AngularBlog.Domain.Models
{
    public class Post : IdEntity<int>
    {
        public string Title { get; set; }
        public DateTime DateTime { get; set; } // TODO NodaTime instead of DateTime
        public User Author { get; set; }
        public string Content { get; set; }
    }
}