using System;
using System.Threading.Tasks;
using Autofac;
using MVPPrismApp.Core.Views;
using Prism.Autofac;
using Prism.Logging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MVPPrismApp.Lib.Services;

using DLToolkit.Forms.Controls;
using MVPPrismApp.Core.Utils;

namespace MVPPrismApp.Core
{
    public partial class App : PrismApplication
    {
        /* 
         * NOTE: 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App()
            : this(null)
        {
        }

        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();


            FlowListView.Init();


            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (networkConnection.IsConnected == false)
            {

                await NavigationService.NavigateAsync("MVPPage/NetworkPage");
                //Load();

            }
            else
            {
                await NavigationService.NavigateAsync("MVPPage/MainTabbedPage");

            }

           // NavigationPage
        }


        async void Load()
        {
            //Device.BeginInvokeOnMainThread(async () =>
            //{

               // var page = new ContentPage();
              //  DisplayAlert("网络加载出错", "网络加载出错，请打开你的蜂窝网络或链接有效的无线网络", "关闭");

            //});
            //await DisplayAlert("1", "1", "1");
        }

        protected override void RegisterTypes()
        {
            Builder.RegisterTypeForNavigation<MVPPage>();
            Builder.RegisterTypeForNavigation<MainTabbedPage>();
            Builder.RegisterTypeForNavigation<MapPage>();
            Builder.RegisterTypeForNavigation<SchedulePage>();
            Builder.RegisterTypeForNavigation<VideoPage>();
            Builder.RegisterTypeForNavigation<GalleryPage>();
            Builder.RegisterTypeForNavigation<NetworkPage>();
            Builder.RegisterType<APIService>().As<IAPIService>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle IApplicationLifecycle
            base.OnSleep();

            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle IApplicationLifecycle
            base.OnResume();

            // Handle when your app resumes
        }
    }
}
