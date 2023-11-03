using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achievementChecker : MonoBehaviour
{
    public achievement achievementCheck;
    public GameObject[] lockedAchivement;
    public GameObject[] unlockedAchivement;

    // Update is called once per frame
    void Update()
    {
        if (achievementCheck.achivement1 == true)
        {
            lockedAchivement[0].SetActive(false);
            unlockedAchivement[0].SetActive(true);
        }

        if (achievementCheck.achivement2 == true)
        {
            lockedAchivement[1].SetActive(false);
            unlockedAchivement[1].SetActive(true);
        }

        if (achievementCheck.achivement3 == true)
        {
            lockedAchivement[2].SetActive(false);
            unlockedAchivement[2].SetActive(true);
        }

        if (achievementCheck.achivement4 == true)
        {
            lockedAchivement[3].SetActive(false);
            unlockedAchivement[3].SetActive(true);
        }

        if (achievementCheck.achivement5 == true)
        {
            lockedAchivement[4].SetActive(false);
            unlockedAchivement[4].SetActive(true);
        }

        if (achievementCheck.achivement6 == true)
        {
            lockedAchivement[5].SetActive(false);
            unlockedAchivement[5].SetActive(true);
        }

        if (achievementCheck.achivement7 == true)
        {
            lockedAchivement[6].SetActive(false);
            unlockedAchivement[6].SetActive(true);
        }

        if (achievementCheck.achivement8 == true)
        {
            lockedAchivement[7].SetActive(false);
            unlockedAchivement[7].SetActive(true);
        }

        if (achievementCheck.achivement9 == true)
        {
            lockedAchivement[8].SetActive(false);
            unlockedAchivement[8].SetActive(true);
        }

        if (achievementCheck.achivement10 == true)
        {
            lockedAchivement[9].SetActive(false);
            unlockedAchivement[9].SetActive(true);
        }

        if (achievementCheck.achivement11 == true)
        {
            lockedAchivement[10].SetActive(false);
            unlockedAchivement[10].SetActive(true);
        }

        if (achievementCheck.achivement12 == true)
        {
            lockedAchivement[11].SetActive(false);
            unlockedAchivement[11].SetActive(true);
        }



    }
}
