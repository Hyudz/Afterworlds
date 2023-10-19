using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class store : MonoBehaviour
{
    public TextMeshProUGUI currentAftercoins;
    public sceneInfo sceneinfo;

    // Update is called once per frame
    void Update()
    {
        currentAftercoins.SetText(sceneinfo.aftercoins.ToString());
    }
}
