using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistence")]
public class sceneInfo : ScriptableObject
{
    public float movementSpeed;
    public int health;
    public int maxHealth;
    public float attackCd;
    public float attackRange;
    public int currentExp;
    public int maxExp;
    public int atkDmg;
    public int atkLimit;
    public int aftercoins;
    public int current_aftercoins;
    public float boxWidth;
    public float boxHeight;

    private void OnEnable()
    {
        health = 20;
        maxHealth = 20;
        atkDmg = 3;
        attackCd = 1;
        movementSpeed = 200.0f;
        attackRange = 26.2f;
        maxExp = 50;
        currentExp = 0;
        atkLimit = 5;
        aftercoins = 0;
        boxWidth = 47.8f;
        boxHeight = 57.4f;
        current_aftercoins = 0;
        aftercoins = 0;
}

    public void retry()
    {
        current_aftercoins = 0;
        health = 20;
        maxHealth = 20;
        atkDmg = 3;
        attackCd = 1;
        movementSpeed = 200.0f;
        attackRange = 26.2f;
        maxExp = 50;
        currentExp = 0;
        atkLimit = 5;
        boxWidth = 47.8f;
        boxHeight = 57.4f;
        current_aftercoins = 0;
    }
}
