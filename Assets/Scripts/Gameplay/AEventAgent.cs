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
	[Tooltip("When event is sent, all initialized EventAgents with the same ID will be activated")]
	[SerializeField] protected int eventID = 1;

	protected void InitReceiver()
	{
		EventManager.Instance.ProgressionEvent += EventReceive;
	}

	protected virtual void EventReceive(int pID)
	{
		if (pID == eventID && actorRole != Role.Sender)
			Debug.LogWarning("Event Agent inherited and triggered on ID "+ pID +" , override EventActivate() with an override function for event");
	}

	/// <summary>
	/// Triggers events with the same ID, if actorRole is set to 'Sender' or 'Both'
	/// </summary>
	protected void EventSend()
	{
		if (actorRole == Role.Sender || actorRole == Role.Both)
			EventManager.Instance.TriggerProgression(eventID);
	}
}
