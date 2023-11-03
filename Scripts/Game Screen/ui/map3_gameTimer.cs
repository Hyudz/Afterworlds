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
    public countdownBar countdown_bar;
    public GameObject[] spawners;
    public GameObject boss;

    [Header("Spawners Map 3")]
    public enemy_spawner ghoul_spawner;
    public enemy_spawner swordsman_spawner;

    [Header("Enemy Health Stats")]
    public enemy_health[] ghoul_health;
    public enemy_health[] swordsman_health;

    [Header("Enemy Attack Stats")]
    public enemy_atk[] ghoul_atk;
    public enemy_atk[] swordsman_atk;

    [Header("Enemy Movement Stats")]
    public enemy[] ghoul_enem;
    public enemy[] swordsman_enem;

    private bool in150Secs = false;
    private bool in2Mins = false;
    private bool in90Secs = false;
    private bool in1Min = false;
    public bool bossFight = false;
    public sceneInfo sceneinfo;

    // Update is called once per frame

    private void Start()
    {
        startCount = false;
    }
    void Update()
    {
        sceneinfo.currentTime = currentTime;
        if (startCount == true && gameOver.gameIsOver != true)
        {
            sceneinfo.currentTime -= Time.deltaTime;
            currentTime -= Time.deltaTime;
            textTime = (int) sceneinfo.currentTime;
            countdown_bar.value(textTime);
            currentTimeText.SetText(textTime.ToString());
            if (currentTime <= 0 && bossFight == false)
            {
                sceneinfo.current_aftercoins += 15;
                sceneinfo.currentBlueite += 3;
                boss.SetActive(true);
                bossFight = true;   
            }
            else if (textTime == 150 && in150Secs == false) // 2 mins and 30 secs
            {
                in150Secs = true;
                ghoul_spawner.spawnInterval -= 1;
                swordsman_spawner.spawnInterval -= 2;

                //add max hp for each of the swordsman
                foreach (enemy_health swordsmanHp in swordsman_health)
                {
                    swordsmanHp.maxHealth += 3;
                }

                //add movement speed for each of the ghoul
                foreach (enemy ghoulSpd in ghoul_enem)
                {
                    ghoulSpd.movement_speed += 10.0f;
                }
            }

            else if (textTime == 120 && in2Mins == false) // 2 mins
            {
                sceneinfo.current_aftercoins += 15;
                //add attack range for each of the swordsman
                foreach (enemy_atk swordsmanRange in swordsman_atk)
                {
                    swordsmanRange.boxHeight += 5.0f;
                    swordsmanRange.boxWidth += 5.0f;
                } 

                //add attack damage for each of the ghoul
                foreach (enemy_atk ghoulAtk in ghoul_atk)
                {
                    ghoulAtk.damage += 1;
                }

                in2Mins = true;
            }
            else if (textTime == 90 && in90Secs == false) // 1 min and 30 secs
            {
                in90Secs = true;
                ghoul_spawner.spawnInterval -= 2;
                swordsman_spawner.spawnInterval -= 1;

                //add attack dmg for swordsman
                foreach (enemy_atk swordsmanAtk in swordsman_atk)
                {
                    swordsmanAtk.damage += 1;
                }

                //reduce attack cooldown for ghoul
                foreach (enemy_atk ghoulCd in ghoul_atk)
                {
                    ghoulCd.attackCooldown -= 3;
                }
            }
            else if (textTime == 60 && in1Min == false)
            {
                sceneinfo.current_aftercoins += 15;
                //add movement speed for swordsman
                foreach (enemy swordsmanSpd in swordsman_enem)
                {
                    swordsmanSpd.movement_speed += 10.0f;
                }

                //add hp for ghoul
                foreach (enemy_health ghoulHp in ghoul_health)
                {
                    ghoulHp.maxHealth += 3;
                }

                in1Min = true;

            } else if (textTime == 10)
            {
                foreach (GameObject spawn in spawners)
                {
                    spawn.SetActive(false);
                }
            }
            
        }
    }

}
