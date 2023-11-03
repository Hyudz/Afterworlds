using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameTimer : MonoBehaviour
{

    [SerializeField] public float currentTime;
    public sceneInfo sceneinfo;
    public achievement achivementList;
    public TextMeshProUGUI currentTimeText;
    public int textTime;
    public bool startCount = false;
    public gameOverScreen gameOver;
    public countdownBar countdown_bar;

    [Header("Spawners Map 1")]
    public enemy_spawner rat_spawner;
    public enemy_spawner slime_spawner;
    public enemy_spawner mouth_spawner;

    [Header("Spawner Object")]
    public GameObject[] map1Spawners;

    [Header("Enemy Health Stats")]
    public enemy_health[] rat_health;
    public enemy_health[] slime_health;
    public enemy_health[] mouth_health;

    [Header("Enemy Attack Stats")]
    public enemy_atk[] rat_atk;
    public enemy_atk[] slime_atk;
    public enemy_atk[] mouth_atk;

    [Header("Enemy Movement Stats")]
    public enemy[] rat_enem;
    public enemy[] slime_enem;
    public enemy[] mouth_enem;

    private bool in4Mins = false;
    private bool in3Mins = false;
    private bool in2Mins = false;
    private bool in1Mins = false;
    private bool in10secs = false;
    public bool inMap1 = true;
    public achievementDb dbHelper;

    // Update is called once per frame

    private void Start()
    {
        startCount = false;
    }
    void Update()
    {
        if (startCount == true && gameOver.gameIsOver != true)
        {
            sceneinfo.currentTime -= Time.deltaTime;
            textTime = (int)sceneinfo.currentTime;
            countdown_bar.value(textTime);
            currentTimeText.SetText(textTime.ToString());
                if (textTime <= 0)
                {
                sceneinfo.currentTime = 300;
                    SceneManager.LoadScene("Map 2");
                sceneinfo.currentMap += 1;
                    
                    inMap1 = false;
                    sceneinfo.current_aftercoins += 5;
                    sceneinfo.currentBlueite += 1;

                dbHelper.updateAchievement1();
                //ASCEND TO NEXT WORLD
            }
                else if (textTime == 240 && in4Mins == false) // 4 mins
                {
                // add movement speed of each rat
                    foreach (enemy ratenem in rat_enem)
                    {
                        ratenem.movement_speed += 10.0f;
                    }
                sceneinfo.current_aftercoins += 5;

                in4Mins = true;
                }
                else if (textTime == 180 && in3Mins == false) // 3 mins
                {
                    //reduce the spawn interval
                    slime_spawner.spawnInterval -= 2;
                    mouth_spawner.spawnInterval -= 2;
                sceneinfo.current_aftercoins += 5;

                //add hp to slime
                foreach (enemy_health slimehealth in slime_health)
                    {
                        slimehealth.maxHealth += 2;
                    }

                    //add movement in mouth
                    foreach (enemy mouthEnem in mouth_enem)
                    {
                        mouthEnem.movement_speed += 10.0f;
                    }

                in3Mins = true;
                }
                else if (textTime == 120 && in2Mins == false) // 2 mins
                {
                    
                    //reduce the spawn interval
                    slime_spawner.spawnInterval -= 1;
                    mouth_spawner.spawnInterval -= 1;
                sceneinfo.current_aftercoins += 5;

                //add health for rat
                foreach (enemy_health rathealth in rat_health)
                    {
                        rathealth.maxHealth += 3;
                    }

                    //add attack range for slime
                    foreach (enemy_atk slimeatk in slime_atk)
                    {
                        slimeatk.boxWidth += 3.0f;
                        slimeatk.boxHeight += 3.0f;
                    }

                    //add attack damage in mouth
                    foreach (enemy_atk mouthatk in mouth_atk)
                    {
                        mouthatk.damage += 1;
                    }
                    
                    in2Mins = true;
            }
                else if (textTime == 60 && in1Mins == false) // 1 mins
                {
                    //reduce the spawn interval
                    slime_spawner.spawnInterval -= 2;
                    mouth_spawner.spawnInterval -= 2;
                sceneinfo.current_aftercoins += 5;

                //reduce attack cooldown of rat
                foreach (enemy_atk ratCd in rat_atk)
                    {
                        ratCd.attackCooldown -= 2;
                    }

                    //add movement speed in slime
                    foreach (enemy slimeMove in  slime_enem)
                    {
                        slimeMove.movement_speed += 10;
                    }

                    foreach (enemy_health mouthHealth in mouth_health)
                    {
                        mouthHealth.maxHealth += 3;
                    }
                    in1Mins = true;
            } else if (textTime == 10 && in10secs == false) { 
                foreach (GameObject spawner in map1Spawners)
                {
                    spawner.SetActive(false);
                }
                in10secs = true;
            }
        }
    }
}
