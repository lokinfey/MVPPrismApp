using System;
namespace MVPPrismApp.Core.Utils
{
    public interface INetworkConnection
    {
        bool IsConnected { get; }
        void CheckNetworkConnection();
    }
}
