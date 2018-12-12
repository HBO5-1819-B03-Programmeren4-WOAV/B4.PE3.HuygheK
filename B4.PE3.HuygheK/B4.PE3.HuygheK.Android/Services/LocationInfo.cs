using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

using Android;
using Android.App;
using Android.Content.PM;
using Android.Locations;

using B4.PE3.HuygheK.Domain;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using B4.PE3.HuygheK.Services;
using Android.Content;
using Xamarin.Essentials;

[assembly: Dependency(typeof(B4.PE3.HuygheK.Droid.Services.DroidLocationInfoService))]
namespace B4.PE3.HuygheK.Droid.Services
{
    internal class DroidLocationInfoService : ILocationInfoServices
    {
        LocationManager locationManager;
        public string lon = "_";
        public string lat = "_";
        public string tijd = DateTime.Now.ToUniversalTime().ToString("r");

        public DroidLocationInfoService()
        {
            
            Locatie();


        }





        public LocationInfo GetLocationInfo()
        {

           // Locatie();
            LocationInfo info = new LocationInfo
            {
                Tekst = "",
                Latitude = lat,
                Longitude = lon,
                Time = tijd
               
            };
                


            
            return info;
        }
        public async void Locatie()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    
                    lon = location.Longitude.ToString();
                    lat = location.Latitude.ToString();
                    // "Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {               // Handle not supported on device exception
                lon = "geenGPS";
                lat = "geenGPS";
            }
            catch (PermissionException pEx)
            {
                lon = "geenToegang";
                lat = "geenToegang";
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
                lon = "fout";
                lat = "fout";
            }
        }
        //public void Locatie()
        //{
        //    locationManager = (LocationManager)GetSystemService(LocationService);
        //    LocationManager locationManager =
        // (LocationManager)this.getSystemService(Context.LOCATION_SERVICE);
        //    locationManager = GetSystemService(LocationService) as LocationManager;

        //    var criteria = new Criteria { PowerRequirement = Power.Medium };
        //    try
        //    {
        //        var bestProvider = locationManager.GetBestProvider(criteria, true);
        //        var location = locationManager.GetLastKnownLocation(bestProvider);


        //        lon = location.Longitude.ToString();
        //        lat = location.Latitude.ToString();
        //    }
        //    catch
        //    {

        //        lat = "No location";
        //        lon = "No location";
        //    };



        //}
        
    }
}