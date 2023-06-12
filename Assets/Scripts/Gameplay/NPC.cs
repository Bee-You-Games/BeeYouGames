using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : AEventAgent, IInteractable
{
    [Header("Interaction Settings")]
    Animator animator;
    [SerializeField] private string prompt;
    public string Prompt => prompt;
    [SerializeField] private SODialogue NPCDialogue;
    public bool Available { get; set; }

	private void Start()
    {
        Available = true;
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.LogWarning("NPC doesn't have animator");
        if(NPCDialogue != null)
            NPCDialogue.parentAgent = this;
        if (actorRole != Role.Sender)
        {
            InitReceiver();
        }
    }

    public bool Interact(PlayerInteractor interactor)
    {
        if (NPCDialogue != null)
        {
            InkManager.Instance.StartDialogue(NPCDialogue, this.gameObject, receiverID, senderID);
        }
        else if ((actorRole == Role.Sender) || (actorRole == Role.Both && progressedState))
        {
            EventSend();
        }
        if(animator != null)
            StartCoroutine(PlayAnimation());

        return true;
    }

    public override void SetDialogue(SODialogue pDialogue)
    {
        NPCDialogue = pDialogue;
        InkManager.Instance.SwitchDialogue(pDialogue);
    }

    IEnumerator PlayAnimation()
    {
        animator.SetBool("Interacting", true);
        Available = false;
        yield return new WaitForSeconds(3f);
        animator.SetBool("Interacting", false);
        Available = true;
    }
}