using UnityEngine;
using UnityEngine.SceneManagement;

namespace DarkenDinosaur.Managers
{
    public class GameSceneManager : MonoBehaviour
    {
        /// <summary>
        /// Restart level event handler.
        /// </summary>
        public void OnRestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
