using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_health : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int dmgTaken)
    {
        currentHealth -= dmgTaken;

        if (currentHealth <= 0)
        {
            Boss_die();
        }
    }
    private void Boss_die()
    {
        Destroy(this.gameObject);
        GetComponent<Collider2D>().enabled = false;
    }
}
