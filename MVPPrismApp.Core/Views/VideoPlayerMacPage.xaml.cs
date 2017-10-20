using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MVPPrismApp.Core.Views
{
    public partial class VideoPlayerMacPage : ContentPage
    {
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        public VideoPlayerMacPage(string URL)
        {
            InitializeComponent();

            var html = new HtmlWebViewSource
            {
                Html = "<body style=\" background-color : #098fdc\"><video id=\"vid\" controls src=\""+URL+"\" style=\"width :100% ; \"  ></video></body>"
            };

            player.Source = html;
            this.BackgroundColor = Color.FromRgb(0, 120, 215);
        }
    }
}
