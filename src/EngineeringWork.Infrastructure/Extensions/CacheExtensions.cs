using System;
using EngineeringWork.Core.DTO;
using Microsoft.Extensions.Caching.Memory;

namespace EngineeringWork.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache cache, string email, JwtDto jwt)
            => cache.Set(GetJwtKey(email), jwt, TimeSpan.FromSeconds(5));

        public static JwtDto GetJwt(this IMemoryCache cache, string email)
            => cache.Get<JwtDto>(GetJwtKey(email));

        private static string GetJwtKey(string email) 
            => $"{email}-jwt";
    }
}