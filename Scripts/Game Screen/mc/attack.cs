using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour

{

    [SerializeField] private float atkCd;
    private Animator anim;
    private float cdTimer = Mathf.Infinity;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int character_dmg = 2;
    private health character_health;
    public GameObject fireBalls;

    //[Header("Targetable Enemy")]


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        character_health = GetComponent<health>();
    }

    // Update is called once per frame
    void Update()
    {
        cdTimer += Time.deltaTime;
        if (cdTimer > atkCd && character_health.currentHealth > 0)
        {
            Attack();
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
        fireBalls.transform.position = attackPoint.position;
        fireBalls.GetComponent<balls>().SetDirection(Mathf.Sign(transform.localScale.x));

        foreach (Collider2D enemy in hitEnemies)
        {
;            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<enemy1_health>().TakeDmg(character_dmg);
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
