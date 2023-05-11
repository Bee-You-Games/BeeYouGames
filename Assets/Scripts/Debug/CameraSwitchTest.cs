using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchTest : MonoBehaviour
{
    [SerializeField]
    private float panTime = 4;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            StartCoroutine(CameraPan());
    }

    public IEnumerator CameraPan()
    {
        CameraManager.Instance.PanToPoint(transform.position);

        yield return new WaitForSeconds(panTime);

        CameraManager.Instance.CancelPan();
    }
}
