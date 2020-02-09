using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Web
{
    public class MyViewLocationExpander : IViewLocationExpander
    {
        private const string THEME_KEY = "theme";
        private const string TENANT_KEY = "tenant";


        public void PopulateValues(ViewLocationExpanderContext context)
        {
            var ctxHelper = MyHttpContextHelper.Instance;

            var theme = ctxHelper.GetTheme(context.ActionContext.HttpContext);
            context.Values[THEME_KEY] = theme;

            var tenant = ctxHelper.GetTenant(context.ActionContext.HttpContext);
            context.Values[TENANT_KEY] = tenant;
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            var newLocations = viewLocations;

            string theme = null;
            context.Values.TryGetValue(THEME_KEY, out theme);
            if (!string.IsNullOrWhiteSpace(theme))
            {
                var themeLocations = MyViewLocation.Instance.CreateForTheme(theme, viewLocations);
                newLocations = themeLocations.Concat(newLocations);
            }

            string tenant;
            context.Values.TryGetValue(TENANT_KEY, out tenant);
            if (!string.IsNullOrWhiteSpace(tenant))
            {
                var tenantLocations = MyViewLocation.Instance.CreateForTenant(tenant, viewLocations);
                newLocations = tenantLocations.Concat(newLocations);
            }

            return newLocations;
        }
    }
}
