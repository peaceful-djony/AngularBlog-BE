using AngularBlog.Services.Interfaces;

namespace AngularBlog.API.Services
{
    public class ScopeInfoService : IScopeInfoService
    {
        public int UserId { get; set; }
        public string SessionId { get; set; }
    }
}