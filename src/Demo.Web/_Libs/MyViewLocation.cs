using System;
using System.Collections.Generic;

namespace Demo.Web
{
    public class MyViewLocation
    {
        public IEnumerable<string> Create(string category, string name, IEnumerable<string> viewLocations)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentNullException(nameof(category));
            }

            var newLocations = new List<string>();
            if (string.IsNullOrEmpty(name))
            {
                return newLocations;
            }

            foreach (var item in viewLocations)
            {
                newLocations.Add($"/{category}/{name}" + item);
            }
            return newLocations;
        }

        public static MyViewLocation Instance = new MyViewLocation();
    }

    public static class MyViewLocationExtension
    {
        public static string Category_Theme = "_Themes";

        public static IEnumerable<string> CreateForTheme(this MyViewLocation moreViewLocation, string theme, IEnumerable<string> viewLocations)
        {
            return moreViewLocation.Create(Category_Theme, theme, viewLocations);
        }


        public static string Category_Tenant = "_Tenants";

        public static IEnumerable<string> CreateForTenant(this MyViewLocation moreViewLocation, string tenant, IEnumerable<string> viewLocations)
        {
            return moreViewLocation.Create(Category_Tenant, tenant, viewLocations);
        }
    }
}
