using Microsoft.AspNetCore.Http;
using System;

namespace Demo.Web
{
    public interface ITenantContextService
    {
        string GetTheme(HttpContext httpContext);
    }

    public static class MyHttpContextHelperExtForTenant
    {
        public static Func<ITenantContextService> Resolve { get; set; }

        public static string GetTenant(this MyHttpContextHelper myHttpContextHelper, HttpContext httpContext)
        {
            if (Resolve == null)
            {
                return myHttpContextHelper.GetContextParams(httpContext, "tenant", null);
            }
            return Resolve().GetTheme(httpContext);
        }
    }
}
