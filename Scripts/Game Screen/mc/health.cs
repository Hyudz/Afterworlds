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
    public bool isDead = false;
    public gameOverScreen gameOver;
    public inventoryForge items;
    public expBar expbar;
    public int currentLevel = 1;
    private float cd = 30.0f;
    private bool in30Secs = false;
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

    private void Update()
    {
        
        if (sceneinfo.shield <= 0 && items.shield_tier != 0)
        {
            cd += Time.deltaTime;
        } else if (cd >= 30 && in30Secs == false)
        {
            if (items.shield_tier == 1)
            {
                sceneinfo.shield += 1;
            } else if (items.shield_tier == 2)
            {
                sceneinfo.shield += 2;
            } else if (items.shield_tier == 3)
            {
                sceneinfo.shield += 4;
            }
            in30Secs = true;
        }
    }

    public void TakeDmg(int dmg)
    {
        if (sceneinfo.shield == 0)
        {
            //currentHealth -= dmg;
            sceneinfo.health -= dmg;
            healthBar.SetHealth();
            character_animation.SetTrigger("hurt");

            if (sceneinfo.health <= 0)
            {
                //character_animation.SetBool("die", true);
                Destroy(this.gameObject);
                isDead = true;
                gameOverScreen.enabled = true;
                gameOver.gameIsOver = true;
                gameOver.Hide();
            }
        } else if (sceneinfo.shield <= 0 && cd >= 30)
        {
            sceneinfo.shield -= dmg;
            cd = 0;
            in30Secs = true;
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
