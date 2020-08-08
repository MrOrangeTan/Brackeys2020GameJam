using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject Song;

    public void StartGame()
    {
        SceneManager.LoadScene("Room1");
    }

    private void Start()
    {
        try
        {
            if (FindObjectOfType<AudioSource>())
                return;
            GameObject s = Instantiate(Song);
            DontDestroyOnLoad(s);
        }
        catch { }
    }
}
