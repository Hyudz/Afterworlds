using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class experienceManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ExpText;
    //[SerializeField] private int Level;
    public float currentExp;
    [SerializeField] private float targetExp;
    [SerializeField] public Slider progressBar;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExpController()
    {
        progressBar.value = currentExp;
        if(currentExp >= targetExp)
        {
            currentExp = 0;
            targetExp += 100;
        }
    }
}
