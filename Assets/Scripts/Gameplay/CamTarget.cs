using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTarget : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;
    void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = targetTransform.position.x;
        transform.position = currentPosition;
    }
}
