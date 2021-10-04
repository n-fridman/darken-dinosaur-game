using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PanelsControlSystem
{
    public class PanelsManager : MonoBehaviour
    {
        [System.Serializable]
        private struct PanelsManagerEvents
        {
            public UnityEvent<Panel> panelOpened;
            public UnityEvent<Panel> panelClosed;
        }
        
        [Header("Settings")] 
        [SerializeField] private List<Panel> _panels;
        [SerializeField] private Panel _openedPanel;
        [SerializeField] private PanelsManagerEvents _events;
        
        /// <summary>
        /// Open panel by name.
        /// </summary>
        /// <param name="panel">Panel name to open.</param>
        public void OpenPanel(string panel)
        {
            Panel panelToOpen = _panels.Find(p => p.name == panel);
            _openedPanel = panelToOpen;
            _openedPanel.gameObject.SetActive(true);
            _events.panelOpened?.Invoke(_openedPanel);
        }
        
        /// <summary>
        /// Close opened panel.
        /// </summary>
        public void ClosePanel()
        {
            _openedPanel.gameObject.SetActive(false);
            _events.panelClosed?.Invoke(_openedPanel);
        }
    }
}