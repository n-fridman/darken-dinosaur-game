using UnityEngine;

namespace DarkenDinosaur.UI
{
    public class DesktopLayerPresenter : MonoBehaviour
    {
        [Header("Game objects")] 
        [SerializeField] private GameObject desktopLayer;

        private void Awake()
        {
#if UNITY_STANDALONE
            this.desktopLayer.SetActive(true);   
#endif
        }
    }
}
