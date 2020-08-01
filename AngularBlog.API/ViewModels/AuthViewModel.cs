namespace AngularBlog.API.ViewModels
{
    /// <summary>
    ///     Authorization View Model
    /// </summary>
    public class AuthViewModel
    {
        /// <summary>
        ///    JSON Web Token 
        /// </summary>
        public string Token { get; set; }
        
        /// <summary>
        ///    JWT Expiration in seconds 
        /// </summary>
        public string ExpiresIn { get; set; }
    }
}