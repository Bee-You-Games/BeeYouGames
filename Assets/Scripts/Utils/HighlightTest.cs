using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightTest : MonoBehaviour
{
    [SerializeField]
    private float panTime = 4;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
            CameraManager.Instance.StartCoroutine(CameraManager.Instance.CameraPan(panTime, transform.position));
    }
}
