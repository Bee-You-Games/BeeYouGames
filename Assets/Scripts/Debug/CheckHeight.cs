using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CheckHeight : MonoBehaviour
{
    void Start()
    {
        Vector3 boxSize = GetComponent<Collider>().bounds.size;
        Debug.Log(boxSize.y);
    }
}
