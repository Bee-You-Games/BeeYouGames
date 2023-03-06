using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 100f)]
    private float speed = 5f;
    [SerializeField]
    [Range(300f, 900f)]
    private float rotationSpeed = 600;
    private Camera cam;
    private Rigidbody playerBody;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        

        if (horizontalMovement != 0 || verticalMovement != 0)
        {
            Vector3 velocity = new Vector3(horizontalMovement, 0, verticalMovement);
            Movement(velocity);
        }

        //Camera movement
        Vector3 cameraPosition = cam.transform.position;
        cameraPosition.x = playerBody.position.x;
        cam.transform.position = cameraPosition;        
    }

    private void Movement(Vector3 pMovementVelocity)
    {
        playerBody.velocity = pMovementVelocity * speed;
        //Rotation with movement
        Quaternion toRotation = Quaternion.LookRotation(pMovementVelocity, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}
