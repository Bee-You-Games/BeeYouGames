using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.LogWarning("interactable object doesn't have animator");
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log(gameObject.name + " is being interacted with!");
        animator.SetBool("Interacting", true);
        return true;
    }
}
