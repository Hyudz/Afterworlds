using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_health : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    public int currentHealth;
    private Animator enemy_animation;
    [SerializeField] public int addedExp;
    public sceneInfo sceneinfo;
    [SerializeField] public int addedAftercoins;

    private void Start()
    {
        //Set the current health to max health at the start
        currentHealth = maxHealth;
        enemy_animation = GetComponent<Animator>();
    }

    //the one who calls this method is at the attack class to tell the program that the enemy takes a damage
    public void TakeDmg(int dmg)
    {
        currentHealth -= dmg;
        enemy_animation.SetTrigger("hurt");

        if(currentHealth <=0) {
            Die();
        }
    }

    public void Die()
    {
        sceneinfo.current_aftercoins += addedAftercoins;
        enemy_animation.SetBool("isDead", true);
        new WaitForSeconds(2);
        Destroy(this.gameObject);
        GetComponent<Collider2D>().enabled = false;
        experience_manager.Instance.AddExperience(addedExp);

        this.enabled = false;
    }
}
