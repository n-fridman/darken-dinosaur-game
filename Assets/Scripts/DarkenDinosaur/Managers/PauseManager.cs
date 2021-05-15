using UnityEngine;

namespace DarkenDinosaur.Managers
{
    public class PauseManager : MonoBehaviour
    {
        /// <summary>
        /// Pause game.
        /// </summary>
        public void Pause() => Time.timeScale = 0;
        
        /// <summary>
        /// Continue game.
        /// </summary>
        public void Continue() => Time.timeScale = 1;
    }
}
