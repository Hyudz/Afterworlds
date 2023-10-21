using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class youwon : MonoBehaviour
{
    public Canvas thisUi;
    public Canvas character_ui;
    public Canvas game_ui;
    public Canvas timer_ui;

    public void Start()
    {
        thisUi.enabled = false;
    }
    public void returnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void hide()
    {
        character_ui.enabled = false;
        game_ui.enabled = false;
        timer_ui.enabled = false;
    }

}
