using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class ParallaxEffect : MonoBehaviour
{
    //[HideInInspector]
    public float Speed;
    //[HideInInspector]
    public bool isRepeating = true;
    //[HideInInspector]
    public bool isRepeatingRandom = false;

    private float startPosition;
    private float spriteLength;
    private CharacterController2D player;
    private Camera cam;

    public event System.Action<ParallaxEffect> OnDestruction;

    private void Start()
    {
        //Check to see if unity is in playmode, because of the excecute always attribute
        if (Application.isPlaying)
        {
            cam = Camera.main;
            player = FindObjectOfType<CharacterController2D>();
            if (player == null) Debug.LogError("Couldn't find a player object", this);

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
            float temp = player.transform.position.x * (1 - Speed);

            float distance = player.transform.position.x * Speed;
            transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

            if (!isRepeating) return;

            if (temp > startPosition + spriteLength)
                startPosition += spriteLength;
            else if (temp < startPosition - spriteLength)
                startPosition -= spriteLength;
        }
    }
}
