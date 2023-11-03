using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class startingTimer_map2 : MonoBehaviour
{
    public TextMeshProUGUI coundownTimer;
    private float currentTime = 4.0f;
    private float timer = 1.0f;
    int textTime;
    public map2_gameTimer gameTimer2;
    public bool inCountdown = true;
    public GameObject[] gameUI;

    public void Update()
    {
        //Time.timeScale = 0f;
        currentTime -= Time.deltaTime;
        textTime = (int) currentTime;
        coundownTimer.SetText(textTime.ToString());

        if (currentTime <= timer)
        {
            gameTimer2.startCount = true;
            inCountdown = false;
            coundownTimer.enabled = false;
            foreach (GameObject objects in gameUI)
            {
                try
                {
                    objects.SetActive(true);
                } catch
                {
                    Debug.Log("Object is destroyed");
                }
            }
        }
        else
        {
            foreach (GameObject objects in gameUI)
            {
                objects.SetActive(false);
            }
        }
    }

}
