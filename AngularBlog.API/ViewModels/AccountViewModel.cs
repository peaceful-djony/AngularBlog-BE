namespace AngularBlog.API.ViewModels
{
    /// <summary>
    ///     VM represents Account's information
    /// </summary>
    public class AccountViewModel
    {
        /// <summary>
        ///     Email of Account
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///    Account Password TODO why do we need it
        /// </summary>
        public string Password { get; set; }
    }
}