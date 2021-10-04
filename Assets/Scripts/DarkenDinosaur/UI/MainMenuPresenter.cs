using UnityEngine;

namespace DarkenDinosaur.UI
{
    [AddComponentMenu("Darken Dinosaur/UI/Main Menu Presenter")]
    public class MainMenuPresenter : MonoBehaviour
    {
        [Header("Modules")] 
        [SerializeField] private GameObject _mainMenuContainer;

        /// <summary>
        /// Show main menu.
        /// </summary>
        public void ShowMainMenu()
        {
            _mainMenuContainer.SetActive(true);
        }
        
        /// <summary>
        /// Hide main menu.
        /// </summary>
        public void HideMainMenu()
        {
            _mainMenuContainer.SetActive(false);
        }
    }
}