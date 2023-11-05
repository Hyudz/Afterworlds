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
        if (achivementCheck.killedEnemies >= 1000 && achivementCheck.achivement5 == false)
        {
            dbHelper.updateAchievement5();
        }
        else if (achivementCheck.killedEnemies >= 100 && achivementCheck.achivement4 == false)
        {
            dbHelper.updateAchievement4();
        }
        else if (achivementCheck.killedEnemies >= 10 && achivementCheck.achivement3 == false)
        {
            dbHelper.updateAchievement3();
        }

        if (achivementCheck.obtainedWeapons == 1 && achivementCheck.achivement8 == false)
        {
            dbHelper.updateAchievement8();
        }
        else if (achivementCheck.obtainedWeapons == 6 && achivementCheck.achivement12 == false)
        {
            dbHelper.updateAchievement12();
        }

        if (achivementCheck.finished >= 10 && achivementCheck.achivement2 == false)
        {
            dbHelper.updateAchievement2();
        }

        try
        {
            if (player_movement.isAFK == true && player_health.isDead == true && achivementCheck.achivement10 == false)
            {
                dbHelper.updateAchievement10();
            }

            if (achivementCheck.finalHit == "Rat" && achivementCheck.achivement9 == false)
            {
                dbHelper.updateAchievement9();
            }
        } catch
        {
            //DO NOTHING FOR FORGE ONLY AND MAP 1
        }

        

    }
}
