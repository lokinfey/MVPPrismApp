using System;

using Xamarin.Forms;

namespace MVPrismApp.Core.Utils
{
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

