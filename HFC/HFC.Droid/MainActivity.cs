using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Locations;

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

            LoadApplication(new App());
        }


        public void OnLocationChanged(Location location)
        {
            last_location = location;
            has_location = true;
        }

        public void OnStatusChanged(String provider, int status, Bundle extras) { }

        public void OnProviderEnabled(String provider) { }

        public void OnProviderDisabled(String provider) { }

        public void OnStatusChanged(string provider, Availability status, Bundle extras) { }

        public static LocationManager locationManager;

        LocationServicesHelper.getLocationUpdate
    }
}

