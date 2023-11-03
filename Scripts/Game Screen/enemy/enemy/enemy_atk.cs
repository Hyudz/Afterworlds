using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_atk : MonoBehaviour
{
    [SerializeField] public float attackCooldown;
    [SerializeField] public int damage;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private LayerMask playerLayer;
    public Transform attackPoint;
    public float boxWidth;
    public float boxHeight;
    public achievement achivementCheck;

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


        Collider2D[] hitCharacter = Physics2D.OverlapBoxAll(attackPoint.position, new Vector2(boxWidth, boxHeight), playerLayer);

        foreach (Collider2D character in hitCharacter)
        {
            if (cooldownTimer >= attackCooldown) {
                if (character.CompareTag("Character"))
                {
                   cooldownTimer = 0.0f;
                   character.GetComponent<health>().TakeDmg(damage);
                   try
                    {
                        if (name == "Enemy_ratv1(Clone)" || name == "Enemy_ratv2(Clone)" || name == "Enemy_ratv3(Clone)")
                        {
                            achivementCheck.finalHit = "Rat";
                        } else
                        {
                            achivementCheck.finalHit = "";
                        }
                    } catch
                    {
                        //DO NOTHING
                    }
                }
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPoint.position, new Vector2(boxWidth, boxHeight));
        
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
