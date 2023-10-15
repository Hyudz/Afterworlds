using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour

{

    private Animator anim;
    private float cdTimer = Mathf.Infinity;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public GameObject fireBalls;
    private int attackLimitCounter;
    public sceneInfo sceneinfo;

    //[Header("Targetable Enemy")]


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        sceneinfo.attackRange = attackRange;
        cdTimer += Time.deltaTime;
 
        if (cdTimer > sceneinfo.attackCd && sceneinfo.health > 0)
        {
            Attack();
            attackLimitCounter = 0;
        }
    }

    private void Attack()
    {
        //anim.SetTrigger("attack_melee");
        cdTimer = 0;

        /*Arguments: 
         * attackPoint - center point
         * attackRange - the radius
         * enemyLayers - filter certain layers
        */
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //RANGED ATK
        //fireBalls.transform.position = attackPoint.position;
        //fireBalls.GetComponent<balls>().SetDirection(Mathf.Sign(transform.localScale.x));

        foreach (Collider2D enemy in hitEnemies)
        {
            if (attackLimitCounter <= sceneinfo.atkLimit)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    enemy.GetComponent<enemy_health>().TakeDmg(sceneinfo.atkDmg);
                    attackLimitCounter += 1;
                }
            }

        }
    }

        private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
