using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExperienceManager : MonoBehaviour
{
    private int currentExperience;

    public static ExperienceManager Instance { get; set; }

    public event Action<int> OnExperienceChange;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("Another instance of ExperienceManager has been found", this);
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Pressing Button");
            AddExperience(20);
        }
#endif
    }

    public void AddExperience(int pXP)
    {
        Debug.Log("Adding XP");
        currentExperience += pXP;
        OnExperienceChange?.Invoke(currentExperience);
    }

    public void RemoveExperience(int pXP)
    {
        currentExperience -= pXP;
        OnExperienceChange?.Invoke(currentExperience);
    }

    public int GetExperience() => currentExperience;
}
