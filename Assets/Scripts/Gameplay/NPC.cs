using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : AEventAgent, IInteractable
{
    [Header("Interaction Settings")]
    Animator animator;
    [SerializeField] private string prompt;
    public string Prompt => prompt;
    [SerializeField] private Dialogue NPCDialogue;
    public bool Available { get; set; }

	private void Awake()
    {
        Available = true;
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.LogWarning("NPC doesn't have animator");
        if(NPCDialogue != null)
            InkManager.Instance.StartDialogue(NPCDialogue);
        if (actorRole != Role.Sender)
        {
            InitReceiver();
        }
    }

    public bool Interact(PlayerInteractor interactor)
    {
        if (NPCDialogue != null)
        {
            NPCDialogue.parentNPC = this;
        }
        StartCoroutine(DanceBreak());
        if ((actorRole == Role.Sender) || (actorRole == Role.Both && progressedState))
        {
            EventSend();
        }
        return true;
    }

    IEnumerator DanceBreak()
    {
        animator.SetBool("Interacting", true);
        Available = false;
        yield return new WaitForSeconds(3f);
        animator.SetBool("Interacting", false);
        Available = true;
    }
}