using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverScreen : MonoBehaviour
{
    public Canvas character_ui;
    public Canvas game_ui;
    //public Button pauseButton;
    public void Start()
    {

    }

    public void Hide()
    {
        character_ui.enabled = false;
        game_ui.enabled = false;
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    
}
