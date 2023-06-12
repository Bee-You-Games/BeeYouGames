using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionCreature : AEventAgent, IInteractable
{
    [Header("Movement Settings")]
    [SerializeField] private Transform playerObject;
    [SerializeField] private float preferredDistance = 1;
    [SerializeField] private float movementSpeed = 5;
    private bool moving = false;
    private bool following = false;
    [Header("Interaction Settings")]
    [SerializeField] private string prompt;
    public string Prompt => prompt;
    public bool Available { get; set; }
    [SerializeField] private SODialogue creatureDialogue;

	private void Start()
	{
        if(PlayerPrefs.GetInt("CreatureUnlocked", 0) == 1)
        {
            Follow();
            return;
        }
        else
		Available = true;
        if (creatureDialogue != null)
            creatureDialogue.parentAgent = this;
        if (actorRole != Role.Sender)
        {
            InitReceiver();
        }
    }
	void Update()
    {
        if (following && Vector3.Distance(transform.position, playerObject.position) > preferredDistance && !moving)
            StartCoroutine(MoveTowardsPlayer());
    }

    private IEnumerator MoveTowardsPlayer()
    {
        moving = true;
        Vector3 initialTarget = new Vector3(playerObject.position.x, transform.position.y, playerObject.position.z);
        while (Vector3.Distance(transform.position, initialTarget) > preferredDistance)
        {
            Vector3 targetPosition = new Vector3(playerObject.position.x, transform.position.y, playerObject.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed * Time.deltaTime);
            yield return null;
        }
        moving = false;
    }

	public bool Interact(PlayerInteractor interactor)
	{
        InkManager.Instance.StartDialogue(creatureDialogue, gameObject, receiverID, senderID);
        return true;

    }

    public override void SetDialogue(SODialogue pDialogue)
    {
        creatureDialogue = pDialogue;
        InkManager.Instance.SwitchDialogue(pDialogue);
    }

	public override void DialogueSuccess()
	{
        PlayerPrefs.SetInt("CreatureUnlocked", 1);
        Follow();
    }

    private void Follow(){
        following = true;
        Available = false;
        gameObject.layer = 0;

        if(!EventManager.Instance.ProgressionCheck(senderID))
            EventManager.Instance.TriggerProgression(senderID);
    }
}
