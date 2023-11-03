using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "items", menuName = "Persistence2")]
public class inventoryForge : ScriptableObject
{
    public int orangeite_values;
    public int blueite_values;
    public int greenite_values;
    public int boots_tier;
    public int armor_tier;
    public int shield_tier;
    public bool redSkin = false;
    public bool yellowSkin = false;
    public bool blueSkin = false;
    public bool thunderSkin = false;
    public bool voidSkin = false;
    public bool legendSkin = false;

    private void OnEnable()
    {
        orangeite_values = 0;
        blueite_values = 0;
        greenite_values = 0;
        boots_tier = 0;
        armor_tier = 0;
        shield_tier = 0;
        redSkin = false;
        yellowSkin = false;
        blueSkin = false;
        thunderSkin = false;
        voidSkin = false;
        legendSkin = false;
}
}
