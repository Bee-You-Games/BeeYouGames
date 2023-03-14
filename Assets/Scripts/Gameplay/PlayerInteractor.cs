using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private float interactRange;
    [SerializeField] private LayerMask interactLayer;

    private float numFound;
    private readonly Collider[] colliders = new Collider[3];
    
    IInteractable interactable;
    [SerializeField] private InteractionUI interactionUI;


    void Update()
    {
        CheckInteractables();
    }

    //Debug gizmo to show interaction range
	private void OnDrawGizmos()
	{
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, interactRange);
	}

    private void CheckInteractables()
    {
        numFound = Physics.OverlapSphereNonAlloc(transform.position, interactRange, colliders, interactLayer);

        if (numFound > 0)
        {
            interactable = colliders[0].GetComponent<IInteractable>();
            Vector3 interactablePosition = colliders[0].gameObject.transform.position;
            if (interactable != null && interactable.Available == true)
            {
                if (!interactionUI.IsDisplayed) interactionUI.SetUp(interactable.Prompt, interactablePosition);
            }
        }
        else
        {
            if (interactable != null) interactable = null;
            if (interactionUI.IsDisplayed) interactionUI.Close();
        }
    }

    public void Interact()
    {
        if (interactable != null && interactable.Available == true)
        {
            interactable.Interact(this);
            interactionUI.Close();
        }
    }
}
