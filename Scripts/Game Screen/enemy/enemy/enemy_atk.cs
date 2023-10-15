using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_atk : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    //[SerializeField] private float range;
    [SerializeField] private int damage;
    //[SerializeField] private float colliderDistance;
    private float cooldownTimer = Mathf.Infinity;
    //[SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    public float attackRange;
    public Transform attackPoint;

    private Animator enemy_animation;
    private health character_health;

    private void Start()
    {
        character_health = GetComponent<health>();
        //enemy_animation = GetComponent<Animator>();
    }
    // Update is called once per frame
    public void Update()
    {
        cooldownTimer += Time.deltaTime;

        /*if (PlayerInSight())
        {
            Debug.Log("this is working");
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                //enemy_animation.SetTrigger("attack");
                character_health.GetComponent<health>().TakeDmg(damage);
            }
        } */

        Collider2D[] hitCharacter = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D character in hitCharacter)
        {
            if (cooldownTimer >= attackCooldown) {
                if (character.CompareTag("Character"))
                {
                   cooldownTimer = 0.0f;
                   character.GetComponent<health>().TakeDmg(damage);
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

    /*private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        
        if (hit.collider != null)
        {
            character_health = hit.transform.GetComponent<health>();
        }
        Debug.Log(hit.collider);

        return hit.collider != null;
          
    } 

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }  */

}
