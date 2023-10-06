using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth = 20;
    public healthbar healthBar;
    private Animator character_animation;
    public Canvas gameOverScreen;
    public expBar expbar;
    public int currentExperience = 0;
    public int maxExperience = 100;
    public int currentLevel = 1;
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

    private void OnEnable()
    {
        experience_manager.Instance.OnExperienceChange += HandleExperienceChange;
    }

    private void OnDisable()
    {
        experience_manager.Instance.OnExperienceChange -= HandleExperienceChange;
    }

    private void HandleExperienceChange(int newExperience)
    {
        currentExperience += newExperience;
        expbar.SetExp(currentExperience);
        if(currentExperience >= maxExperience)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        maxHealth += 10;
        currentHealth = maxHealth;
        currentExperience = 0;
        maxExperience += 50;
    }
}
