using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour

{

    private Animator anim;
    private float cdTimer = Mathf.Infinity;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public GameObject fireBalls;
    private int attackLimitCounter;
    public sceneInfo sceneinfo;
    public GameObject meleeSize;

    //[Header("Targetable Enemy")]


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        meleeSize.transform.localScale = sceneinfo.scaleSize;
    }

    // Update is called once per frame
    void Update()
    {
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
        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, sceneinfo.attackRange, enemyLayers);
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, new Vector2(sceneinfo.boxWidth, sceneinfo.boxHeight), enemyLayers);

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
                } else if (enemy.CompareTag("Boss"))
                {
                    enemy.GetComponent<boss_health>().takeDamage(sceneinfo.atkDmg);
                }
            }

        }
    }

        private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackPoint.position, new Vector3(sceneinfo.boxWidth, sceneinfo.boxHeight, 0));

        //Gizmos.DrawWireSphere(attackPoint.position, sceneinfo.attackRange);
    }


}
