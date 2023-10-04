using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    public int currentHealth;
    public healthbar healthBar;
    private Animator character_animation;
    public Canvas gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        /*
         * At the start of the script, set the max health into the current health
         * and call the SetmaxHealth method of the healthBar script
        */
        currentHealth = maxHealth;
        healthBar.SetmaxHealth(maxHealth);
        character_animation = GetComponent<Animator>();
        gameOverScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDmg(int dmg)
    {
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);
        character_animation.SetTrigger("hurt");

        if(currentHealth <= 0)
        {
            //character_animation.SetBool("die", true);
            this.enabled = false;
            gameOverScreen.enabled = true;
            Time.timeScale = 0;
        }
    }
}
