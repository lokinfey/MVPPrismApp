using Prism.AppModel;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;
using MVPPrismApp.Lib.Models;
using MVPPrismApp.Lib.Services;
using MVPPrismApp.Core.Utils;
using Xamarin.Forms;

namespace MVPPrismApp.Core.ViewModels
{
    public class SchedulePageViewModel: ViewModelBase
    {

        private readonly IAPIService _apiService;

        public SchedulePageViewModel(IAPIService apiService,INavigationService navigationService, IApplicationStore applicationStore,
                         IDeviceService deviceService)
                      : base(navigationService, applicationStore, deviceService)
        {
            Title = "日程";
            this._apiService = apiService;


            IsActiveChanged += HandleIsActiveTrue;
            IsActiveChanged += HandleIsActiveFalse;
        }


        bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            set { SetProperty(ref isLoading, value); }
        }

        private IEnumerable<Grouping<string, SchduleItem>> _schduleList;

        public IEnumerable<Grouping<string, SchduleItem>> SchduleList
        {
            get { return _schduleList; }
            set { SetProperty(ref _schduleList, value); }
        }

        public override  void OnNavigatingTo(NavigationParameters parameters)
        {
            // TODO: Implement your initialization logic

            if (IsActive) return;

            IsActive = true;

        }

        public override  void OnNavigatedFrom(NavigationParameters parameters)
        {
            // TODO: Handle any final tasks before you navigate away
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {


            if (IsLoading) return;
            IsLoading = true;

            var result = await this._apiService.getSchduleList();
            var list = new ObservableCollection<SchduleItem>(result);


            SchduleList = from p in result
                          orderby p.SessionGroup
                          group p by p.SessionGroup into ListGroup
                                   select new Grouping<string, SchduleItem>(ListGroup.Key, ListGroup);

            IsLoading = false;
            //Console.WriteLine("Schedule");
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
