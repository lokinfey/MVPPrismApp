using System;

using Xamarin.Forms;

namespace MVPPrismApp.Core.Utils
{
    public class BaseContentPage : ContentPage
    {
        public void SendAppearing()
        {
            OnAppearing();
        }

        public void SendDisappearing()
        {
            OnDisappearing();
        }
    }
}

