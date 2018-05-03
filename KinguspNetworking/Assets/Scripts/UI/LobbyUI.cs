using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Kingusp.Networking;

namespace Kingusp.UI
{
    public class LobbyUI : UIManager
    {
        #region Panel
        [SerializeField] private GameObject MainPanel;
        [SerializeField] private GameObject PrivatePanel;
        [SerializeField] private GameObject HostPanel;
        [SerializeField] private GameObject ServerPanel;
        [SerializeField] private GameObject ClientPanel;
        [SerializeField] private GameObject ConnectingPanel;
        #endregion Panel

        #region MainPanel
        public void OnClickAutoMatch()
        {
            MatchMaker.singleton.AutoInternetMatch();
        }

        public void OnClickPrivateMatch()
        {
            ChangePanel(PrivatePanel);
        }

        public void OnClickQuit()
        {
            Application.Quit();
        }
        #endregion MainPanel

        #region PrivatePanel
        private string privateMatchName = "";
        private string privatePassword = "";

        public void OnEndEditMatchName(string matchName) { privateMatchName = matchName; }
        public void OnEndEditPassword(string password) { privatePassword = password; }

        public void OnClickJoinMatch()
        {
            if (privateMatchName == "" || privatePassword == "")
            {
                Debug.Log("MatchName or Password is Null");
                return;
            }
            MatchMaker.singleton.AutoInternetMatch(privateMatchName, privatePassword);
        }

        public void OnClickBack()
        {
            ChangePanel(MainPanel);
        }
        #endregion PrivatePanel

        #region HostPanel
        public void OnClickStopHost()
        {
            MatchMaker.singleton.DisConnect();
            ChangePanel(MainPanel);
        }
        #endregion HostPanel

        #region ServerPanel
        public void OnClickStopServer()
        {
            MatchMaker.singleton.DisConnect();
            ChangePanel(MainPanel);
        }
        #endregion ServerPanel

        #region ClientPanel
        public void OnClickStopClient()
        {
            MatchMaker.singleton.DisConnect();
            ChangePanel(MainPanel);
        }
        #endregion HostClient

        #region UnityMethod
        private void Awake()
        {
            ChangePanel(MainPanel);
        }

        private void Update()
        {
            switch (Networking.NetworkManager.networkState)
            {
                case Networking.NetworkManager.NetworkState.Host: ChangePanel(HostPanel); break;
                case Networking.NetworkManager.NetworkState.Server: ChangePanel(ServerPanel); break;
                case Networking.NetworkManager.NetworkState.Client: ChangePanel(ClientPanel); break;
                case Networking.NetworkManager.NetworkState.Connecting: ChangePanel(ConnectingPanel); break;
            }
        }
        #endregion
    }
}