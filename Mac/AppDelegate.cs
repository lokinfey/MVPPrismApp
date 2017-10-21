using AppKit;
using Autofac;
using FFImageLoading.Forms.Mac;
using Foundation;
using MVPPrismApp.Core;
using Prism;
using Prism.Autofac;

using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

namespace MVPPrismApp.Mac
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {


        NSWindow _window;

        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

            var rect = new CoreGraphics.CGRect(200, 1000, 1024, 768);
            _window = new NSWindow(rect, style, NSBackingStore.Buffered, false);
            _window.Title = "Xamarin.Forms on Mac!";
            _window.TitleVisibility = NSWindowTitleVisibility.Hidden;
        }

        public override NSWindow MainWindow
        {
            get { return _window; }
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application

            Xamarin.Forms.Forms.Init();
            CachedImageRenderer.Init();
            //LoadApplication(new App());

            LoadApplication(new App(new MacInitializer()));
            base.DidFinishLaunching(notification);
        }

        //public override void DidFinishLaunching(NSNotification notification)
        //{
        //    Xamarin.Forms.Forms.Init();
        //    CachedImageRenderer.Init();
        //    LoadApplication(new App());
        //}

        //public override void WillTerminate(NSNotification notification)
        //{
        //    // Insert code here to tear down your application
        //}
    }


    public class MacInitializer : IPlatformInitializer
    {
        public void RegisterTypes(ContainerBuilder builder)
        {
            // Register Any Platform Specific Implementations that you cannot 
            // access from Shared Code
        }
    }
}
