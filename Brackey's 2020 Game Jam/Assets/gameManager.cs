using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class gameManager : MonoBehaviour
{
    bool isGamePause;
    [SerializeField] private GameObject pauseMenuUI;

    private void Awake()
    {
        pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isGamePause = !isGamePause;
        if (isGamePause)
        {
            pause();
        }
        else
        {
            resume();
        }
    }
    void pause()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }

    void resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }
}
