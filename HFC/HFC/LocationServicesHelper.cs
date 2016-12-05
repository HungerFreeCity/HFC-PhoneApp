using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HFC
{
    public static class LocationServicesHelper
    {
        // Reference to getLocationUpdate function.
        public delegate void getLocationUpdateDelegate();
        public static getLocationUpdateDelegate getLocationUpdate;

        public static string locationProvider_name;

        public static double last_location_long;
        public static double last_location_lat;

        public static bool has_location = false;
    }
}
