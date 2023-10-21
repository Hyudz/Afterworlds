using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forgeItems : MonoBehaviour
{
    public inventoryForge items;
    public Button red_forge;
    public Button yellow_forge;
    public Button blue_forge;
    public Button lightning_forge;
    public Button void_forge;
   
    public void forgeRed()
    {
        if (items.orangeite_values >= 3)
        {
            red_forge.interactable = false;
            items.orangeite_values -= 3;
            items.redSkin = true;
        }
        
    }

    public void forgeYellow()
    {
        if (items.orangeite_values >= 3)
        {
            yellow_forge.interactable = false;
            items.orangeite_values -= 3;
            items.yellowSkin = true;
        }
        
    }

    public void forgeBlue()
    {
        if (items.orangeite_values >= 3)
        {
            blue_forge.interactable = false;
            items.orangeite_values -= 3;
            items.blueSkin = true;
        }
        
    }

    public void forgeLightning()
    {
        if (items.orangeite_values >= 1 && items.greenite_values >= 4)
        {
            lightning_forge.interactable = false;
            items.orangeite_values -= 1;
            items.greenite_values -= 4;
            items.thunderSkin = true;
        }
        
    }

    public void forgeVoid()
    {
        if (items.orangeite_values >= 2 && items.greenite_values > 4)
        {
            void_forge.interactable = false;
            items.orangeite_values -= 2;
            items.greenite_values -= 4;
            items.voidSkin = true;
        }
        
    }
}
