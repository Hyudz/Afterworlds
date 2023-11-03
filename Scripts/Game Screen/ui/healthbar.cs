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
    //public TextMeshProUGUI healthIndicator;
    public sceneInfo sceneinfo;

    private void Update()
    {
        //fill.color = gradient.Evaluate(1f);
        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetmaxHealth()
    {
        slider.maxValue = sceneinfo.maxHealth;
        //healthIndicator.SetText(sceneinfo.health + "/" + sceneinfo.maxHealth);
        slider.value = sceneinfo.health;
    }

    //this method updates the value of health slider
    public void SetHealth()
    {
        slider.value = sceneinfo.health;
        //healthIndicator.SetText(sceneinfo.health + "/" + sceneinfo.maxHealth);
    }
}
