using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : AEventAgent, IInteractable
{
    Animator animator;
    [SerializeField] private string _prompt;
    public string Prompt => _prompt;
    public bool Available { get; set; }

	private void Awake()
    {
        Available = true;
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.LogWarning("NPC doesn't have animator");
        if (actorRole != Role.Sender)
        {
            InitReceiver();
        }
    }

    public bool Interact(PlayerInteractor interactor)
    {
        animator.SetBool("Interacting", true);
        Available = false;

        if ((actorRole == Role.Sender) || (actorRole == Role.Both && progressedState))
        {
            EventSend();
        }
        return true;
    }

	protected override void OnReceive()
	{
		
	}
}