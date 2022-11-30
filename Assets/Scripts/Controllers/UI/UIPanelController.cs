using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Controllers.UI
{
    public class UIPanelController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> uıPanelList = new List<GameObject>();

        public void OpenPanel(UIPanels panelState)
        {
            uıPanelList[(int)panelState].SetActive(true);
        }

        public void ClosePanel(UIPanels panelState)
        {
            uıPanelList[(int)panelState].SetActive(false);
        }
    }
}