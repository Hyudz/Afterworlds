using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseButton : MonoBehaviour
{

    //public GameObject pause_panel;
    public void saveAndExit()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void continueGame(){
        Time.timeScale = 1.0f;
        //pause_panel.SetActive(false);
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        //pause_panel.SetActive(false);
    }
}
