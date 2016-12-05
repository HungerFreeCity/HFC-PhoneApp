using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FormsToolkit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using PSC.Xamarin.MvvmHelpers;

namespace HFC
{
    public class MapsViewModel: BaseViewModel, INavigation
    {
		INavigation _Navigation => Application.Current?.MainPage?.Navigation;

	    #region INavigation implementation

		public void RemovePage(Page page)
		{
			_Navigation?.RemovePage(page);
		}

		public void InsertPageBefore(Page page, Page before)
		{
			_Navigation?.InsertPageBefore(page, before);
		}

		public async Task PushAsync(Page page)
		{
			var task = _Navigation?.PushAsync(page);
			if (task != null)
				await task;
		}

		public async Task<Page> PopAsync()
		{
			var task = _Navigation?.PopAsync();
			return task != null ? await task : await Task.FromResult(null as Page);
		}

		public async Task PopToRootAsync()
		{
			var task = _Navigation?.PopToRootAsync();
			if (task != null)
				await task;
		}

		public async Task PushModalAsync(Page page)
		{
			var task = _Navigation?.PushModalAsync(page);
			if (task != null)
				await task;
		}

		public async Task<Page> PopModalAsync()
		{
			var task = _Navigation?.PopModalAsync();
			return task != null ? await task : await Task.FromResult(null as Page);
		}

		public async Task PushAsync(Page page, bool animated)
		{
			var task = _Navigation?.PushAsync(page, animated);
			if (task != null)
				await task;
		}

		public async Task<Page> PopAsync(bool animated)
		{
			var task = _Navigation?.PopAsync(animated);
			return task != null ? await task : await Task.FromResult(null as Page);
		}

		public async Task PopToRootAsync(bool animated)
		{
			var task = _Navigation?.PopToRootAsync(animated);
			if (task != null)
				await task;
		}

		public async Task PushModalAsync(Page page, bool animated)
		{
			var task = _Navigation?.PushModalAsync(page, animated);
			if (task != null)
				await task;
		}

		public async Task<Page> PopModalAsync(bool animated)
		{
			var task = _Navigation?.PopModalAsync(animated);
			return task != null ? await task : await Task.FromResult(null as Page);
		}

		public IReadOnlyList<Page> NavigationStack => _Navigation?.NavigationStack;

	    public IReadOnlyList<Page> ModalStack => _Navigation?.ModalStack;

	    #endregion

        public MapsViewModel()
        {
            _Geocoder = new Geocoder();
        }

        readonly Geocoder _Geocoder;

        /*public async Task ExecuteGetDirectionsCommand()
        {
            var position = await GetPosition();

            var pin = new Pin() { Position = position };

            await CrossExternalMaps.Current.NavigateTo(pin.Label, pin.Position.Latitude, pin.Position.Longitude, NavigationType.Driving);
        }*/

        public void SetupMap()
        {
            MessagingService.Current.SendMessage(MessageKeys.SetupMap);
        }

        public void DisplayGeocodingError()
        {
            //MessagingService.Current.SendMessage<MessagingServiceAlert>(MessageKeys.DisplayAlert, new MessagingServiceAlert()
            //    {
            //        Title = "Geocoding Error", 
            //        Message = "Please make sure the address is valid, or that you have a network connection.",
            //        Cancel = "OK"
            //    });

            IsBusy = false;
        }
    }

    public static class MessageKeys
    {
        public const string SetupMap = "SetupMap";
        public const string DataPartitionPhraseValidation = "DataPartitionPhraseValidation";
        public const string BackendUrlValidation = "BackendUrlValidation";
    }
}