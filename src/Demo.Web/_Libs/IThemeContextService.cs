using Microsoft.AspNetCore.Http;
using System;

namespace Demo.Web
{
    public interface IThemeContextService
    {
        string GetTheme(HttpContext httpContext);
    }
    
    public static class MyHttpContextHelperExtForTheme
    {
        public static Func<IThemeContextService> Resolve { get; set; }

        public static string GetTheme(this MyHttpContextHelper myHttpContextHelper, HttpContext httpContext)
        {
            if (Resolve == null)
            {
                return myHttpContextHelper.GetContextParams(httpContext, "theme", null);
            }
            return Resolve().GetTheme(httpContext);
        }
    }
}
