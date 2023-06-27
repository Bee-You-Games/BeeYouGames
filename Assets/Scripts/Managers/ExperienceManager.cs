using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ExperienceManager : MonoBehaviour
{
    [SerializeField]
    private int maxValue = 100;

    public int MaxValue
    {
        get { return maxValue; }
        private set { maxValue = value; }
    }

    private int currentExperience;

    public static ExperienceManager Instance { get; private set; }

    public event Action<int> OnExperienceChange;

    private List<string> rewardedText;

    private void Awake()
    {
        rewardedText = new List<string>();
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("Another instance of ExperienceManager has been found", this);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(StringUtils.GetCurrentLevel()))
        {
            currentExperience = PlayerPrefs.GetInt(StringUtils.GetCurrentLevel());
            OnExperienceChange?.Invoke(currentExperience);
        }
        else
            PlayerPrefs.SetInt(StringUtils.GetCurrentLevel(), currentExperience);
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

        PlayerPrefs.SetInt(StringUtils.GetCurrentLevel(), currentExperience);

        OnExperienceChange?.Invoke(currentExperience);
    }

    public void AddDialogueExperience(int pXP, string rewardText = null)
    {
        if (rewardText != null && rewardedText.Contains(rewardText))
            return;
        Debug.Log("Adding XP");
        currentExperience += pXP;

        PlayerPrefs.SetInt(GetCurrentLevel(), currentExperience);

        OnExperienceChange?.Invoke(currentExperience);

        if (rewardText != null)
            rewardedText.Add(rewardText);
    }

    public void RemoveExperience(int pXP)
    {
        currentExperience -= pXP;
        PlayerPrefs.SetInt(StringUtils.GetCurrentLevel(), currentExperience);
        OnExperienceChange?.Invoke(currentExperience);
    }

    public int GetExperience() => currentExperience;
}
