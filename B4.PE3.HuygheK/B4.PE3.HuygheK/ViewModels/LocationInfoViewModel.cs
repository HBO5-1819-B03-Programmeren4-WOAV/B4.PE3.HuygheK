using B4.PE3.HuygheK.Domain;
using B4.PE3.HuygheK.Services;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace B4.PE3.HuygheK.ViewModels
{
    public class LocationInfoViewModel : FreshBasePageModel
    {
        

        //private ILocationInfoServices service;

        //public LocationInfoViewModel(ILocationInfoServices deviceInfoService)
        //{
        //    service = deviceInfoService;
        ////}

        public LocationInfo LocationInfo { get; set; }
        private string longitude;
        public string Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value;
                RaisePropertyChanged(nameof(Longitude));
            }
        }
        private string latitude;
        public string Latitude
        {
            get { return longitude; }
            set
            {
                latitude = value;
                RaisePropertyChanged(nameof(Latitude));
            }
        }

        public override void Init(object initData)
        {
            base.Init(initData);
           
            
            try
            {
                ILocationInfoServices service = DependencyService.Get<ILocationInfoServices>();
                LocationInfo = service.GetLocationInfo();
               // Locatie();
            }
            catch
            {

            };
           
        }
        //public async void Locatie()
        //{
        //    try
        //    {
        //        var location = await Geolocation.GetLastKnownLocationAsync();

        //        if (location != null)
        //        {
        //            Longitude = location.Longitude.ToString();
        //            LocationInfo.Longitude = location.Longitude.ToString();
        //            LocationInfo.Latitude = location.Latitude.ToString();
        //            "Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
        //        }
        //    }
        //    catch (FeatureNotSupportedException fnsEx)
        //    {               // Handle not supported on device exception
        //        LocationInfo.Longitude = "geenGPS";
        //        LocationInfo.Latitude = "geenGPS";
        //    }
        //    catch (PermissionException pEx)
        //    {
        //        LocationInfo.Longitude = "geenToegang";
        //        LocationInfo.Latitude = "geenToegang";
        //        Handle permission exception
        //    }
        //    catch (Exception ex)
        //    {
        //        Unable to get location
        //        LocationInfo.Longitude = "fout";
        //        LocationInfo.Latitude = "fout";
        //    }
        //}

    }
}
