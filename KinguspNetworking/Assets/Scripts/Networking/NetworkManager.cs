using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Kingusp.Networking
{
    public class NetworkManager : UnityEngine.Networking.NetworkManager
    {
        #region NetworkState
        public enum NetworkState
        {
            Nothing,
            Connecting,
            Host,
            Server,
            Client,
        }
        public static NetworkState networkState = NetworkState.Nothing;
        #endregion NetworkState
    }
}