using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class experience_manager : MonoBehaviour
{
    //reference of itself
    public static experience_manager Instance;

    public delegate void ExperienceChangeHandler(int amount);
    public event ExperienceChangeHandler OnExperienceChange;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddExperience(int amount)
    {
        OnExperienceChange?.Invoke(amount);
    }
}
