using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    [SerializeField] private GameObject pauseCanvas;
    private bool isGamePaused;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
        pauseCanvas.SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
        pauseCanvas.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }

    public bool GetPauseStatus()
    {
        return isGamePaused;
    }
}
