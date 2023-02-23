using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 100f)]
    private float speed = 5f;
    private Camera cam;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(horizontalMovement, 0, verticalMovement);

        rigidbody.velocity = velocity * speed;
        Vector3 cameraPosition = cam.transform.position;
        cameraPosition.x = rigidbody.position.x;
        cam.transform.position = cameraPosition;


    }
}
