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

    public void SetmaxExp()
    { 
        slider.maxValue = 100;
    }

    //this method updates the value of health slider
    public void SetExp(int exp)
    {
        slider.value = exp;
        expIndicator.SetText(exp.ToString() + "/" + slider.maxValue.ToString());
    }
}
