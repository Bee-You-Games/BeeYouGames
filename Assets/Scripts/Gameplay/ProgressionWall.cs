using UnityEngine;
public class ProgressionWall : AEventAgent
{
    [SerializeField]
    private float wallMovement = -5;
    [SerializeField]
    private float movementTime = 4;
    // Start is called before the first frame update
    void Start()
    {
        InitReceiver();
    }

    protected override void OnReceive() 
    {
        transform.LeanMoveLocalY(transform.position.y + wallMovement, movementTime);
        StartCoroutine(CameraManager.Instance.CameraPan(movementTime, transform.position));
    }
}
