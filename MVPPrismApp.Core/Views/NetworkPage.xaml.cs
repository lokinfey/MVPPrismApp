using System;
using System.Collections.Generic;
using MVPPrismApp.Core.Utils;
using Xamarin.Forms;

namespace MVPPrismApp.Core.Views
{
    public partial class NetworkPage : BaseContentPage
    {
        public NetworkPage()
        {
            InitializeComponent();

            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("网络加载出错", "网络加载出错，请打开你的蜂窝网络或链接有效的无线网络退出应用后重新打开", "关闭");

            });
        }
    }
}
