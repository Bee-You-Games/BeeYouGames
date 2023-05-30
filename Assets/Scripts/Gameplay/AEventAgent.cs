using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EventIndicator))]
public abstract class AEventAgent : MonoBehaviour
{
	public enum Role
	{
		Sender,
		Receiver,
		Both
	}
	[SerializeField]
	[Tooltip("This event will be called when the DialogueSuccess function is called through dialogue, if triggerDialogueSuccess is enabled")]
    private UnityEvent dialogueSuccessEvent;
	[Header("Event Agent Settings")]
	[Tooltip("'Sender' and 'Both' will send an event with the set ID when EventSend() is called")]
	[SerializeField] protected Role actorRole;
	[Tooltip("When an event is sent from this actor, all initialized receiver EventAgents with the same ID will be activated")]
	[SerializeField] protected int senderID = 0;
	[Tooltip("When an event is sent with a matching ID, this agent will be activated")]
	[SerializeField] protected int receiverID = 0;
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

	public virtual void DialogueSuccess()
	{
		if(dialogueSuccessEvent != null)
			dialogueSuccessEvent.Invoke();
		else 
			Debug.LogWarning("No success event set for " + gameObject.name);
	}

    public int GetSenderID() => senderID;
    public int GetReceiverID() => receiverID;
}
