using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Demo.Web
{
    public interface IThemeContextService
    {
        string GetTheme(HttpContext httpContext);
    }

    public static class MyViewLocationExtForTheme
    {
        public static string Category_Theme = "_Themes";

        public static IEnumerable<string> CreateForTheme(this MyViewLocation myViewLocation, string theme, IEnumerable<string> viewLocations)
        {
            return myViewLocation.Create(Category_Theme, theme, viewLocations);
        }
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
