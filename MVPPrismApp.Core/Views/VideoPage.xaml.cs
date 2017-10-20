using System;
using System.Collections.Generic;
using MVPPrismApp.Core.Utils;
using MVPPrismApp.Lib.Models;
using Xamarin.Forms;

namespace MVPPrismApp.Core.Views
{
    public partial class VideoPage : BaseContentPage
    {
        async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
                return;
            var item = e?.SelectedItem as VideoItem;

#if __MOBILE__

            await this.Navigation.PushModalAsync(new VideoPlayerPage(item.VideoURL));

            #else
            await this.Navigation.PushModalAsync(new VideoPlayerMacPage(item.VideoURL));



#endif

            ((ListView)sender).SelectedItem = null;
        }

        public VideoPage()
        {
            InitializeComponent();
        }
    }
}
