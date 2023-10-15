using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameTimer : MonoBehaviour
{

    [SerializeField] public float currentTime;
    public TextMeshProUGUI currentTimeText;
    int textTime;
    public bool startCount = false;
    public gameOverScreen gameOver;

    [Header("Spawners Map 1")]
    public enemy_spawner rat_spawner;
    public enemy_spawner slime_spawner;
    public enemy_spawner mouth_spawner;

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
            Debug.Log(currentTime);
                if (textTime <= 0)
                {
                    SceneManager.LoadScene("Map 2");
                    //ASCEND TO NEXT WORLD
                }
                else if (textTime == 240 && in4Mins == false) // 4 mins
                {
                    rat_spawner.spawnInterval -= 1;
                    in4Mins = true;
                    Debug.Log("Rat spawner interval" + rat_spawner.spawnInterval);
                }
                else if (textTime == 180 && in3Mins == false) // 3 mins
                {
                    slime_spawner.spawnInterval -= 2;
                    mouth_spawner.spawnInterval -= 2;
                    Debug.Log("Slime spawner interval" + slime_spawner.spawnInterval);
                    Debug.Log("Mouth spawner interval" + mouth_spawner.spawnInterval);
                    in3Mins = true;
                }
                else if (textTime == 120 && in2Mins == false) // 2 mins
                {
                    rat_spawner.spawnInterval -= 1;
                    slime_spawner.spawnInterval -= 1;
                    mouth_spawner.spawnInterval -= 1;
                    Debug.Log("Rat spawner interval" + rat_spawner.spawnInterval);
                    Debug.Log("Slime spawner interval" + slime_spawner.spawnInterval);
                    Debug.Log("Mouth spawner interval" + mouth_spawner.spawnInterval);
                    in2Mins = true;
            }
                else if (textTime == 240 && in1Mins == false) // 1 mins
                {
                    slime_spawner.spawnInterval -= 2;
                    mouth_spawner.spawnInterval -= 2;
                    Debug.Log("Slime spawner interval" + slime_spawner.spawnInterval);
                    Debug.Log("Mouth spawner interval" + mouth_spawner.spawnInterval);
                    in1Mins = true;
            }
        }
    }
}
