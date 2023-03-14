using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
	public string Prompt { get; }
	public bool Available { get; set; }
	public bool Interact(Interactor interactor);
}
