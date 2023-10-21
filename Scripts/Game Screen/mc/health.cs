using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public healthbar healthBar;

    private Animator character_animation;

    public Canvas gameOverScreen;
    public Canvas levelUpScreen;
    public Levelup_system levelup;
    public gameOverScreen gameOver;

    public expBar expbar;
    public int currentLevel = 1;

    public sceneInfo sceneinfo;
    // Start is called before the first frame update
    void Start()
    {
        /*
         * At the start of the script, set the max health into the current health
         * and call the SetmaxHealth method of the healthBar script
        */
        //currentHealth = maxHealth;
        //sceneinfo.health = currentHealth;
        healthBar.SetmaxHealth();
        expbar.SetExp();
        character_animation = GetComponent<Animator>();
        gameOverScreen.enabled = false;
        levelUpScreen.enabled = false;
    }

    public void TakeDmg(int dmg)
    {
        //currentHealth -= dmg;
        sceneinfo.health -= dmg;
        healthBar.SetHealth();
        character_animation.SetTrigger("hurt");

        if(sceneinfo.health <= 0)
        {
            //character_animation.SetBool("die", true);
            Destroy(this.gameObject);
            gameOverScreen.enabled = true;
            gameOver.gameIsOver = true;
            gameOver.Hide();
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
        sceneinfo.currentExp += newExperience;
        expbar.SetExp();
        if(sceneinfo.currentExp >= sceneinfo.maxExp)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        currentLevel += 1;
        sceneinfo.currentExp = 0;
        sceneinfo.maxExp += 30;

        expbar.SetExp();
        expbar.SetmaxExp();

        levelup.choose();
        levelUpScreen.enabled = true;
        levelup.hide();
        Time.timeScale = 0;
    }

    public void addHealth(int addedHealth)
    {
        sceneinfo.health += addedHealth;
        sceneinfo.maxHealth += addedHealth;
        healthBar.SetHealth();
    }

    public void restoreHealth()
    {
        sceneinfo.health = sceneinfo.maxHealth;
        healthBar.SetHealth();
        healthBar.SetmaxHealth();
    }
}
