using System;
using System.Text;
using AngularBlog.Common;
using Microsoft.Extensions.Options;

namespace AngularBlog.API.Extensions
{
    public static class SettingsExtension
    {
        public static byte[] GetSecretKey(this IOptions<AppSettings> appSettings)
        {
            var secret = appSettings?.Value?.Secret;
            if (string.IsNullOrWhiteSpace(secret))
            {
                throw new ArgumentNullException(nameof(secret));
            }
            return GetSecretKey(secret);
        }
        
        public static byte[] GetSecretKey(this AppSettings appSettings)
        {
            var secret = appSettings?.Secret;
            if (string.IsNullOrWhiteSpace(secret))
            {
                throw new ArgumentNullException(nameof(secret));
            }
            return GetSecretKey(secret);
        }

        private static byte[] GetSecretKey(string secret)
        {
            return Encoding.ASCII.GetBytes(secret);
        }
    }
}