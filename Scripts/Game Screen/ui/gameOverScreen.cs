using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public inventoryForge items;
    public inventoryDb inventoryHelper;
    public gameloadDb dbHelper;

    [Header("In Game Rewards")]
    public TextMeshProUGUI reward1;
    public TextMeshProUGUI reward2;
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
        reward1.SetText("Coins x"+sceneinfo.current_aftercoins.ToString());
        reward2.SetText("Blueite x" + sceneinfo.currentBlueite.ToString());
        
        foreach (GameObject spawns in spawners)
        {
            spawns.SetActive(false);
        }
    }

    public void retry1()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game Screen");
        
        gameIsOver = false;

        /*inventoryHelper.readBlueite();
        inventoryHelper.readGreenite();
        inventoryHelper.readCoins(); */

        items.blueite_values += sceneinfo.currentBlueite;
        items.greenite_values += sceneinfo.currentGreenite;
        sceneinfo.aftercoins += sceneinfo.current_aftercoins;

        inventoryHelper.updateBlueite(items.blueite_values);
        inventoryHelper.updateGreenite(items.greenite_values);
        inventoryHelper.updateCoins(sceneinfo.aftercoins);

        sceneinfo.current_aftercoins = 0;
        sceneinfo.currentBlueite = 0;
        sceneinfo.currentGreenite = 0;
        sceneinfo.currentMap = 1;
        sceneinfo.retry();

    }

    public void retry()
    {
        Time.timeScale = 1.0f;
        gameIsOver = false;

        /*inventoryHelper.readBlueite();
        inventoryHelper.readGreenite();
        inventoryHelper.readCoins(); */

        items.blueite_values += sceneinfo.currentBlueite;
        items.greenite_values += sceneinfo.currentGreenite;
        sceneinfo.aftercoins += sceneinfo.current_aftercoins;

        inventoryHelper.updateBlueite(items.blueite_values);
        inventoryHelper.updateGreenite(items.greenite_values);
        inventoryHelper.updateCoins(sceneinfo.aftercoins);

        sceneinfo.current_aftercoins = 0;
        sceneinfo.currentBlueite = 0;
        sceneinfo.currentGreenite = 0;
        sceneinfo.currentMap = 1;
        sceneinfo.retry();
    }

    public void returnToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main Menu");

        /*inventoryHelper.readBlueite();
        inventoryHelper.readGreenite();
        inventoryHelper.readCoins(); */

        items.blueite_values += sceneinfo.currentBlueite;
        items.greenite_values += sceneinfo.currentGreenite;
        sceneinfo.aftercoins += sceneinfo.current_aftercoins;
        dbHelper.deleteGame(sceneinfo.currentButton);

        inventoryHelper.updateBlueite(items.blueite_values);
        inventoryHelper.updateGreenite(items.greenite_values);
        inventoryHelper.updateCoins(sceneinfo.aftercoins);
        
        sceneinfo.current_aftercoins = 0;
        sceneinfo.currentBlueite = 0;
        sceneinfo.currentGreenite = 0;
    }

    
}
