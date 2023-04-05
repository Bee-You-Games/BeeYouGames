using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }
    List<int> progressedIDs = new List<int>();

    private void Awake()
	{
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("Multiple instances of EventManager have been found", this);
    }

    public event Action<int> ProgressionEvent;
    public void TriggerProgression(int pID)
    {
        if (ProgressionEvent != null)
        {
            ProgressionEvent(pID);
        }
        if (!progressedIDs.Contains(pID))
        {
            progressedIDs.Add(pID);
        }
    }

    public bool ProgressionCheck(int pID)
    {
        if (progressedIDs.Contains(pID))
            return true;
        else
            return false;
    }
}
