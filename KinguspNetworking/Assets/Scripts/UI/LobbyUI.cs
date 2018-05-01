using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Kingusp.UI
{
    public class LobbyUI : UIManager
    {
        #region Panel
        [SerializeField] private GameObject MainPanel;
        [SerializeField] private GameObject HostPanel;
        [SerializeField] private GameObject ServerPanel;
        [SerializeField] private GameObject ClientPanel;
        #endregion Panel

        #region MainPanel
        public void OnClickStartHost()
        {
            Debug.Log("OnClickStartHost");
            NetworkManager.singleton.StartHost();
            ChangePanel(HostPanel);
        }

        public void OnClickStartServer()
        {
            Debug.Log("OnClickStartServer");
            NetworkManager.singleton.StartServer();
            ChangePanel(ServerPanel);
        }

        public void OnClickStartClient()
        {
            Debug.Log("OnClickStartClient");
            NetworkManager.singleton.StartClient();
            ChangePanel(ClientPanel);
        }

        public void OnClickQuit()
        {
            Application.Quit();
        }
        #endregion MainPanel

        #region UnityMethod
        private void Awake()
        {
            ChangePanel(MainPanel);
        }
        #endregion
    }
}