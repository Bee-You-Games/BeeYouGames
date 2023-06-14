using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class AreaTrigger : MonoBehaviour
{
    private Collider triggerCollider;
    protected void Setup()
    {
        triggerCollider = GetComponent<Collider>();
        triggerCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Activate();
        }
    }

    protected virtual void Activate(){
        Debug.Log("AreaTrigger triggered, Activate not implemented in class inheriting AreaTrigger");
    }

}
