using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storeItems : MonoBehaviour
{

    public sceneInfo sceneinfo;
    public inventoryForge items;
    [Header("Boots Config")]
    public GameObject[] tiers;
    private int boots_tier = 0;
    public GameObject purchase_btn1;
    public GameObject upgrade_btn1;
    public GameObject max_btn1;
    public int purchaseCost1;
    public int upgradeCost1_tier2;
    public int upgradeCost1_tier3;
    public float movement_add;

    [Header("Armor Config")]
    public GameObject[] armor_tiers;
    private int armor_tier = 0;
    public GameObject purchase_btn2;
    public GameObject upgrade_btn2;
    public GameObject max_btn2;
    public int purchaseCost2;
    public int upgradeCost2_tier2;
    public int upgradeCost2_tier3;
    public int hp_add;

    [Header("Shield Config")]
    public GameObject[] shield_tiers;
    private int shield_tier = 0;
    public GameObject purchase_btn3;
    public GameObject upgrade_btn3;
    public GameObject max_btn3;
    public int purchaseCost3;
    public int upgradeCost3_tier2;
    public int upgradeCost3_tier3;
    public int negate_tier1;
    public int negate_tier2;
    public int negate_tier3;

    [Header("Materials Config")]
    public int orangeite_price;

    public void buyBoots()
    {

        if (sceneinfo.aftercoins >= purchaseCost1)
        {
            purchase_btn1.SetActive(false);
            upgrade_btn1.SetActive(true);
            sceneinfo.aftercoins -= purchaseCost1;

            sceneinfo.movementSpeed += movement_add;
            items.boots_tier += 1;
        } else
        {
            Debug.Log("Not enough aftercoins");
        }
    }

    public void upgradeBoots()
    {
        if(sceneinfo.aftercoins >= upgradeCost1_tier2 && items.boots_tier == 1)
        { 
            sceneinfo.aftercoins -= upgradeCost1_tier2;
            sceneinfo.movementSpeed += movement_add;
            items.boots_tier += 1;
        }
        else if (sceneinfo.aftercoins >= upgradeCost1_tier3 && items.boots_tier == 2)
        {

            upgrade_btn1.SetActive(false);
            max_btn1.SetActive(true);
            sceneinfo.aftercoins -= upgradeCost1_tier3;
            sceneinfo.movementSpeed += movement_add;
            items.boots_tier += 1;
        } else
        {
            Debug.Log("Cant upgrade");
        }
    }

    public void buyArmor()
    {
        purchase_btn2.SetActive(false);
        upgrade_btn2.SetActive(true);
        
        armor_tier += 1;
        sceneinfo.health += hp_add;
        items.armor_tier += 1;
        sceneinfo.aftercoins -= purchaseCost2;
    }

    public void upgradeArmor()
    {

         if (sceneinfo.aftercoins >= upgradeCost2_tier2 && items.armor_tier == 1)
        {
            items.armor_tier += 1;
            sceneinfo.health += hp_add;
            sceneinfo.aftercoins -= upgradeCost2_tier2;
        }
        else if (sceneinfo.aftercoins >= upgradeCost2_tier3 && items.armor_tier == 2)
        {
            items.armor_tier += 1;
            sceneinfo.health += hp_add;
            sceneinfo.aftercoins -= upgradeCost2_tier3;

            upgrade_btn2.SetActive(false);
            max_btn2.SetActive(true);
        }
       
    }
    public void buyShield()
    {
        purchase_btn3.SetActive(false);
        upgrade_btn3.SetActive(true);

        items.shield_tier += 1;
        sceneinfo.aftercoins -= purchaseCost3;
    }

    public void upgradeShield()
    {
       
       if (sceneinfo.aftercoins >= upgradeCost2_tier2 && items.shield_tier == 1)
        {
            items.shield_tier += 1;
            sceneinfo.aftercoins -= upgradeCost3_tier2;
        }
        else if (sceneinfo.aftercoins >= upgradeCost2_tier2 && items.shield_tier == 2)
        {
            items.shield_tier += 1;

            upgrade_btn3.SetActive(false);
            max_btn3.SetActive(true);
            sceneinfo.aftercoins -= upgradeCost3_tier3;
        }
    }

    public void buyItem()
    {
        if (sceneinfo.aftercoins >= orangeite_price)
        {
            items.orangeite_values += 1;
            sceneinfo.aftercoins -= orangeite_price;
        }
    }

    public void Update()
    {
        if (items.boots_tier != 0)
        {
            tiers[items.boots_tier -1].SetActive(false);
            tiers[items.boots_tier].SetActive(true);
        }

        if (items.armor_tier != 0)
        {
            armor_tiers[items.armor_tier - 1].SetActive(false);
            armor_tiers[items.armor_tier].SetActive(true);
        }

        if (items.shield_tier != 0)
        {
            shield_tiers[items.shield_tier -1].SetActive(false);
            shield_tiers[items.shield_tier].SetActive(true);
        }
    }
}
