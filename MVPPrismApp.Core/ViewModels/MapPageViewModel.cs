using Prism.AppModel;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using MVPPrismApp.Lib.Models;

namespace MVPPrismApp.Core.ViewModels
{

    public class MapPageViewModel: ViewModelBase
    {
        public MapPageViewModel(INavigationService navigationService, IApplicationStore applicationStore,
                         IDeviceService deviceService)
                      : base(navigationService, applicationStore, deviceService)
        {
            Title = "地图";


            IsActiveChanged += HandleIsActiveTrue;
            IsActiveChanged += HandleIsActiveFalse;
        }


        private ObservableCollection<LocationItem> _locations;


        public ObservableCollection<LocationItem> Locations
        {
            get { return _locations; }
            set { SetProperty(ref _locations, value); }
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            // TODO: Implement your initialization logic
            if (IsActive) return;

            IsActive = true;

            //Locations = new ObservableCollection<LocationItem>
            //{
            //    new LocationItem
            //    {
            //        ImgURL = "location1.png"
            //    },
            //    new LocationItem
            //    {
            //        ImgURL = "location2.png"
            //        },
            //    new LocationItem
            //    {
            //        ImgURL = "location3.png"
            //    }
            //};
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            // TODO: Handle any final tasks before you navigate away
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {

            //Console.WriteLine("Map");
            //switch (parameters.GetNavigationMode())
            //{
            //    case NavigationMode.Back:
            //        // TODO: Handle any tasks that should occur only when navigated back to
            //        break;
            //    case NavigationMode.New:
            //        // TODO: Handle any tasks that should occur only when navigated to for the first time
            //        break;
            //}

            // TODO: Handle any tasks that should be done every time OnNavigatedTo is triggered
        }


        private void HandleIsActiveTrue(object sender, EventArgs args)
        {
            if (IsActive == false) return;

            // Handle Logic Here
        }

        private void HandleIsActiveFalse(object sender, EventArgs args)
        {
            if (IsActive == true) return;

            // Handle Logic Here
        }

        public override void Destroy()
        {
            // TODO: Dispose of any objects you need to for memory management
            IsActiveChanged -= HandleIsActiveTrue;
            IsActiveChanged -= HandleIsActiveFalse;
        }
    } 
}
