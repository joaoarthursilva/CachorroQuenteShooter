using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    [SerializeField] private bool isPaused = false;
    private bool _togglePause = false;

    void Start()
    {
        pauseMenu.SetActive(false);
    }
    
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
    }

    private void TogglePause(bool togglePause)
    {
        switch (isPaused)
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
        SceneManager.LoadScene("MainMenu");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    void Update()
    {
        _togglePause = Input.GetKeyDown(KeyCode.Escape);
        TogglePause(_togglePause);
    }
}