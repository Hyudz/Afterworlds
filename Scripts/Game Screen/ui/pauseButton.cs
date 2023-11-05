using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseButton : MonoBehaviour
{
    public sceneInfo sceneinfo;
    public gameloadDb db;
    //public GameObject pause_panel;
    public void saveAndExit()
    {
        Time.timeScale = 1.0f;
        db.updateAtkSpd(sceneinfo.currentButton, sceneinfo.attackCd);
        db.updateDmg(sceneinfo.currentButton, sceneinfo.atkDmg);
        db.updateHeight(sceneinfo.currentButton, sceneinfo.boxHeight);
        db.updateWidth(sceneinfo.currentButton, sceneinfo.boxWidth);
        db.updateHP(sceneinfo.currentButton, sceneinfo.health);
        db.updateMaxHP(sceneinfo.currentButton, sceneinfo.maxHealth);
        db.updateLimit(sceneinfo.currentButton, sceneinfo.atkLimit);
        db.updateAtkSpd(sceneinfo.currentButton, sceneinfo.attackCd);
        db.updateMap(sceneinfo.currentButton, sceneinfo.currentMap);
        db.updateCurrentExp(sceneinfo.currentButton, sceneinfo.currentExp);
        db.updateMaxExp(sceneinfo.currentButton, sceneinfo.maxExp);
        db.updateCurrentTime(sceneinfo.currentButton, sceneinfo.currentTime);
        db.updateCoins(sceneinfo.currentButton, sceneinfo.current_aftercoins);
        db.updateBlueite(sceneinfo.currentButton, sceneinfo.currentBlueite);
        db.updateGreenite(sceneinfo.currentButton, sceneinfo.currentGreenite);
        db.updateScaleSize(sceneinfo.currentButton, sceneinfo.scaleSize.x);
        //clear earned rewards
        sceneinfo.current_aftercoins = 0;
        sceneinfo.currentBlueite = 0;
        sceneinfo.currentGreenite = 0;
        SceneManager.LoadScene("Main Menu");
    }

    public void continueGame(){
        Time.timeScale = 1.0f;
        //pause_panel.SetActive(false);
    }

    public void retry() //for map 2 and 3
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game Screen");
        sceneinfo.retry();
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        Debug.Log("Game paused");
        //pause_panel.SetActive(false);
    }
}
