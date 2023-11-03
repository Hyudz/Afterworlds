using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_health : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    public achievement achievementCheck;
    private int currentHealth;
    public Canvas winner;
    public youwon win;
    public sceneInfo sceneinfo;
    public achievementDb dbHelper;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int dmgTaken)
    {
        currentHealth -= dmgTaken;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Boss_die();
        }
    }
    public void Boss_die()
    {
        Destroy(this.gameObject);
        dbHelper.updateAchievement6();
        achievementCheck.finished += 1;
        dbHelper.updateFinishCount(achievementCheck.finished);
        sceneinfo.currentGreenite += 1;

        GetComponent<Collider2D>().enabled = false;
        winner.enabled = true;
        win.hide();
    }
}
