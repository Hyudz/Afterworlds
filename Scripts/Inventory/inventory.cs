using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public inventoryForge items;
    public sceneInfo sceneInfo;
    [Header("Items Config")]
    public GameObject[] boots_tiers;
    public GameObject[] armor_tier;
    public GameObject[] shield_tier;

    [Header("Materials Config")]
    public TextMeshProUGUI orangeite_items;
    public TextMeshProUGUI blueite_items;
    public TextMeshProUGUI greenite_items;

    [Header("Skins Config")]
    public Button[] skinButtons;

    //[Header("Skin Config")]

    private void Update()
    {

        if (items.boots_tier != 0)
        {
            boots_tiers[items.boots_tier - 1].SetActive(false);
            boots_tiers[items.boots_tier].SetActive(true);
        }

        if (items.armor_tier != 0)
        {
            armor_tier[items.armor_tier - 1].SetActive(false);
            armor_tier[items.armor_tier].SetActive(true);
        }

        if (items.shield_tier != 0)
        {
            shield_tier[items.shield_tier - 1].SetActive(false);
            shield_tier[items.shield_tier].SetActive(true);
        }

        if (items.redSkin == true)
        {
            skinButtons[0].interactable = true;
        } 
        
        if (items.yellowSkin == true)
        {
            skinButtons[1].interactable = true;
        } 
        
        if (items.blueSkin == true)
        {
            skinButtons[2].interactable = true;
        } 
        
        if (items.thunderSkin == true)
        {
            skinButtons[3].interactable = true;
        } 
        
        if (items.voidSkin == true)
        {
            skinButtons[4].interactable = true;
        }

        if (items.legendSkin == true)
        {
            skinButtons[5].interactable = true;
        }


        orangeite_items.SetText("x"+items.orangeite_values);
        blueite_items.SetText("x" + items.blueite_values);
        greenite_items.SetText("x"+items.greenite_values);
    }


    public void equipSkin1()
    {
        Debug.Log("Red");
        sceneInfo.currentSkin = "Common Skin 1";
    }
    public void equipSkin2()
    {
        Debug.Log("Blue");
        sceneInfo.currentSkin = "Common Skin 2";
    }
    public void equipSkin3()
    {
        Debug.Log("Green");
        sceneInfo.currentSkin = "Common Skin 3";
    }

    public void equipSkin4()
    {
        Debug.Log("Yellow");
        sceneInfo.currentSkin = "Epic Skin 1";
    }

    public void equipSkin5()
    {
        Debug.Log("Orange");
        sceneInfo.currentSkin = "Epic Skin 2";
    }

    public void equipSkin6()
    {
        sceneInfo.currentSkin = "Legendary Skin";
    }

}
