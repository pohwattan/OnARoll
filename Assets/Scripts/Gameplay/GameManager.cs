using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu = null;
    [SerializeField] private GameObject endMenu = null;
    private bool isPaused = false;
    private bool isGameOver = false;

    private void OnEnable()
    {
        EventManager.TimerExpired += EndGame;
        EventManager.BoundaryEntered += EndGame;
    }

    private void OnDisable()
    {
        EventManager.TimerExpired -= EndGame;
        EventManager.BoundaryEntered -= EndGame;
    }

    void Start()
    {
        SetActivePauseMenu(false);
        SetActiveEndMenu(false);
    }

    void Update()
    {
        if ((Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.P)) && !isPaused && !isGameOver)
        {
            SetActivePauseMenu(true);
        }
        else if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.P) && isPaused && !isGameOver)
        {
            SetActivePauseMenu(false);
        }
    }

    public void SetActivePauseMenu(bool state)
    {
        pauseMenu.SetActive(state);

        Time.timeScale = state ? 0 : 1;
        isPaused = state;
    }

    private void SetActiveEndMenu(bool state)
    {
        endMenu.SetActive(state);
        Time.timeScale = state ? 0 : 1;
    }

    private void EndGame()
    {
        SetActiveEndMenu(true);
        isGameOver = true;
    }

    public void PlayAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level");
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
