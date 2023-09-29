using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1_health : MonoBehaviour
{
    int maxHealth = 10;
    int currentHealth;
    public Animator enemy1_animation;

    private void Start()
    {
        currentHealth = maxHealth;
        enemy1_animation = GetComponent<Animator>();
    }

    public void TakeDmg(int dmg)
    {
        currentHealth -= dmg;
        //enemy1_animation.SetTrigger("hurt");

        if(currentHealth <=0) {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy dies");
        enemy1_animation.SetTrigger("die");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
