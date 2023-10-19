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
    public countdownBar countdown_bar;

    [Header("Spawners Map 2")]
    public enemy_spawner deer_spawner;
    public enemy_spawner posGoblin_spawner;
    public enemy_spawner negGoblin_spawner;
    public enemy_spawner owl_spawner;

    [Header("Enemy Health Stats")]
    public enemy_health[] deer_health;
    public enemy_health[] owl_health;
    public enemy_health[] goblin_health;

    [Header("Enemy Attack Stats")]
    public enemy_atk[] deer_atk;
    public enemy_atk[] owl_atk;
    public enemy_atk[] goblin_atk;

    [Header("Enemy Movement Stats")]
    public enemy[] deer_enem;
    public enemy[] owl_enem;
    public enemy[] goblin_enem;

    private bool in4Mins = false;
    private bool in3Mins = false;
    private bool in2Mins = false;
    private bool in1Min = false;

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
            countdown_bar.value(textTime);
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

                //reduce attack cooldown for the deer
                foreach (enemy_atk deerAtk in deer_atk)
                {
                    deerAtk.attackCooldown -= 3;
                }

                //add movement speed for the goblin
                foreach (enemy goblinSpd in goblin_enem)
                {
                    goblinSpd.movement_speed += 10.0f;
                }

                
                }
                else if (textTime == 180 && in3Mins == false) // 3 mins
                {
                in3Mins = true;
                reducedInterval(2);

                //add attack range for the owl
                foreach (enemy_atk owlRange in owl_atk)
                {
                    owlRange.boxHeight += 3.0f;
                    owlRange.boxWidth += 3.0f;
                }

                //add hp for the deer
                foreach (enemy_health deerHealth in deer_health)
                {
                    deerHealth.maxHealth += 2;
                }
            }
                else if (textTime == 120 && in2Mins == false) // 2 mins
                {
                in2Mins=true;
                reducedInterval(2);

                //reduce the attack cooldown for the goblins
                foreach (enemy_atk goblinAtk in goblin_atk)
                {
                    goblinAtk.attackCooldown -= 2;
                }

                //add movement speed for the owl
                foreach (enemy owlSpd in owl_enem)
                {
                    owlSpd.movement_speed += 10.0f;
                }
            }
                else if (textTime == 60 && in1Min == false) // 1 min
                {

                //add movement speed for each deer
                foreach (enemy deerSpd in deer_enem)
                {
                    deerSpd.movement_speed += 10.0f;
                }

                //add hp for each goblin
                foreach (enemy_health goblinHp in goblin_health)
                {
                    goblinHp.maxHealth += 3;
                }

                //reduce atk cd for each owl
                foreach (enemy_atk owlCd in owl_atk)
                {
                    owlCd.attackCooldown -= 4;
                }


                in1Min = true;

            }
            
        }
    }

    //reduce the interval for each spawner
    private void reducedInterval(int interval)
    {
        deer_spawner.spawnInterval -= interval;
        negGoblin_spawner.spawnInterval -= interval -1;
        posGoblin_spawner.spawnInterval -= interval -1;
        owl_spawner.spawnInterval -= interval;
    }
}
