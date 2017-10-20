using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MVPPrismApp.Core.Views
{
    public partial class VideoPlayerPage : ContentPage
    {
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        public VideoPlayerPage(string URL)
        {
            InitializeComponent();

            VPlayer.Source = URL;
            this.BackgroundColor = Color.FromRgb(0, 120, 215);
        }
    }
}
