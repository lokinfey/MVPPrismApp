using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Support.V7.Widget;
using System.Reflection;
using MVPPrismApp.Droid.Renderers;


[assembly: ExportRenderer(typeof(ListView), typeof(CusListViewRender))]
namespace MVPPrismApp.Droid.Renderers
{
    public class CusListViewRender : ListViewRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            //var list = e.NewElement;


            var nativeListView = (global::Android.Widget.ListView)Control;


            var list = e.NewElement;



            base.OnElementChanged(e);
        }
    }
}
