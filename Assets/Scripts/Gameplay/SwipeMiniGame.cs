using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMiniGame : ASwipe, IInteractable
{
    [SerializeField]
    private string prompt;

    private int swipeCount;

    public string Prompt => prompt;

    public bool Available { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Available = true;
    }

    public bool Interact(PlayerInteractor interactor)
    {
        return true;
    }


    // Update is called once per frame
    void Update()
    {
        if (GetSwipeOnPC().magnitude >= pixelDistToDetect)
        {
            swipeCount++;
            Debug.Log(swipeCount);
        }
    }
}
