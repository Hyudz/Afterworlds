using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdownBar : MonoBehaviour
{

    public Slider cdSlider;
    public Image fill;

    public void value(int newValue)
    {
        cdSlider.value = newValue;
        
    }
}
