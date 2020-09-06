using System;

namespace AngularBlog.API.ViewModels
{
    /// <summary>
    ///     VM represents Post
    /// </summary>
    public class PostViewModel
    {
        /// <summary>
        ///     Title of Post
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     When Post was created
        /// </summary>
        public DateTime CreatedAt { get; set; } // TODO NodaTime instead of DateTime

        /// <summary>
        ///     Author of Post
        /// </summary>
        public AuthorViewModel Author { get; set; }

        /// <summary>
        ///     Content of Post (can be HTML)
        /// </summary>
        public string Content { get; set; }
    }
}