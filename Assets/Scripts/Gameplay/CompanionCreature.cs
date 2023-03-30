using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionCreature : MonoBehaviour
{
    [SerializeField] private Transform playerObject;
    [SerializeField] private float preferredDistance = 1;
    [SerializeField] private float movementSpeed = 5;
    private bool moving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerObject.position) > preferredDistance && !moving)
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
            //transform.position -= (playerObject.position - transform.position) * 0.06f;
            yield return null;
        }
        moving = false;
    }
}
