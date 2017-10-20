using Prism.AppModel;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using MVPPrismApp.Lib.Services;
using System.Collections.ObjectModel;
using MVPPrismApp.Lib.Models;
using System.Linq;
using MVPPrismApp.Core.Utils;

namespace MVPPrismApp.Core.ViewModels
{

    public class GalleryPageViewModel : ViewModelBase
    {
        private readonly IAPIService _apiService;


        private ObservableCollection<Grouping<string, NewsResultItem>> _gallerys;

        public ObservableCollection<Grouping<string, NewsResultItem>> Gallerys
        {
            get { return _gallerys; }
            set { SetProperty(ref _gallerys, value); }
        }


        public GalleryPageViewModel(IAPIService apiService,INavigationService navigationService, IApplicationStore applicationStore,
                         IDeviceService deviceService)
                      : base(navigationService, applicationStore, deviceService)
        {
            Title = "相册";
            this._apiService = apiService;


            IsActiveChanged += HandleIsActiveTrue;
            IsActiveChanged += HandleIsActiveFalse;
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            // TODO: Implement your initialization logic
            if (IsActive) return;

            IsActive = true;

            var result = await this._apiService.getNewsList();

            ObservableCollection<NewsResultItem> resultItemList = new ObservableCollection<NewsResultItem>();
            foreach (var item in result)
            {
                foreach (var i in item.NewsList)
                {
                    NewsResultItem resultItem = new NewsResultItem();
                    //NewsInfoResultItem info = new NewsInfoResultItem();
                    resultItem.NewsTitle = item.NewsTitle + "(" + item.NewsDate.Trim() + ")";
                    //resultItem.NewsInfo = info;
                    resultItem.PhotoURL = i.PhotoURL;
                    Console.WriteLine(resultItem.PhotoURL);
                    resultItemList.Add(resultItem);
                }
            };


            var trans = from p in resultItemList
                        group p by p.NewsTitle into ListGroup
                        select new Grouping<string, NewsResultItem>(ListGroup.Key, ListGroup);
            Gallerys = new ObservableCollection<Grouping<string, NewsResultItem>>(trans);

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
