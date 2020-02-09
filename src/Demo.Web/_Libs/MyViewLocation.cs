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
}
