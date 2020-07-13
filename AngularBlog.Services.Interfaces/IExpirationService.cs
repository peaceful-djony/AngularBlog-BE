using System;

namespace AngularBlog.Services.Interfaces
{
    public interface IExpirationService
    {
        //TODO NodaTime instead of DateTime
        DateTime GetExpiration();
    }
}