namespace AngularBlog.Services.Interfaces
{
    public interface IScopeInfoService
    {
        public int UserId { get; set; } // TODO store int id?
        public string SessionId { get; set; }
    }
}