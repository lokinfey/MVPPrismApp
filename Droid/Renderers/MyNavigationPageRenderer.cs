using System;
using System.ComponentModel;
using Android.Graphics;
using Android.Widget;
using MVPPrismApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using Support = Android.Support.V7.Widget;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(MyNavigationPageRenderer))]
namespace MVPPrismApp.Droid.Renderers
{
    public class MyNavigationPageRenderer : NavigationPageRenderer
    {
        private Support.Toolbar _toolbar;

        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);

            if (child.GetType() == typeof(Support.Toolbar))
                _toolbar = (Support.Toolbar)child;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var page = this.Element as NavigationPage;

            if (page != null && _toolbar != null)
            {
              //  Typeface tf = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "MyFont.ttf");

                TextView title = (TextView)_toolbar.FindViewById(Resource.Id.toolbar_title);
                title.SetText("2017年微软最有价值专家中国峰会", TextView.BufferType.Normal);

                //title.SetTypeface(tf, TypefaceStyle.Normal);
            }

        }
    }
}
