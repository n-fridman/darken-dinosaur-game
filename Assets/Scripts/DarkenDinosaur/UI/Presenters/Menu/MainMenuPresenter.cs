using UnityEngine;

namespace DarkenDinosaur.UI.Presenters.Menu
{
    [AddComponentMenu("Darken Dinosaur/UI/Presenters/Menu/Main Menu Presenter")]
    public class MainMenuPresenter : MonoBehaviour
    {
        [Header("Components")] 
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