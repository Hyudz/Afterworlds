using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour

{

    [SerializeField] private float atkCd;
    private Animator anim;
    private float cdTimer = Mathf.Infinity;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cdTimer += Time.deltaTime;
        if (cdTimer > atkCd)
        {
            Attack();
        }
    }

    private void Attack()
    {
        anim.SetTrigger("attack_melee");
        cdTimer = 0;
    }

   
}
