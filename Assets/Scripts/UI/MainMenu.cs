using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject mainMenu;
        public GameObject settingsMenu;
        public void Leave()
        {
            Application.Quit();
        }

        public void StartGame()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void OpenSettings()
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }
    }
}