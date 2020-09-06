using System.Collections.Generic;

namespace AngularBlog.API.ViewModels
{
    /// <summary>
    ///     Author of posts View Model
    /// </summary>
    public class AuthorViewModel
    {
        /// <summary>
        ///    Email of Author 
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        ///     First Name of Author
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        ///     Last Name of Author
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        ///     Posts of Author
        /// </summary>
        public IEnumerable<PostViewModel> Posts { get; set; } = new List<PostViewModel>();
    }
}