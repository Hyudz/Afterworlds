using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
   
    public void toAchievement()
    {
        SceneManager.LoadScene("Achievement");
    }

    public void toStore()
    {
        SceneManager.LoadScene("Store");
    }

    public void toInventory()
    {
        SceneManager.LoadScene("Inventory");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}