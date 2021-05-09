using UnityEngine;

namespace DarkenDinosaur.UI
{
    public class MobileLayerPresenter : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private GameObject mobileLayer;

        private void Awake()
        {
#if UNITY_ANDROID || UNITY_IOS
            this.mobileLayer.SetActive(true);
#endif
        }
    }
}
