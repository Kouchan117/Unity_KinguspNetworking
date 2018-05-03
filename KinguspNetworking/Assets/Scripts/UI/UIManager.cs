using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingusp.UI
{
    public class UIManager : MonoBehaviour
    {
        private GameObject nowPanel = null;

        #region Method
        public void ChangePanel(GameObject nextPanel)
        {
            if (nowPanel == nextPanel) return;
            if (nowPanel != null)
                nowPanel.SetActive(false);
            nowPanel = nextPanel;
            nowPanel.SetActive(true);
        }
        #endregion
    }
}