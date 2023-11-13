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
    public sceneInfo sceneinfo;
    public int shieldd;
    public float schieldCd = 30.0f;
    public bool inCooldown;
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
        if (inCooldown == false)
        {
            if (items.shield_tier == 1)
            {
                dmg -= 1;
                inCooldown = true;
            } else if (items.shield_tier == 2)
            {
                dmg -= 1;
                shieldd += 1;
                if (shieldd >= 2) {
                    shieldd = 0;
                    inCooldown = true;
                }
            } else if (items.shield_tier == 3)
            {
                dmg -= 1;
                shieldd += 1;
                if (shieldd >= 4)
                {
                    shieldd = 0;
                    inCooldown = true;
                }
            }
        }
        
        sceneinfo.health -= dmg;
        healthBar.SetHealth();
        if (shieldd <= 0)
        {
            character_animation.SetTrigger("hurt");
        }
       
        if (sceneinfo.health <= 0)
        {
            Destroy(gameObject);
            isDead = true;
            gameOverScreen.enabled = true;
            gameOver.gameIsOver = true;
            gameOver.Hide();
        }



    }

    public void Update()
    {
        
        if (inCooldown == true)
        {
            schieldCd -= Time.deltaTime;

            if (schieldCd <= 0)
            {
                inCooldown = false;
                schieldCd = 30.0f;
            }
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
