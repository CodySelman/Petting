using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button resumeButton;
    public Button restartButton;
    public Button quitButton;

    public AudioClip[] petSounds;
    public GameObject[] pettableObjects;

    public static bool isGamePaused = false;

    private void Start()
    {
        Resume();
    }

    void Update()
    {
        if (isGamePaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
            {
                Resume();
            } else if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Title");
            } else if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        } else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
    }

    private void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1f;
    }

    private void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
}
