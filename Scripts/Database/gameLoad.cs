using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gameLoad : MonoBehaviour
{
    public Button[] gameButtons;
    public Button addBtn;
    public bool btn1_interact = false;
    public bool btn2_interact = false;
    public bool btn3_interact = false;
    public gameloadDb loadDb;
    public sceneInfo sceneinfo;
    public GameObject[] deleteButtons;
    public TextMeshProUGUI[] userText;
    public TextMeshProUGUI[] userCoins;
    public TextMeshProUGUI[] remainingTime;
    public GameObject[] coinImage;

    public void checkData()
    {
        loadDb.checkGame1();
        loadDb.checkGame2();
        loadDb.checkGame3();

        if (loadDb.game1Uid == 1)
        {
            gameButtons[0].interactable = true;
            deleteButtons[0].SetActive(true);
            userText[0].SetText("User 1");
            loadDb.checkData(1);
            userCoins[0].SetText(":" + sceneinfo.current_aftercoins);
            remainingTime[0].SetText("Remaining Time: \n" + (int)sceneinfo.currentTime);
            coinImage[0].SetActive(true);
        }
        else
        {
            gameButtons[0].interactable = false;
            deleteButtons[0].SetActive(false);
            userText[0].SetText("New Game");
            userCoins[0].SetText("");
            remainingTime[0].SetText("");
            coinImage[0].SetActive(false);
        }

        if (loadDb.game2Uid == 2)
        {
            gameButtons[1].interactable = true;
            deleteButtons[1].SetActive(true);
            userText[1].SetText("User 2");
            loadDb.checkData(2);
            userCoins[1].SetText(":" + sceneinfo.current_aftercoins);
            remainingTime[1].SetText("Remaining Time: \n" + (int)sceneinfo.currentTime);
            coinImage[1].SetActive(true);
        }
        else
        {
            gameButtons[1].interactable = false;
            deleteButtons[1].SetActive(false);
            userText[1].SetText("New Game");
            userCoins[1].SetText("");
            remainingTime[1].SetText("");
            coinImage[1].SetActive(false);
        }

        if (loadDb.game3Uid == 3)
        {
            gameButtons[2].interactable = true;
            deleteButtons[2].SetActive(true);
            userText[2].SetText("User 3");
            loadDb.checkData(3);
            userCoins[2].SetText(":" + sceneinfo.current_aftercoins);
            remainingTime[2].SetText("Remaining Time: \n" + (int)sceneinfo.currentTime);
            coinImage[2].SetActive(true);
        }
        else
        {
            gameButtons[2].interactable = false;
            deleteButtons[2].SetActive(false);
            userText[2].SetText("New Game");
            userCoins[2].SetText("");
            coinImage[2].SetActive(false);
            remainingTime[2].SetText("");
        }
    }

    public void Start()
    {
        checkData();
    }

    public void Update()
    {
        checkData();
    }

    public void btn1()
    {
        sceneinfo.currentButton = 1;
        loadDb.readGame(1);
    }

    public void btn2()
    {
        sceneinfo.currentButton = 2;
        loadDb.readGame(2);
    }

    public void btn3()
    {
        sceneinfo.currentButton = 3;
        loadDb.readGame(3);
    }

    public void add()
    {
        //check();
        if (loadDb.game1Uid == 0)
        {
            gameButtons[0].interactable = true;
            loadDb.insertGame(1, 1, 1, 3, 5, 47, 54,0,30,300, 0, 0, 0,"pos");

        } 
        
        else if (loadDb.game2Uid == 0)
        {
            gameButtons[1].interactable = true;
            loadDb.insertGame(2, 1, 1, 3, 5, 47, 54, 0, 30, 300, 0, 0, 0,"pos");
        } 
        
        else if (loadDb.game3Uid == 0)
        {
            gameButtons[2].interactable = true;
            loadDb.insertGame(3, 1, 1, 3, 5, 47, 54, 0, 30, 300,0,0,0,"pos");
        }
    }

    public void deleleGame1()
    {

        loadDb.deleteGame(1);
        loadDb.game1Uid = 0;
        gameButtons[0].interactable = false;
        btn1_interact = false;
  
    }

    public void deleleGame2()
    {

        loadDb.deleteGame(2);
        gameButtons[1].interactable = false;
        loadDb.game2Uid = 0;
        btn2_interact = false;
        
    }

    public void deleleGame3()
    {

        loadDb.deleteGame(3);
        gameButtons[2].interactable = false;
        loadDb.game3Uid = 0;
        btn3_interact = false;
        
        
    }
}
