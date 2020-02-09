using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Demo.Web
{
    public interface ITenantContextService
    {
        string GetTheme(HttpContext httpContext);
    }

    public static class MyViewLocationExtForTenant
    {
        public static string Category_Tenant = "_Tenants";

        public static IEnumerable<string> CreateForTenant(this MyViewLocation myViewLocation, string tenant, IEnumerable<string> viewLocations)
        {
            return myViewLocation.Create(Category_Tenant, tenant, viewLocations);
        }
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
