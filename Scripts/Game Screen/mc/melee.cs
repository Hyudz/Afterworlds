using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{
    public float currentCd = 0.0f;
    public float animCd = 1.0f;
    public Animator meleeAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentCd += Time.deltaTime;
        if (currentCd >= animCd)
        {
            meleeAnimation.SetTrigger("attack_melee");
            currentCd = 0.0f;
        }
        
    }
}
