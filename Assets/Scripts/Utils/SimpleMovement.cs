using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField][Range(0f, 100f)]
    private float speed = 5f;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            handleMovement(-1);
        else if (Input.GetKey(KeyCode.D))
            handleMovement(1);
    }

    private void handleMovement(int pDirection)
    {
        Vector3 velocity = new Vector3(pDirection, 0, 0);
        velocity.Normalize();

        transform.position += velocity * speed * Time.deltaTime;
        cam.transform.position += velocity * speed * Time.deltaTime;
    }
}
