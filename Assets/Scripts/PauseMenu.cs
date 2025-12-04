using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        
        if (pauseUI == null)
        {
            return;
        }

        pauseUI.SetActive(false);
        IsPaused = false;

    }

    // Update is called once per frame
    void Update()
    {
        // Detect Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("Resume");
        pauseUI.SetActive(false);
        Time.timeScale = 1.0f; 
        IsPaused = false;
    }

    void Pause()
    {
        Debug.Log("Paused");
        pauseUI.SetActive(true);
        Time.timeScale = 0.0f;  
        IsPaused = true;
    }
    public void QuitToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Debug.Log("Quiteded");
        Application.Quit();
    }
    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(2);
    }

}
