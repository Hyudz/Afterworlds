using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class expBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public TextMeshProUGUI expIndicator;
    public sceneInfo sceneinfo;

    public void SetmaxExp()
    {
        expIndicator.SetText(sceneinfo.currentExp + "/" + sceneinfo.maxExp);
        slider.maxValue = sceneinfo.maxExp;
    }

    //this method updates the value of health slider
    public void SetExp()
    {
        slider.value = sceneinfo.currentExp;
        expIndicator.SetText(sceneinfo.currentExp + "/" + sceneinfo.maxExp);
    }

}
