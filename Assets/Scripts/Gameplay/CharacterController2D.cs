using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Interactor))]


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
    private PlayerInput playerInput;
    private Interactor interactor;
    // Start is called before the first frame update
	private void Awake()
	{
        playerBody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        interactor = GetComponent<Interactor>();
        
        cam = Camera.main;
    }

	void Update()
    {
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();

        if (input.magnitude != 0)
        {
            Vector3 velocity = new Vector3(input.x, 0, input.y);
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

    //OnInteract is called when the Input System gets an input for Interact (check input actions)
    private void OnInteract()
    {
        interactor.Interact();
    }
}
