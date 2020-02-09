using System;
using System.Collections.Generic;

namespace Demo.Libs.Themes
{
    public class MoreViewLocation
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

        public static MoreViewLocation Instance = new MoreViewLocation();
    }

    public static class MoreViewLocationExtension
    {
        public static string ExtendCategoryTheme = "_Theme";

        public static IEnumerable<string> CreateForTheme(this MoreViewLocation moreViewLocation, string theme, IEnumerable<string> viewLocations)
        {
            return moreViewLocation.Create(ExtendCategoryTheme, theme, viewLocations);
        }


        public static string ExtendCategoryTenant = "_Tenant";

        public static IEnumerable<string> CreateForTenant(this MoreViewLocation moreViewLocation, string tenant, IEnumerable<string> viewLocations)
        {
            return moreViewLocation.Create(ExtendCategoryTenant, tenant, viewLocations);
        }
    }
}
