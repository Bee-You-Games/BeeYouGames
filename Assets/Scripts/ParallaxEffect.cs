using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField][Range(0f, 1f)]
    private float parallaxSpeed;
    [SerializeField][Tooltip("If set to true, the image will repeat itself.\nBest used for an endless background")]
    private bool isRepeating = true;

    private float startPosition;
    private float spriteLength;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        startPosition = transform.position.x;
        spriteLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = cam.transform.position.x * (1 - parallaxSpeed);

        float distance = cam.transform.position.x * parallaxSpeed;
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        if (!isRepeating) return;

        if (temp > startPosition + spriteLength)
            startPosition += spriteLength;
        else if (temp < startPosition - spriteLength)
            startPosition -= spriteLength;
    }
}
