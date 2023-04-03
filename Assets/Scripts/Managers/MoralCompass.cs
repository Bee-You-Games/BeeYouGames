using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoralCompass : MonoBehaviour
{
    private float moralCompassValue = 0;

    public event Action<float> OnMoralCompassChange;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void EditMoralCompassValue(float pValue)
    {
        moralCompassValue += pValue;

        OnMoralCompassChange?.Invoke(moralCompassValue);
    }

    public float GetMoralCompassValue() => moralCompassValue;
}
