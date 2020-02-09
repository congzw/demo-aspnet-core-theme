using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;

namespace Demo.Web
{
    public class MyHttpContextHelper
    {
        public string GetContextParams(HttpContext httpContext, string name, string defaultValue)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }
            
            if (httpContext.Request.Query.TryGetValue(name, out StringValues theme))
            {
                return theme;
            }

            return defaultValue;
        }

        public static MyHttpContextHelper Instance = new MyHttpContextHelper();
    }
}
