using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEventAgent : MonoBehaviour
{
	public enum Role
	{
		Sender,
		Receiver,
		Both
	}
	[Tooltip("'Sender' and 'Both' will send an event with the set ID when EventSend() is called")]
	[SerializeField] protected Role actorRole;
	[Tooltip("When an event is sent from this actor, all initialized receiver EventAgents with the same ID will be activated")]
	[SerializeField] protected int senderID;
	[Tooltip("When an event is sent with a matching ID, this agent will be activated")]
	[SerializeField] protected int receiverID;
	protected bool progressedState = false;

	protected void InitReceiver()
	{
		EventManager.Instance.ProgressionEvent += EventReceive;
	}

	protected void EventReceive(int pID)
	{
		if (pID == receiverID && actorRole != Role.Sender)
		{
			progressedState = true;
			OnReceive();
		}
	}

	protected virtual void OnReceive() 
	{
		Debug.LogWarning("Receiver Event Agent inherited and triggered on ID " + receiverID + ". override OnReceive() with an override function for event");
	}

	/// <summary>
	/// Triggers events with the same ID, if actorRole is set to 'Sender' or 'Both'
	/// </summary>
	protected void EventSend()
	{
		EventManager.Instance.TriggerProgression(senderID);
	}
}
