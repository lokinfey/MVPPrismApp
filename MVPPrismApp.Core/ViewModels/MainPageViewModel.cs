﻿using Prism.AppModel;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using MVPPrismApp.Lib.Services;

namespace MVPPrismApp.Core.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {


        public MainPageViewModel(INavigationService navigationService, IApplicationStore applicationStore,
                         IDeviceService deviceService)
                      : base(navigationService, applicationStore, deviceService)
        {
            Title = "Main Page";
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            // TODO: Implement your initialization logic
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            // TODO: Handle any final tasks before you navigate away
        }

        public override  void OnNavigatedTo(NavigationParameters parameters)
        {

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

        public override void Destroy()
        {
            // TODO: Dispose of any objects you need to for memory management
        }
    }
}
