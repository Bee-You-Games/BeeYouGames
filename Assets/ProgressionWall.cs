using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionWall : MonoBehaviour
{
    [SerializeField]
    private int id = 1;
    [SerializeField]
    private float wallMovement = -5;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.ProgressionEvent += MoveWall;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveWall(int pID) 
    {
        if(pID == id)
        transform.LeanMoveLocalY(transform.position.y + wallMovement, 1);
    }

}
