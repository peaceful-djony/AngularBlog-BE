using System.Text;
using AngularBlog.Common;
using Microsoft.Extensions.Options;

namespace AngularBlog.API.Extensions
{
    public static class SettingsExtension
    {
        public static byte[] GetSecretKey(this IOptions<AppSettings> appSettings)
        {
            return GetSecretKey(appSettings.Value.Secret);
        }
        
        public static byte[] GetSecretKey(this AppSettings appSettings)
        {
            return GetSecretKey(appSettings.Secret);
        }

        private static byte[] GetSecretKey(string secret)
        {
            return Encoding.ASCII.GetBytes(secret);
        }
    }
}