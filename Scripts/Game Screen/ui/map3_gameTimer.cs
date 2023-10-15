using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class map3_gameTimer : MonoBehaviour
{

    [SerializeField] public float currentTime;
    public TextMeshProUGUI currentTimeText;
    int textTime;
    public bool startCount = false;
    public gameOverScreen gameOver;

    [Header("Spawners Map 3")]
    public enemy_spawner ghoul_spawner;
    public enemy_spawner swordsman_spawner;

    private bool in2Mins = false;
    private bool in1Mins = false;

    // Update is called once per frame

    private void Start()
    {
        startCount = false;
    }
    void Update()
    {
        if (startCount == true && gameOver.gameIsOver != true)
        {
            currentTime -= Time.deltaTime;
            textTime = (int) currentTime;
            currentTimeText.SetText(textTime.ToString());
                if (currentTime <= 0)
                {
                    //Summon the boss
                }
                else if (textTime == 120 && in2Mins == false) // 2 mins
                {
                in2Mins = true;
                ghoul_spawner.spawnInterval -= 2;
                swordsman_spawner.spawnInterval -= 1;
                }
                else if (textTime == 60 && in1Mins == false) // 1 mins
                {
                in1Mins =true;
                ghoul_spawner.spawnInterval -= 2;
                swordsman_spawner.spawnInterval -= 1;
                }
            
        }
    }
}
