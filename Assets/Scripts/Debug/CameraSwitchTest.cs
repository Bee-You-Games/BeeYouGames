using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchTest : MonoBehaviour
{
    [SerializeField]
    private float panFrames = 120;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            StartCoroutine(CameraManager.Instance.PanToPoint(transform.position, panFrames));
    }


    /*
    public IEnumerator CameraPan()
    {
        CameraManager.Instance.PanToPoint(transform.position);

        yield return new WaitForSeconds(panTime);

        CameraManager.Instance.CancelPan();
    }
    */
}
