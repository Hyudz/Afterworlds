using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class store : MonoBehaviour
{
    public TextMeshProUGUI currentAftercoins;
    public sceneInfo sceneinfo;
    public inventoryDb inventoryHelper;

    // Update is called once per frame
    void Update()
    {
        inventoryHelper.readCoins();
        currentAftercoins.SetText(sceneinfo.aftercoins.ToString());
    }
}
