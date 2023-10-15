using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Levelup_system : MonoBehaviour
{
    [Header("Upgraded Stats")]
    [SerializeField] public float movementSpeed;
    [SerializeField] public float attackSpeed;
    [SerializeField] public int hp;
    [SerializeField] public int damage;
    [SerializeField] public int limit;

    [Header("Stats References")]
    public health player_health;
    public Canvas levelupSystem;
    public melee meleeAnim;
    public sceneInfo sceneinfo;

    [Header("UI References")]
    public Canvas UI;
    public Canvas game_Timer;
    public Canvas characterStats;

    [Header("Text References")]
    public TextMeshProUGUI buff1_text;
    public TextMeshProUGUI buff2_text;
    public TextMeshProUGUI buff3_text;

    List<string> buffList = new List<string>();

    public void Start()
    {
        enabled = false;
        buffList.Add("Movement Speed");
        buffList.Add("HP increase");
        buffList.Add("HP restoration");
        buffList.Add("Additional Damage");
        buffList.Add("Attack Speed");
        buffList.Add("Increase cleaving range");
    }


    // Start is called before the first frame update
    public void addMovementSpeed()
    {
        sceneinfo.movementSpeed += movementSpeed;
        show();
    }   
    public void addHp()
    {
        player_health.addHealth(hp);
        show();
    }
    public void restoreHp()
    {
        player_health.restoreHealth();
        show();
    }

    public void addDamage()
    {
        sceneinfo.atkDmg += damage;
        show();
    }

    public void reduceCd()
    {
        sceneinfo.attackCd -= attackSpeed;
        meleeAnim.animCd -= attackSpeed;
        show();
    }

    public void addLimit()
    {
        sceneinfo.atkLimit += limit;
        show();
    }

    public void show()
    {
        UI.enabled = true;
        game_Timer.enabled = true;
        characterStats.enabled = true;

        Time.timeScale = 1.0f;
        levelupSystem.enabled = false;
    }

    public void hide()
    {
        UI.enabled = false;
        game_Timer.enabled = false;
        characterStats.enabled = false; 
    }


}
