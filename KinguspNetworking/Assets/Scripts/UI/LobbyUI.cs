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
        #endregion Panel

        #region MainPanel
        public void OnClickCreateMatch()
        {
            MatchMaker.singleton.CreateInternetMatch("Test");
        }

        public void OnClickFindMatch()
        {
            MatchMaker.singleton.FindInternetMatch("Test");
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