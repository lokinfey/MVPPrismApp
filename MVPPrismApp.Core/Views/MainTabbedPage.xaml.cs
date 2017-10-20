using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVPPrismApp.Core.Utils;
using Prism.Navigation;
using Xamarin.Forms;

namespace MVPPrismApp.Core.Views
{
    public partial class MainTabbedPage : TabbedPage , INavigatingAware
    {
        public MainTabbedPage()
        {
            InitializeComponent();

            Title = "2017年微软最有价值专家中国峰会";
           // BarBackgroundColor = Color.FromRgb(10, 79, 157);
            //  BarTextColor = Color.White;
        }



        public  void OnNavigatingTo(NavigationParameters parameters)
        {


                foreach (var child in Children)
                {
                    (child as INavigatingAware)?.OnNavigatingTo(parameters);
                    (child?.BindingContext as INavigatingAware)?.OnNavigatingTo(parameters);
                }

            //DisplayAlert();
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            Title = CurrentPage?.Title;
        }
    }
}
