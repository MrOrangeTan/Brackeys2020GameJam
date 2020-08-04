using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject optionsMenuUI;
    [SerializeField] private KeyCode pauseButton;

    private bool isGamePause= false;

    private void Awake()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            if (isGamePause)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    void pause()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        isGamePause = true;
    }

    void resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(true);
        isGamePause = false;
    }

    public void loadOptions()
    {
        optionsMenuUI.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
