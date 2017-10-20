using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Autofac;
using Prism.Autofac;
using MVPPrismApp.Core;
using FFImageLoading.Forms.Droid;
using Octane.Xam.VideoPlayer.Android;
using Android.Content;
using FFImageLoading;
using Android.Content.Res;

namespace MVPPrismApp.Droid
{
    [Activity(Label = "MVPPrismApp.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme",   ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);


            FormsVideoPlayer.Init("6EA93319AABD13FBDAE0627E59874032F4242FB5");

            CachedImageRenderer.Init();


            Application.RegisterComponentCallbacks(new LifecycleCallbacks());

            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class LifecycleCallbacks : Java.Lang.Object, IComponentCallbacks2
    {


        public void OnTrimMemory([GeneratedEnum] TrimMemory level)
        {   
            ImageService.Instance.InvalidateMemoryCache();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);

        }

        public void OnConfigurationChanged(Configuration newConfig)
        {
        }

        public void OnLowMemory()
        {
        }

    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(ContainerBuilder builder)
        {

        }
    }
}
