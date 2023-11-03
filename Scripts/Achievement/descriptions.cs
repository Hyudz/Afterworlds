using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class descriptions : MonoBehaviour
{
    public TextMeshProUGUI title, description;

    public void achivement1()
    {
        title.SetText("Beginner's Luck");
        description.SetText("Finish the first map without getting killed");
    }

    public void achivement2()
    {
        title.SetText("Touch Some Grass");
        description.SetText("Finish the Game ten times");
    }

    public void achivement3()
    {
        title.SetText("Shindee");
        description.SetText("Kill 10 Enemies");
    }

    public void achivement4()
    {
        title.SetText("Junior Reaper");
        description.SetText("Kill 100 Enemies");
    }

    public void achivement5()
    {
        title.SetText("God of War");
        description.SetText("Kill 1000 enemies");
    }

    public void achivement6()
    {
        title.SetText("Who's the boss now?");
        description.SetText("Kill the boss for the first time");
    }

    public void achivement7()
    {
        title.SetText("Noob");
        description.SetText("Get Killed during the easy level of the game");
    }

    public void achivement8()
    {
        title.SetText("Black smith trainee");
        description.SetText("Forge an item");
    }

    public void achivement9()
    {
        title.SetText("Ratatouille");
        description.SetText("Get killed by rats");
    }

    public void achivement10()
    {
        title.SetText("AFK");
        description.SetText("Get killed while in idle");
    }

    public void achivement11()
    {
        title.SetText("Smash or Pass");
        description.SetText("Get Killed by the boss");
    }

    public void achivement12()
    {
        title.SetText("Weapon's master");
        description.SetText("Obtain all the weapon tyoes");
    }
}
