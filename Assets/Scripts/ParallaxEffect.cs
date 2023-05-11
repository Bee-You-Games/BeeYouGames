using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class ParallaxEffect : MonoBehaviour
{
    [HideInInspector]
    public float Speed;
    [HideInInspector]
    public bool isRepeating = true;
    [HideInInspector]
    public bool isRepeatingRandom = false;

    private float startPosition;
    private float spriteLength;

    private CharacterController2D player;
    [SerializeField]
    private Transform cam;

    private GameObject leftDuplicate;
    private GameObject rightDuplicate;
    

    public event System.Action<ParallaxEffect> OnDestruction;

    private void Start()
    {
        //Check to see if unity is in playmode, because of the excecute always attribute
        if (Application.isPlaying)
        {
            //cam = Camera.main.transform;
            Debug.Log(cam.gameObject.name);
            //player = FindObjectOfType<CharacterController2D>();
            //if (player == null) Debug.LogError("Couldn't find a player object", this);

            startPosition = transform.position.x;

            spriteLength = GetComponent<SpriteRenderer>().bounds.size.x;

            if (isRepeating)
            {
                leftDuplicate = new GameObject($"{this.name} left");
                leftDuplicate.transform.SetParent(this.transform);
                var spriteRendererLeft = leftDuplicate.AddComponent<SpriteRenderer>();
                spriteRendererLeft.sprite = GetComponent<SpriteRenderer>().sprite;
                spriteRendererLeft.sortingOrder = GetComponent<SpriteRenderer>().sortingOrder;
                leftDuplicate.transform.rotation = transform.rotation;
                leftDuplicate.transform.localScale = transform.localScale;
                leftDuplicate.transform.position = transform.position - new Vector3(GetComponent<SpriteRenderer>().bounds.size.x, 0, 0);

                rightDuplicate = new GameObject($"{this.name} right");
                rightDuplicate.transform.SetParent(this.transform);
                var spriteRendererRight = rightDuplicate.AddComponent<SpriteRenderer>();
                spriteRendererRight.sprite = GetComponent<SpriteRenderer>().sprite;
                spriteRendererRight.sortingOrder = GetComponent<SpriteRenderer>().sortingOrder;
                rightDuplicate.transform.rotation = transform.rotation;
                rightDuplicate.transform.localScale = transform.localScale;
                rightDuplicate.transform.position = transform.position + new Vector3(GetComponent<SpriteRenderer>().bounds.size.x, 0, 0);
            }
        }
    }

    private void OnDestroy()
    {
        if(!Application.isPlaying)
            OnDestruction?.Invoke(this);
    }

    private void Update()
    {
        //Check to see if unity is in playmode, because of the excecute always attribute
        if (Application.isPlaying)
        {
            Debug.Log(cam.position.x);
            float tempPos = cam.position.x * (1 - Speed);

            float distance = cam.transform.position.x * Speed;
            transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

            if (!isRepeating) return;

            if (tempPos > startPosition + spriteLength)
                startPosition += spriteLength;
            else if (tempPos < startPosition - spriteLength)
                startPosition -= spriteLength;
        }
    }
}
