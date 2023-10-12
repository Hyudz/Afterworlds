using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class healthbar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TextMeshProUGUI healthIndicator;

    private void Update()
    {
        //fill.color = gradient.Evaluate(1f);
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetmaxHealth(int health)
    {
        healthIndicator.SetText(health.ToString() + "/" + health.ToString());
        slider.maxValue = health;
        slider.value = health;
    }

    //this method updates the value of health slider
    public void SetHealth(int health)
    {
        slider.value = health;
        healthIndicator.SetText(health.ToString() + "/" + slider.maxValue.ToString());
    }
}
