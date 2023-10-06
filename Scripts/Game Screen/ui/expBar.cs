using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class expBar : MonoBehaviour
{

    public Slider slider;
    public Image fill;

    public void SetmaxExp()
    { 
        slider.maxValue = 100;
    }

    //this method updates the value of health slider
    public void SetExp(int exp)
    {
        slider.value = exp;
    }
}
