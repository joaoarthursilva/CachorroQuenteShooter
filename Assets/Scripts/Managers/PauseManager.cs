using Player;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject settingsMenu;
        private bool _isPaused;
        private bool _togglePause;

        private void Start()
        {
            if (settingsMenu != null)
                settingsMenu.SetActive(false);
            _isPaused = false;
            _togglePause = false;
            if (pauseMenu != null)
                pauseMenu.SetActive(false);
        }

        public void ResumeGame()
        {
            _isPaused = false;
            settingsMenu.SetActive(false);
            pauseMenu.SetActive(false);
            if (GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().IsDead()) return;
            Time.timeScale = 1;
        }

        private void PauseGame()
        {
            _isPaused = true;
            Time.timeScale = 0;
            pauseMenu.gameObject.SetActive(true);
        }

        public void OpenSettings()
        {
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }

        public void CloseSettings()
        {
            pauseMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }

        private void TogglePause(bool togglePause)
        {
            switch (_isPaused)
            {
                case false when togglePause: //esc to pause
                    PauseGame();
                    break;
                case true when togglePause: //esc to unpause
                    ResumeGame();
                    break;
            }
        }

        public void BackToMainMenu()
        {
            DiedScreen.ReverseDontDestroy();
            SceneManager.LoadScene("MainMenu");
        }

        public void CloseGame()
        {
            Application.Quit();
        }

        private void Update()
        {
            _togglePause = Input.GetKeyDown(KeyCode.Escape);
            TogglePause(_togglePause);
        }
    }
}