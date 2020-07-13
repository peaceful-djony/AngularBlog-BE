using System;
using AngularBlog.Services.Interfaces;

namespace AngularBlog.API.Services
{
    public class ExpirationService : IExpirationService
    {
        public DateTime GetExpiration()
        {
            return DateTime.UtcNow.AddDays(7);
        }
    }
}