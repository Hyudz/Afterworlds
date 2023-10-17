using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverScreen : MonoBehaviour
{
    public Canvas character_ui;
    public Canvas game_ui;
    public Canvas timer_ui;
    public bool gameIsOver = false;
    public GameObject[] spawners;
    public sceneInfo sceneinfo;
    //public Button pauseButton;
    public void Start()
    {
        gameIsOver = false;
    }

    public void Hide()
    {
        character_ui.enabled = false;
        game_ui.enabled = false;
        timer_ui.enabled = false;

        foreach (GameObject spawns in spawners)
        {
            spawns.SetActive(false);
        }
    }

    public void retry1()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game Screen");
        sceneinfo.retry();
        gameIsOver = false;
    }

    public void retry()
    {
        Time.timeScale = 1.0f;
        sceneinfo.retry();
        gameIsOver = false;
    }

    public void returnToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main Menu");
    }

    
}
