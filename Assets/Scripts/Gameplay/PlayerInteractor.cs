using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private float interactRange;
    [SerializeField] private LayerMask interactLayer;

    private float numFound;
    private readonly Collider[] colliders = new Collider[5];
    
    private IInteractable interactable;
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
            Collider closestTarget;
            if (numFound > 1)
            {
                List<Collider> sortedColliders = colliders
                    .Where(col => col != null)
                    .OrderBy(col => Vector3.Distance(col.transform.position, transform.position))
                    .ToList();

                closestTarget = sortedColliders[0];
            }
            else
                closestTarget = colliders[0];

            interactable = closestTarget.GetComponent<IInteractable>();
            Vector3 interactablePosition = closestTarget.gameObject.transform.position;
            if (interactable != null && interactable.Available == true)
            {
                //checks if either UI is inactive, or if the new target is a different interactable than the current interactionUI's target
                if (!interactionUI.IsDisplayed || interactionUI.Target != interactable) interactionUI.SetUp(interactable.Prompt, interactablePosition, interactable);
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
