using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1_health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;
    private enemy1 enemy;

    private void Start()
    {
        currentHealth = maxHealth;
        enemy = GetComponent<enemy1>();
        //enemy1_animation = GetComponent<Animator>();
    }

    public void TakeDmg(int dmg)
    {
        currentHealth -= dmg;
        //enemy1_animation.SetTrigger("hurt");

        if(currentHealth <=0) {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
        Debug.Log("Enemy " + this.name +" dies");
        //enemy1_animation.SetTrigger("die");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        //DestroyImmediate(gameObject, true);
    }
}
