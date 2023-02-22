using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildNumber : MonoBehaviour
{
    private TextMeshProUGUI buildVersionText;

    private void Start()
    {
        buildVersionText = GetComponent<TextMeshProUGUI>();

        if (buildVersionText != null)
            buildVersionText.text = $"v{Application.version}";
        else
            Debug.LogError("Variable buildVersionText is NULL", this);
    }
}
