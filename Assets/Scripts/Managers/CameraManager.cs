using UnityEngine;
using Cinemachine;
[RequireComponent(typeof(CinemachineVirtualCamera))]

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }
    public CinemachineVirtualCamera PlayerCam { get; private set; }
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

        PlayerCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void SetTarget(Transform pTarget)
    {
        camTarget.targetTransform = pTarget;
    }

    public void PanToPoint(Vector3 point)
    {
        GameObject camera = Instantiate(cameraPrefab);
        Vector3 camPosition = camera.transform.position;
        camPosition.x = point.x;
        camera.transform.position = camPosition;
        currentCam = camera;
        PlayerCam.enabled = false;
    }

    public void CancelPan()
    {
        if (currentCam != null)
        {
            PlayerCam.enabled = true;
            Destroy(currentCam);
            currentCam = null;
        }
        else
            Debug.LogWarning("CancelPan was called why there was no camera pan active");
    }
}
