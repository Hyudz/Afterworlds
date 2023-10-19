using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseButton : MonoBehaviour
{
    public sceneInfo sceneinfo;
    //public GameObject pause_panel;
    public void saveAndExit()
    {
        Time.timeScale = 1.0f;
        sceneinfo.current_aftercoins = 0;
        SceneManager.LoadScene("Main Menu");
    }

    public void continueGame(){
        Time.timeScale = 1.0f;
        //pause_panel.SetActive(false);
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        Debug.Log("Game paused");
        //pause_panel.SetActive(false);
    }
}
