using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

namespace Kingusp.Networking
{
    public class MatchMaker : MonoBehaviour
    {
        public static MatchMaker singleton;
        private string privateMatchName = "";
        private string privatePassword = "";

        #region UnityMethod
        private void Awake()
        {
            if (singleton == null)
                singleton = this;
            else
                DestroyObject(gameObject);
        }
        #endregion UnityMethod

        #region Method
        public void AutoInternetMatch(string matchName, string password)
        {
            NetworkManager.singleton.StartMatchMaker();
            privateMatchName = matchName;
            privatePassword = password;
            Debug.Log(privateMatchName + ":" + privatePassword);
            //NetworkManager.singleton.matchMaker.ListMatches(0, 10, privateMatchName, true, 0, 0, OnInternetMatchList);
            NetworkManager.singleton.matchMaker.ListMatches(0, 10, "", true, 0, 0, OnInternetMatchList);
            NetworkManager.networkState = NetworkManager.NetworkState.Connecting;
        }
        public void AutoInternetMatch()
        {
            AutoInternetMatch("", "");
        }

        public void CreateInternetMatch(string matchName, string password)
        {
            NetworkManager.singleton.matchMaker.CreateMatch(matchName, 6, true, password, "", "", 0, 0, OnInternetMatchCreate);
            NetworkManager.networkState = NetworkManager.NetworkState.Connecting;
        }

        public void FindInternetMatch(string matchName)
        {
            NetworkManager.singleton.StartMatchMaker();
            NetworkManager.singleton.matchMaker.ListMatches(0, 10, matchName, true, 0, 0, OnInternetMatchList);
            NetworkManager.networkState = NetworkManager.NetworkState.Connecting;
        }

        public void DisConnect()
        {
            switch (NetworkManager.networkState)
            {
                case NetworkManager.NetworkState.Nothing: break;
                case NetworkManager.NetworkState.Host: NetworkManager.singleton.StopHost(); break;
                case NetworkManager.NetworkState.Server: NetworkManager.singleton.StopServer(); break;
                case NetworkManager.NetworkState.Client: NetworkManager.singleton.StopClient(); break;
            }
            NetworkManager.networkState = NetworkManager.NetworkState.Nothing;
        }
        #endregion Method

        #region CallBack
        private void OnInternetMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
        {
            if (success)
            {
                Debug.Log("Create match succeeded");

                MatchInfo hostInfo = matchInfo;
                NetworkServer.Listen(hostInfo, 9000);

                NetworkManager.singleton.StartHost(hostInfo);
                NetworkManager.networkState = NetworkManager.NetworkState.Host;
            }
            else
            {
                Debug.LogError("Create match failed");
            }
        }

        private void OnInternetMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
        {
            if (success)
            {
                if (matches.Count != 0)
                {
                    Debug.Log("join match");
                    NetworkManager.singleton.matchMaker.JoinMatch(matches[matches.Count - 1].networkId, privatePassword, "", "", 0, 0, OnJoinInternetMatch);
                }
                else
                {
                    Debug.Log("create match");
                    CreateInternetMatch(privateMatchName, privatePassword);
                }
            }
            else
            {
                Debug.LogError("Couldn't connect to match maker");
            }
        }

        private void OnJoinInternetMatch(bool success, string extendedInfo, MatchInfo matchInfo)
        {
            if (success)
            {
                Debug.Log("Able to join a match");

                MatchInfo hostInfo = matchInfo;
                NetworkManager.singleton.StartClient(hostInfo);
                NetworkManager.networkState = NetworkManager.NetworkState.Client;
            }
            else
            {
                Debug.LogError("Join match failed");
            }
        }
        #endregion CallBack
    }
}