using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class startingTimer : MonoBehaviour
{
    public TextMeshProUGUI coundownTimer;
    private float currentTime = 4.0f;
    public bool inCountdown = true;
    private float timer = 1.0f;
    int textTime;
    public gameTimer gameTimer;
    public GameObject[] gameUI;


    public void Update()
    {
        //Time.timeScale = 0f;
        currentTime -= Time.deltaTime;
        textTime = (int) currentTime;
        coundownTimer.SetText(textTime.ToString());

        if (currentTime <= timer)
        {
            gameTimer.startCount = true;   
            coundownTimer.enabled = false;
            inCountdown = false;
            //OnEnable();

            foreach (GameObject objects in gameUI)
            {
                try
                {
                    objects.SetActive(true);
                } catch
                {
                    Debug.Log("Object is disabled");
                }
            }
        } else
        {
            foreach (GameObject objects in gameUI)
            {
                objects.SetActive(false);
            }
        }
    }

}
