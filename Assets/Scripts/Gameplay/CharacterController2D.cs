using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerInteractor))]


public class CharacterController2D : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField]  private float speed = 5f;
    [Range(300f, 900f)]
    [SerializeField]  private float rotationSpeed = 600;
    private Rigidbody playerBody;
    private PlayerInput playerInput;
    private PlayerInteractor interactor;
    private Animator animator;
    // Start is called before the first frame update
	private void Awake()
	{
        playerBody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        interactor = GetComponent<PlayerInteractor>();
        animator = GetComponent<Animator>();
    }

	void Update()
    {
        if (InkManager.Instance != null && !InkManager.Instance.IsDialogueActive)
        {
            Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();

            if (input.magnitude != 0)
            {
                Vector3 velocity = new Vector3(input.x, 0, input.y);
                Movement(velocity);
            }else
            {
                animator.SetBool("walking", false);
            }
        }
    }

    private void Movement(Vector3 pMovementVelocity)
    {
        animator.SetBool("walking", true);
        playerBody.velocity = pMovementVelocity * speed;

        //Rotation with movement
        Quaternion toRotation = Quaternion.LookRotation(pMovementVelocity, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }

    /// <summary>
    /// OnInteract is called when the Input System gets an input for Interact (check input actions)
    /// </summary>
    private void OnInteract()
    {
        if (!InkManager.Instance.IsDialogueActive)
            interactor.Interact();
    }

    private void OnTap() 
    {
        if (InkManager.Instance.IsDialogueActive)
            InkManager.Instance.DialogueClick();
        
    }
}
