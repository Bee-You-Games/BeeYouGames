using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float interactRange;
    [SerializeField] private LayerMask interactLayer;

    private float numFound;
    private readonly Collider[] colliders = new Collider[3];
    IInteractable interactable;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(transform.position, interactRange, colliders, interactLayer);

        if (numFound > 0)
        {
            interactable = colliders[0].GetComponent<IInteractable>();
        }
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, interactRange);
	}

    public void Interact()
    {
        if (interactable != null)
        {
            interactable.Interact(this);
        }
    }
}
