using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class startingTimer : MonoBehaviour
{
    public TextMeshProUGUI coundownTimer;
    private float currentTime = 4.0f;
    private float timer = 1.0f;
    int textTime;
    public gameTimer gameTimer;

    [Header("Spawners")]
    public spawn_Enemy_ratv1 spawner1;

    private void Start()
    {
        Time.timeScale = 0;
    }


    public void Update()
    {
        //Time.timeScale = 0f;
        currentTime -= Time.deltaTime;
        textTime = (int) currentTime;
        coundownTimer.SetText(textTime.ToString());

        if (currentTime <= timer)
        {
            Time.timeScale = 1.0f;
            gameTimer.startCount = true;
            coundownTimer.enabled = false;
            //OnEnable();
        }
    }

}
