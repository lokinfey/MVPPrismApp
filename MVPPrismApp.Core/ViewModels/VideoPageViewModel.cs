using Prism.AppModel;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using MVPPrismApp.Lib.Services;
using System.Collections.ObjectModel;
using MVPPrismApp.Lib.Models;

namespace MVPPrismApp.Core.ViewModels
{

    public class VideoPageViewModel: ViewModelBase
    {

        private readonly IAPIService _apiService;

        public VideoPageViewModel(IAPIService apiService,INavigationService navigationService, IApplicationStore applicationStore,
                         IDeviceService deviceService)
                      : base(navigationService, applicationStore, deviceService)
        {
            Title = "视频";
            this._apiService = apiService;


            IsActiveChanged += HandleIsActiveTrue;
            IsActiveChanged += HandleIsActiveFalse;
        }


        private ObservableCollection<VideoItem> _videoList;

        public ObservableCollection<VideoItem> VideoList
        {
            get { return _videoList; }
            set { SetProperty(ref _videoList, value); }
        }

        public override async  void OnNavigatingTo(NavigationParameters parameters)
        {
            // TODO: Implement your initialization logic
            if (IsActive) return;

            IsActive = true;


            var result = await this._apiService.getVideoList();
            VideoList = new ObservableCollection<VideoItem>(result);


        }

        public override  void OnNavigatedFrom(NavigationParameters parameters)
        {
            // TODO: Handle any final tasks before you navigate away

        }

        public override    void OnNavigatedTo(NavigationParameters parameters)
        {

            //var result = await _apiService.getVideoList();
            //VideoList = new ObservableCollection<VideoItem>(result);

           // Console.WriteLine("Video");
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
