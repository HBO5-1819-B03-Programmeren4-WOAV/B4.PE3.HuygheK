using B4.PE3.HuygheK.Domain;
using B4.PE3.HuygheK.Services;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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

        public override void Init(object initData)
        {
            base.Init(initData);
            
            try
            {
                ILocationInfoServices service = DependencyService.Get<ILocationInfoServices>();
                LocationInfo = service.GetLocationInfo();
            }
            catch
            {

            };
           
        }

    }
}
