using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mpa1 : MonoBehaviour
{
    public achievement achievementChecker;
    public achievementDb dbHelper;
    public gameTimer map1Timer;
    public health player_health;

    // Update is called once per frame
    void Update()
    {
        if (map1Timer.inMap1 == true && player_health.isDead == true)
        {
            dbHelper.updateAchievement7();
        }
    }
}
