using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ParallaxEffect : MonoBehaviour
{
    [Range(0f, 1f)]
    public float Speed;
    [Tooltip("If set to true, the image will repeat itself.\nBest used for an endless background")]
    public bool isRepeating = true;
    public bool isRepeatingRandom = false;

    private float startPosition;
    private float spriteLength;
    private Camera cam;

    public event System.Action<ParallaxEffect> OnDestruction;

    private void Start()
    {
        //Check to see if unity is in playmode, because of the excecute always attribute
        if (Application.isPlaying)
        {
            cam = Camera.main;
            startPosition = transform.position.x;
            spriteLength = GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

    private void OnDestroy()
    {
        //TODO make sure this gets called in editor time aswell
        OnDestruction?.Invoke(this);   
    }

    private void Update()
    {
        //Check to see if unity is in playmode, because of the excecute always attribute
        if (Application.isPlaying)
        {
            float temp = cam.transform.position.x * (1 - Speed);

            float distance = cam.transform.position.x * Speed;
            transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

            if (!isRepeating) return;

            if (temp > startPosition + spriteLength)
                startPosition += spriteLength;
            else if (temp < startPosition - spriteLength)
                startPosition -= spriteLength;
        }
    }
}
