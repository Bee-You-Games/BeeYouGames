using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionWall : AEventAgent
{
    [SerializeField]
    private float wallMovement = -5;
    // Start is called before the first frame update
    void Start()
    {
        InitReceiver();
    }

    protected override void EventReceive(int pID) 
    {
        if(pID == eventID)
        transform.LeanMoveLocalY(transform.position.y + wallMovement, 1);
    }
}
