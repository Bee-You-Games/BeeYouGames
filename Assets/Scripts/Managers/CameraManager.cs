using System.Collections;
using UnityEngine;
using Cinemachine;
[RequireComponent(typeof(CinemachineVirtualCamera))]

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }
    public CinemachineVirtualCamera PlayerVirtualCam { get; private set; }
    private Camera mainCam;
    [SerializeField]
    private PlayerCamTarget camTarget;
    [SerializeField]
    private GameObject cameraPrefab;
    private GameObject currentCam;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else 
        {
            Debug.LogWarning("Several CameraManager scripts are being initiated");
            Destroy(this);
        }
        mainCam = Camera.main;
        PlayerVirtualCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void SetTarget(Transform pTarget)
    {
        camTarget.targetTransform = pTarget;
    }

    public IEnumerator PanToPoint(Vector3 point, float panFrames)
    {
        int elapsedFrames = 0;
        PlayerVirtualCam.enabled = false;
        Vector3 camPosition = mainCam.transform.position;
        Vector3 targetPosition = point;
        targetPosition.x = camPosition.x;
        while (Vector3.Distance(mainCam.transform.position, targetPosition) > 0.1f)
        {
            float interpolationRatio = (float)elapsedFrames / panFrames;
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, targetPosition, interpolationRatio);
            yield return null;
        }
        //yield return new WaitForSeconds(2);
        PlayerVirtualCam.enabled = true;
    }
    /*
    public void PanToPoint(Vector3 point)
    {
        currentCam = Instantiate(cameraPrefab);
        Vector3 camPosition = currentCam.transform.position;
        camPosition.x = point.x;
        currentCam.transform.position = camPosition;
        PlayerCam.enabled = false;
    }
    */

    public void CancelPan()
    {
        if (currentCam != null)
        {
            PlayerVirtualCam.enabled = true;
            Destroy(currentCam);
            currentCam = null;
        }
        else
            Debug.LogWarning("CancelPan was called why there was no camera pan active");
    }
}
