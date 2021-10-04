using UnityEngine;

namespace PanelsControlSystem
{
    [System.Serializable]
    public struct Panel
    {
        [Tooltip("Panel name.")]
        public string name;
        
        [Tooltip("Panel game object.")]
        public GameObject gameObject;
    }
}