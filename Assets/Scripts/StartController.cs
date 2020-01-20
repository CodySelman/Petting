using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Title")
        {
            startButton.onClick.AddListener(() => SceneManager.LoadScene("0-1 Transition"));
            quitButton.onClick.AddListener(() => Application.Quit());
        } else if (sceneName == "0-1 Transition")
        {
            startButton.onClick.AddListener(() => SceneManager.LoadScene("Level 1"));
        }
        else if (sceneName == "1-2 Transition")
        {
            startButton.onClick.AddListener(() => SceneManager.LoadScene("Level 2"));
        } else if (sceneName == "2-3 Transition")
        {
            startButton.onClick.AddListener(() => SceneManager.LoadScene("Level 3"));
        } else if (sceneName == "3-4 Transition")
        {
            startButton.onClick.AddListener(() => SceneManager.LoadScene("Level 4"));
        } else if (sceneName == "Game Over")
        {
            startButton.onClick.AddListener(() => SceneManager.LoadScene("0-1 Transition"));
            quitButton.onClick.AddListener(() => Application.Quit());
        }
    }
}
