using System;

namespace AngularBlog.Domain.Models
{
    public class Post
    {
        public string Title { get; set; }
        public DateTime DateTime { get; set; } // TODO NodaTime instead of DateTime
        public string Author { get; set; }     // TODO not just string
        public string Content { get; set; }
    }
}