using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Locations;

using Xamarin.Forms.Maps;

namespace HFC.Droid
{
    [Activity(Label = "HFC", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ILocationListener
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            global::Xamarin.FormsMaps.Init(this, bundle);

            // Set up location services for maps.
            locationManager = (LocationManager)GetSystemService(LocationService);

            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Coarse
            };

            IList<string> acceptableLocationProviders = locationManager.GetProviders(criteriaForLocationService, true);

            if (acceptableLocationProviders.Any())
            {
                locationProvider_name = acceptableLocationProviders.First();
            }
            else
            {
                locationProvider_name = string.Empty;
            }

            LocationServicesHelper.getLocationUpdate = GetSingleLocationUpdate;

            LoadApplication(new App());
        }

        public Position GetSingleLocationUpdate()
        {
            // If we have a location provider.
            if (!String.IsNullOrEmpty(locationProvider_name))
            {
                LocationServicesHelper.has_location = false;
                locationManager.RequestSingleUpdate(locationProvider_name, this, null);

                while (LocationServicesHelper.has_location == false)
                {
                    Task.Delay(500);
                }
            }
            
            return new Position(LocationServicesHelper.last_location_lat, LocationServicesHelper.last_location_long);
        }


        public void OnLocationChanged(Location location)
        {
            LocationServicesHelper.last_location_lat = location.Latitude;
            LocationServicesHelper.last_location_long = location.Longitude;
            LocationServicesHelper.has_location = true;
        }

        public void OnStatusChanged(String provider, int status, Bundle extras) { }

        public void OnProviderEnabled(String provider) { }

        public void OnProviderDisabled(String provider) { }

        public void OnStatusChanged(string provider, Availability status, Bundle extras) { }

        public static LocationManager locationManager;
        public static string locationProvider_name;
    }
}

