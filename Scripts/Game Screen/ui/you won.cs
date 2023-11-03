using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class youwon : MonoBehaviour
{
    public Canvas thisUi;
    public Canvas character_ui;
    public Canvas game_ui;
    public Canvas timer_ui;
    public gameloadDb dbHelper;

    [Header ("Database Helpers")]
    public sceneInfo sceneinfo;
    public inventoryForge items;
    public inventoryDb inventoryHelper;

    [Header("Rewards")]
    public TextMeshProUGUI reward1;
    public TextMeshProUGUI reward2;
    public TextMeshProUGUI reward3;
    

    public void Start()
    {
        thisUi.enabled = false;
    }
    public void returnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
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

    public void retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game Screen");

        items.blueite_values += sceneinfo.currentBlueite;
        items.greenite_values += sceneinfo.currentGreenite;
        sceneinfo.current_aftercoins += sceneinfo.aftercoins;

        inventoryHelper.updateBlueite(items.blueite_values);
        inventoryHelper.updateGreenite(items.greenite_values);
        inventoryHelper.updateCoins(sceneinfo.aftercoins);

        sceneinfo.retry();
        sceneinfo.current_aftercoins = 0;
        sceneinfo.currentBlueite = 0;
        sceneinfo.currentGreenite = 0;
    }
    public void hide()
    {
        character_ui.enabled = false;
        game_ui.enabled = false;
        timer_ui.enabled = false;
        reward1.SetText("Coins x" + sceneinfo.current_aftercoins.ToString());
        reward2.SetText("Blueite x"+sceneinfo.currentBlueite.ToString());
        reward3.SetText("Greenite x"+sceneinfo.currentGreenite.ToString());
    }

}
