using B4.PE3.HuygheK.Domain;
using B4.PE3.HuygheK.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Xamarin.Forms;

[assembly: Dependency(typeof(B4.PE3.HuygheK.UWP.Services.UwpLocationInfoService))]

namespace B4.PE3.HuygheK.UWP.Services
{
    internal class UwpLocationInfoService : ILocationInfoServices
    {
        public string Tekst { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public string lat = "_";
        public string lon = "_";
        
        public UwpLocationInfoService()
        {
            GetLocation();
            

        }
        public LocationInfo GetLocationInfo()
        {
            LocationInfo info = new LocationInfo
            {
                Tekst = "",
                Latitude = lat,
                Longitude = lon
            };
            GetLocation();
            info.Latitude = lat;
            info.Longitude = lon;
           
            return info;
        }

        async void GetLocation()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:

                    // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is 0), DesiredAccuracy.Default is used.
                    Geolocator geolocator = new Geolocator();

                    // Subscribe to StatusChanged event to get updates of location status changes


                    // Carry out the operation
                    Geoposition pos = await geolocator.GetGeopositionAsync();
                    lat = pos.Coordinate.Point.Position.Latitude.ToString();
                    lon = pos.Coordinate.Point.Position.Longitude.ToString();

                    // notify user: Location updated
                    break;

                case GeolocationAccessStatus.Denied:
                    // notify user: Access to location is denied
                    lat = "geenToegang";
                    lon = "geenToegang";
                    break;

                case GeolocationAccessStatus.Unspecified:
                    // notify user: Unspecified error
                    lat = "geenGPS";
                    lon = "geenGPS";
                    break;
            }
              
        }
       
    }
}
