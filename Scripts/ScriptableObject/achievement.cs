using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AchivementList", menuName = "Achievement List")]
public class achievement : ScriptableObject
{
    public bool achivement1 = false; // Beginner's luck - finish the map without getting killed
    public bool achivement2 = false; // Touch some grass - finish the game without being killed
    public int finished;
    public bool achivement3 = false; // Shindee - kill 10 enemies
    public bool achivement4 = false; // Junior reaper - kill 100 enemies
    public bool achivement5 = false; // God of War - Kill 1000 enemies
    public int killedEnemies;
    public bool achivement6 = false; // Who's the boss now? - Kill the boss for the first time
    public bool achivement7 = false; // Noob - Get killed at the start of the game
    public bool achivement8 = false; // Black Smith Trainee - Forge an item
    public bool achivement9 = false; // It is what it is - Get killed by common mobs
    public string finalHit;
    public bool achivement10 = false; // AFK - Get killed while in idle
    public bool achivement11 = false; // Smash or Pass? - Get killed by the boss
    public bool achivement12 = false; // Weapons Master - Obtain all the weapon types
    public int obtainedWeapons;

    private void OnEnable()
    {
        achivement1 = false;
        achivement2 = false;
        achivement3 = false;
        achivement4 = false;
        achivement5 = false;
        achivement6 = false;
        achivement7 = false;
        achivement8 = false;
        achivement9 = false;
        achivement10 = false;
        achivement11 = false;
        achivement12 = false;
        killedEnemies = 0;
        obtainedWeapons = 0;
        finished = 0;
        finalHit = "";
    }
}
