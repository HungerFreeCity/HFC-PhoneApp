using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace HFC
{
    public partial class MapsPage : ContentPage
    {
        protected MapsViewModel ViewModel => BindingContext as MapsViewModel;
        ObservableCollection<FoodBank> FoodBankList;

        public MapsPage(ObservableCollection<FoodBank> p_FoodBankList)
        {
            FoodBankList = p_FoodBankList;

            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Typically, is preferable to call into the viewmodel for OnAppearing() logic to be performed,
            // but we're not doing that in this case because we need to interact with the Xamarin.Forms.Map property on this Page.
            // In the future, the Map type and it's properties may get more binding support, so that the map setup can be omitted from code-behind.
            await SetupMap();
        }

        /// <summary>
        /// Sets up the map.
        /// </summary>
        /// <returns>A Task.</returns>
        async Task SetupMap()
        {
            // set to a default position
            Position position;

            try
            {
                position = LocationServicesHelper.getLocationUpdate();
            }
            catch (Exception ex)
            {
                ViewModel.DisplayGeocodingError();

                return;
            }

            CenterMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(10)));

            CenterMap.CustomPins = new List<CustomPin> { };
            CenterMap.Pins.Clear();

            // Xamarin.Forms.Maps (2.3.107) currently has a bug that causes map pins to throw ExecutionEngineExceptions on UWP.
            // Omitting pins on UWP for now.
            if (Device.OS != TargetPlatform.WinPhone && Device.OS != TargetPlatform.Windows)
            {
                foreach(FoodBank fb in FoodBankList)
                {
                    var pin = new CustomPin()
                    {
                        Pin = new Pin
                        {
                            Type = PinType.Place,
                            Position = fb.Coordinates,
                            Label = fb.FoodBankName,
                            Address = fb.Address
                        },
                        // In cases where a center has 3 or fewer needs, check NeedList Count to avoid exception.
                        need1 = fb.NeedsList.Count < 1 ? "" : fb.NeedsList[0].Name,
                        need2 = fb.NeedsList.Count < 2 ? "" : fb.NeedsList[1].Name,
                        need3 = fb.NeedsList.Count < 3 ? "" : fb.NeedsList[2].Name,
                    };

                    // Add each base Pin
                    CenterMap.CustomPins.Add(pin);
                    CenterMap.Pins.Add(pin.Pin);
                }
            }
        }
    }
}
