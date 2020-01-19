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
        startButton.onClick.AddListener(() => SceneManager.LoadScene("Level 1"));
        quitButton.onClick.AddListener(() => Application.Quit());
    }
}
