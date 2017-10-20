using Autofac;
using Foundation;
using MVPPrismApp.Core;
using Prism.Autofac;
using UIKit;
using Xamarin.Forms.Platform.iOS;

using FFImageLoading.Forms.Touch;
using Octane.Xam.VideoPlayer.iOS;

namespace MVPPrismApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();
            CachedImageRenderer.Init();

            FormsVideoPlayer.Init("F118B63AE568A8A047ED4CF467DA72DA89CDFD48");

            var statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;

            if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
            {
                statusBar.BackgroundColor = UIColor.FromRGB(10, 79, 157); //UIColor.FromRGB(0, 120, 215);
            }

            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(ContainerBuilder builder)
        {
            // Register Any Platform Specific Implementations that you cannot 
            // access from Shared Code
        }
    }
}
