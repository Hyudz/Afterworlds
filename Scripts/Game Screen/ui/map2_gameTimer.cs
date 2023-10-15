using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class map2_gameTimer : MonoBehaviour
{

    [SerializeField] public float currentTime;
    public TextMeshProUGUI currentTimeText;
    int textTime;
    public bool startCount = false;
    public gameOverScreen gameOver;

    [Header("Spawners Map 2")]
    public enemy_spawner deer_spawner;
    public enemy_spawner posGoblin_spawner;
    public enemy_spawner negGoblin_spawner;
    public enemy_spawner owl_spawner;

    private bool in4Mins = false;
    private bool in3Mins = false;
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
                    SceneManager.LoadScene("Map 3");
                    //ASCEND TO NEXT WORLD
                }
                else if (textTime == 240 && in4Mins == false) // 4 mins
                {
                in4Mins = true;
                reducedInterval(2);
                }
                else if (textTime == 180 && in3Mins == false) // 3 mins
                {
                in3Mins = true;
                reducedInterval(2);
            }
                else if (textTime == 120 && in2Mins == false) // 2 mins
                {
                in2Mins=true;
                reducedInterval(2);
            }
                else if (textTime == 60 && in1Mins == false) // 1 mins
                {
                in1Mins = true;
                reducedInterval(2);
            }
            
        }
    }

    private void reducedInterval(int interval)
    {
        deer_spawner.spawnInterval -= interval;
        negGoblin_spawner.spawnInterval -= interval;
        posGoblin_spawner.spawnInterval -= interval;
        owl_spawner.spawnInterval -= interval;
    }
}
