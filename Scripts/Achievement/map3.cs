using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map3 : MonoBehaviour
{
    public map3_gameTimer map3Timer;
    public health player_health;
    public achievement achivementChecker;
    public achievementDb dbHelper;

    // Update is called once per frame
    void Update()
    {
        if (map3Timer.bossFight == true && player_health.isDead)
        {
            dbHelper.updateAchievement11();
        }
    }
}
