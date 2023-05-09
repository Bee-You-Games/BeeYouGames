using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thingamabob : AEventAgent, IInteractable
{
    [SerializeField] private string prompt;
    public string Prompt => prompt;
    public bool Available { get; set;}

	public bool Interact(PlayerInteractor interactor)
	{
        Debug.Log("boom");
        return true;
	}

	// Start is called before the first frame update
	void Start()
    {
        Available = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
