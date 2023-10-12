using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1_health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public int currentHealth;
    private Animator enemy1_animation;
    [SerializeField] public int addedExp;

    private void Start()
    {
        //Set the current health to max health at the start
        currentHealth = maxHealth;
        enemy1_animation = GetComponent<Animator>();
    }

    //the one who calls this method is at the attack class to tell the program that the enemy takes a damage
    public void TakeDmg(int dmg)
    {
        currentHealth -= dmg;
        enemy1_animation.SetTrigger("hurt");

        if(currentHealth <=0) {
            Die();
        }
    }

    public void Die()
    {
        enemy1_animation.SetBool("isAlive", false);
        new WaitForSeconds(2);
        Destroy(this.gameObject);
        GetComponent<Collider2D>().enabled = false;
        experience_manager.Instance.AddExperience(addedExp);

        this.enabled = false;
    }
}
