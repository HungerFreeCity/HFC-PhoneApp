using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace HFC
{
    public static class LocationServicesHelper
    {
        // Reference to getLocationUpdate function.
        // Use LocationServicesHelper.getLocationUpdate() to get back a position.
        public delegate Position getLocationUpdateDelegate();
        public static getLocationUpdateDelegate getLocationUpdate;

        // Holds last gotten postion. Use getLocationUpdate, above, if you are unsure if a location has already been gotten.
        public static double last_location_long;
        public static double last_location_lat;

        public static bool has_location = false;
    }
}
