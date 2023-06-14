using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : AreaTrigger
{
    private SODialogue dialogue;
    [SerializeField]
    private NPC speakingNPC;
    void Start()
    {
        Setup();
        dialogue = speakingNPC.NPCDialogue;
    }

    protected override void Activate()
    {
        InkManager.Instance.StartDialogue(dialogue, speakingNPC.gameObject, speakingNPC.GetReceiverID(), speakingNPC.GetSenderID());
        Destroy(gameObject);
    }
}