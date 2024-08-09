using UnityEngine;

namespace TicTacMagic
{
    public class GameMenuManager : MonoBehaviour
    {
        [SerializeField] UIMenu pauseMenu;

        private void OpenPauseMenu()
        {
            if(pauseMenu.gameObject.activeSelf)
                pauseMenu.gameObject.SetActive(false);
            else
                pauseMenu.gameObject.SetActive(true);
        }
    }
}
