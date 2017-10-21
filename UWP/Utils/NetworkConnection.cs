using MVPPrism.UWP.Utils;
using MVPPrismApp.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(NetworkConnection))]
namespace MVPPrism.UWP.Utils
{
    public class NetworkConnection : INetworkConnection
    {
        public bool IsConnected { get; set; }

        public void CheckNetworkConnection()
        {
            bool status = NetworkInterface.GetIsNetworkAvailable();
            if (status)
                IsConnected = true;
            else
                IsConnected = false;

        }
    }
}