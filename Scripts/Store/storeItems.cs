using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class storeItems : MonoBehaviour
{

    public sceneInfo sceneinfo;
    public inventoryForge items;
    public inventoryDb inventoryHelper;
    public GameObject[] store_items;

    [Header("Boots Config")]
    public GameObject[] tiers;
    public GameObject purchase_btn1;
    public GameObject upgrade_btn1;
    public GameObject max_btn1;
    public int purchaseCost1;
    public int upgradeCost1_tier2;
    public int upgradeCost1_tier3;
    public float movement_add;
    public TextMeshProUGUI bootsPrice;

    [Header("Armor Config")]
    public GameObject[] armor_tiers;
    public GameObject purchase_btn2;
    public GameObject upgrade_btn2;
    public GameObject max_btn2;
    public int purchaseCost2;
    public int upgradeCost2_tier2;
    public int upgradeCost2_tier3;
    public int hp_add;
    public TextMeshProUGUI armorPrice;

    [Header("Shield Config")]
    public GameObject[] shield_tiers;
    public GameObject purchase_btn3;
    public GameObject upgrade_btn3;
    public GameObject max_btn3;
    public int purchaseCost3;
    public int upgradeCost3_tier2;
    public int upgradeCost3_tier3;
    public int negate_tier1;
    public int negate_tier2;
    public int negate_tier3;
    public TextMeshProUGUI shieldPrice;

    [Header("Materials Config")]
    public int orangeite_price;

    private void Start()
    {
        if (items.boots_tier == 0)
        {
            bootsPrice.SetText(purchaseCost1.ToString());
        } else if (items.boots_tier == 1)
        {
            bootsPrice.SetText(upgradeCost1_tier2.ToString());
        }
        else if (items.boots_tier == 2)
        {
            bootsPrice.SetText(upgradeCost1_tier3.ToString());
        } else
        {
            store_items[0].SetActive(false);
        }

        if (items.armor_tier == 0)
        {
            armorPrice.SetText(purchaseCost2.ToString());
        }
        else if (items.armor_tier == 1)
        {
            armorPrice.SetText(upgradeCost2_tier2.ToString());
        }
        else if (items.armor_tier == 2)
        {
            armorPrice.SetText(upgradeCost2_tier3.ToString());
        }
        else
        {
            store_items[1].SetActive(false);
        }

        if (items.shield_tier == 0)
        {
            shieldPrice.SetText(purchaseCost3.ToString());
        }
        else if (items.shield_tier == 1)
        {
            shieldPrice.SetText(upgradeCost3_tier2.ToString());
        }
        else if (items.shield_tier == 2)
        {
            shieldPrice.SetText(upgradeCost3_tier3.ToString());
        }
        else
        {
            store_items[2].SetActive(false);
        }
    }

    public void buyBoots()
    {

        if (sceneinfo.aftercoins >= purchaseCost1)
        {
            sceneinfo.aftercoins -= purchaseCost1;
            inventoryHelper.updateCoins(sceneinfo.aftercoins);
            //sceneinfo.movementSpeed += movement_add;
            //items.boots_tier += 1;
            inventoryHelper.updateBootsTier(1);
            bootsPrice.SetText(upgradeCost1_tier2.ToString());
        }
    }

    public void upgradeBoots()
    {
        if(sceneinfo.aftercoins >= upgradeCost1_tier2 && items.boots_tier == 1)
        {
            bootsPrice.SetText(upgradeCost1_tier3.ToString());
            sceneinfo.aftercoins -= upgradeCost1_tier2;
            inventoryHelper.updateCoins(sceneinfo.aftercoins);
            //sceneinfo.movementSpeed += movement_add;
            inventoryHelper.updateBootsTier(2);
            //items.boots_tier += 1;
        }
        else if (sceneinfo.aftercoins >= upgradeCost1_tier3 && items.boots_tier == 2)
        {
            sceneinfo.aftercoins -= upgradeCost1_tier3;
            inventoryHelper.updateCoins(sceneinfo.aftercoins);
            //sceneinfo.movementSpeed += movement_add;
            //items.boots_tier += 1;
            inventoryHelper.updateBootsTier(3);
            store_items[0].SetActive(false);
        }
    }

    public void buyArmor()
    {

        if (sceneinfo.aftercoins >= purchaseCost2)
        {
            armorPrice.SetText(upgradeCost1_tier2.ToString());
            //sceneinfo.health += hp_add;
            //items.armor_tier += 1;
            inventoryHelper.updateArmorTier(1);
            sceneinfo.aftercoins -= purchaseCost2;
        }
    
    }

    public void upgradeArmor()
    {
        
         if (sceneinfo.aftercoins >= upgradeCost2_tier2 && items.armor_tier == 1)
        {
            armorPrice.SetText(upgradeCost1_tier3.ToString());
            //items.armor_tier += 1;
            //sceneinfo.health += hp_add;
            inventoryHelper.updateArmorTier(2);
            sceneinfo.aftercoins -= upgradeCost2_tier2;
            inventoryHelper.updateCoins(sceneinfo.aftercoins);
        }
        else if (sceneinfo.aftercoins >= upgradeCost2_tier3 && items.armor_tier == 2)
        {
            //items.armor_tier += 1;
            sceneinfo.health += hp_add;
            sceneinfo.aftercoins -= upgradeCost2_tier3;
            inventoryHelper.updateArmorTier(3);
            inventoryHelper.updateCoins(sceneinfo.aftercoins);
            store_items[1].SetActive(false);
        }
        Debug.Log(items.armor_tier == 3);
       
         
       
    }
    public void buyShield()
    {

        if (sceneinfo.aftercoins >= purchaseCost3)
        {
            shieldPrice.SetText(upgradeCost3_tier2.ToString());
            //items.shield_tier += 1;
            sceneinfo.aftercoins -= purchaseCost3;
            inventoryHelper.updateCoins(sceneinfo.aftercoins);
            inventoryHelper.updateShieldTier(1);
        }
    }

    public void upgradeShield()
    {
       
       if (sceneinfo.aftercoins >= upgradeCost2_tier2 && items.shield_tier == 1)
        {
            shieldPrice.SetText(upgradeCost3_tier3.ToString());
            //items.shield_tier += 1;
            sceneinfo.aftercoins -= upgradeCost3_tier2;
            inventoryHelper.updateCoins(sceneinfo.aftercoins);
            inventoryHelper.updateShieldTier(2);
        }
        else if (sceneinfo.aftercoins >= upgradeCost2_tier2 && items.shield_tier == 2)
        {
            //items.shield_tier += 1;
            sceneinfo.aftercoins -= upgradeCost3_tier3;
            inventoryHelper.updateCoins(sceneinfo.aftercoins);
            inventoryHelper.updateShieldTier(3);
            store_items[2].SetActive(false);
        }
    }

    public void buyItem()
    {
        if (sceneinfo.aftercoins >= orangeite_price)
        {
            //items.orangeite_values += 1;
            inventoryHelper.updateOrangeite(items.orangeite_values += 1);
            sceneinfo.aftercoins -= orangeite_price;
            inventoryHelper.updateCoins(sceneinfo.aftercoins);
        }
    }

    public void Update()
    {
        //BOOTS TIER ---------------------------------------------------------------------

        if (items.boots_tier != 0)
        {
            tiers[items.boots_tier -1].SetActive(false);
            tiers[items.boots_tier].SetActive(true);
        }

        if(items.boots_tier == 0)
        {
            purchase_btn1.SetActive(true);
        }
        else if (items.boots_tier == 1 || items.boots_tier == 2)
        {
            purchase_btn1.SetActive(false);
            upgrade_btn1.SetActive(true);
        }
        else if (items.boots_tier == 3)
        {

            purchase_btn1.SetActive(false);
            upgrade_btn1.SetActive(false);
            max_btn1.SetActive(true);
        }

        //ARMOR TIER ---------------------------------------------------------------------

        if (items.armor_tier != 0)
        {
            armor_tiers[items.armor_tier - 1].SetActive(false);
            armor_tiers[items.armor_tier].SetActive(true);
        }

        if (items.armor_tier == 0)
        {
            purchase_btn2.SetActive(true);
        }
        else if (items.armor_tier == 1 || items.armor_tier == 2)
        {
            purchase_btn2.SetActive(false);
            upgrade_btn2.SetActive(true);
        } else if (items.armor_tier == 3)
        {
            
            purchase_btn2.SetActive(false);
            upgrade_btn2.SetActive(false);
            max_btn2.SetActive(true);
        }

        //SHIELD TIER ---------------------------------------------------------------------

        if (items.shield_tier != 0)
        {
            shield_tiers[items.shield_tier -1].SetActive(false);
            shield_tiers[items.shield_tier].SetActive(true);
        }

        if(items.shield_tier == 0)
        {
            purchase_btn3.SetActive(true);
        }
        else if (items.shield_tier == 1 || items.shield_tier == 2)
        {
            purchase_btn3.SetActive(false);
            upgrade_btn3.SetActive(true);
        }
        else if (items.shield_tier == 3)
        {

            purchase_btn3.SetActive(false);
            upgrade_btn3.SetActive(false);
            max_btn3.SetActive(true);
        }
    }
}
