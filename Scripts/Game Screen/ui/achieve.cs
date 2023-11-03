using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achieve : MonoBehaviour
{
    public achievement achivementCheck;
    public health player_health;
    public character_movement player_movement;
    public achievementDb dbHelper;
    
    public void killCount()
    {
        achivementCheck.killedEnemies += 1;
        dbHelper.updateKillCount(achivementCheck.killedEnemies);
    }

    public void weaponCount()
    {
        achivementCheck.obtainedWeapons += 1;
        dbHelper.updateWeaponCount(achivementCheck.obtainedWeapons);
    }

    private void Update()
    {
        
        if (achivementCheck.killedEnemies >= 1000)
        {
            dbHelper.updateAchievement5();
        } else if (achivementCheck.killedEnemies >= 100)
        {
            dbHelper.updateAchievement4();
        }
        else if (achivementCheck.killedEnemies >= 10)
        {
            dbHelper.updateAchievement3();
        }

        if (achivementCheck.obtainedWeapons == 1)
        {
            dbHelper.updateAchievement8();
        } else if (achivementCheck.obtainedWeapons == 6)
        {
            dbHelper.updateAchievement12();
        }

        if (achivementCheck.finished >= 10)
        {
            dbHelper.updateAchievement2();
        }

        try
        {
            if (player_movement.isAFK == true && player_health.isDead == true)
            {
                dbHelper.updateAchievement10();
            }

            if (achivementCheck.finalHit == "Rat")
            {
                dbHelper.updateAchievement9();
            }
        } catch
        {
            //DO NOTHING FOR FORGE ONLY AND MAP 1
        }

        

    }
}
