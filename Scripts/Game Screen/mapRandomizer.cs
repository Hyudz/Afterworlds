using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapRandomizer : MonoBehaviour
{
    public GameObject posMap, negMap;
    void Start()
    {
        int random = Random.Range(0, 2);

        if (random == 0)
        {
            posMap.SetActive(true); 
            negMap.SetActive(false);
        }
        else
        {
            posMap.SetActive(false);
            negMap.SetActive(true);
        }
    }

   
}
