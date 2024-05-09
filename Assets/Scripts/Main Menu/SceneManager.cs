using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public TimerCanvas timerCanvas;

    
    public void PlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
