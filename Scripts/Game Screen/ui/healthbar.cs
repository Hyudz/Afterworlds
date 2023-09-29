using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Update()
    {
        fill.color = gradient.Evaluate(1f);
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetmaxHealth(int health)
    {
        //Set the max value of the health slider
        slider.maxValue = health;

        slider.value = health;
        //fill.color = gradient.Evaluate(1f);
        Debug.Log(gradient.Evaluate(1f));
    }

    //this method updates the value of health slider
    public void SetHealth(int health)
    {
        //Sets the value of the slider with the health value
        slider.value = health;
        
    }
}
