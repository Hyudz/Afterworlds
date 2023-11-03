using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forgeItems : MonoBehaviour
{
    public inventoryForge items;
    public inventoryDb inventoryHelper;
    public achieve achivementCheck;
    public Button red_forge;
    public Button yellow_forge;
    public Button blue_forge;
    public Button lightning_forge;
    public Button void_forge;
    public Button legend_forge;
   
    public void forgeRed()
    {
        if (items.orangeite_values >= 3)
        {
            //items.orangeite_values -= 3;
            //items.redSkin = true;
            inventoryHelper.updateOrangeite(items.orangeite_values -= 3);
            inventoryHelper.updateSkin1();
            achivementCheck.weaponCount();
        }
        
    }

    public void forgeYellow()
    {
        if (items.orangeite_values >= 3)
        {
            //items.orangeite_values -= 3;
            inventoryHelper.updateOrangeite(items.orangeite_values -= 3);
            inventoryHelper.updateSkin2();
            //items.yellowSkin = true;
            achivementCheck.weaponCount();
        }
        
    }

    public void forgeBlue()
    {
        if (items.orangeite_values >= 3)
        {
            //items.orangeite_values -= 3;
            //items.blueSkin = true;
            inventoryHelper.updateOrangeite(items.orangeite_values -= 3);
            inventoryHelper.updateSkin3();
            achivementCheck.weaponCount();
        }
        
    }

    public void forgeLightning()
    {
        if (items.orangeite_values >= 5 && items.blueite_values >= 5) //bluiete 5
        {
            //items.orangeite_values -= 1;
            //items.blueite_values -= 5;
            //items.thunderSkin = true;
            inventoryHelper.updateOrangeite(items.orangeite_values -= 5);
            inventoryHelper.updateBlueite(items.blueite_values -= 5);
            inventoryHelper.updateSkin4();
            achivementCheck.weaponCount();
        }
        
    }

    public void forgeVoid()
    {
        if (items.orangeite_values >= 5 && items.blueite_values >= 5) // blueite
        {
            //items.orangeite_values -= 2;
            //items.blueite_values -= 5;
            //items.voidSkin = true;
            inventoryHelper.updateOrangeite(items.orangeite_values -= 5);
            inventoryHelper.updateBlueite(items.blueite_values -= 5);
            inventoryHelper.updateSkin5();
            achivementCheck.weaponCount();
        }
        
    }

    public void forgeLegend()
    {
        if (items.orangeite_values >= 10 && items.greenite_values >= 2 && items.blueite_values >= 7)
        {
            //items.legendSkin = true;
            //items.orangeite_values -= 10;
            //items.blueite_values -= 7;
            //items.greenite_values -= 2;
            inventoryHelper.updateOrangeite(items.orangeite_values -= 10);
            inventoryHelper.updateBlueite(items.blueite_values -= 2);
            inventoryHelper.updateGreenite(items.greenite_values -= 7);
            inventoryHelper.updateSkin6();
            achivementCheck.weaponCount();
        }
    }

    public void Update()
    {
        if (items.redSkin == true)
        {
            red_forge.interactable = false;
        }

        if (items.blueSkin == true)
        {
            blue_forge.interactable = false;
        }

        if (items.yellowSkin == true)
        {
            yellow_forge.interactable = false;
        }

        if (items.thunderSkin == true)
        {
            lightning_forge.interactable = false;
        }

        if (items.voidSkin == true)
        {
            void_forge.interactable = false;
        }

        if (items.legendSkin == true)
        {
            legend_forge.interactable = false;
        }
    }
}
