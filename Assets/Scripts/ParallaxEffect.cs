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
    [HideInInspector]
    public float MinimumHeight;
    [HideInInspector]
    public float MaximumHeight;

    private float startPosition;
    private float spriteLength;
    private float screenWidth;

    private Vector2 screenBounds;

    private CharacterController2D player;
    private Camera cam;
    private Transform camTrans;
    private Renderer objRenderer;

    private GameObject leftDuplicate;
    private GameObject rightDuplicate;

    private bool wasMoved;

    public event System.Action<ParallaxEffect> OnDestruction;

    private void Start()
    {
        cam = Camera.main;
        objRenderer = GetComponent<Renderer>();

        float cameraHeight = cam.orthographicSize * 2f;
        screenWidth = cameraHeight * cam.aspect;

        //Check to see if unity is in playmode, because of the excecute always attribute
        if (Application.isPlaying)
        {
            camTrans = cam.transform;
            player = FindObjectOfType<CharacterController2D>();
            if (player == null) Debug.LogError("Couldn't find a player object", this);

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
        if (!Application.isPlaying) return;

        float tempPos = camTrans.position.x * (1 - Speed);

        float distance = camTrans.position.x * Speed;
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        if (isRepeating)
        {
            if (tempPos > startPosition + spriteLength)
                startPosition += spriteLength;
            else if (tempPos < startPosition - spriteLength)
                startPosition -= spriteLength;
        }
        else if (isRepeatingRandom)
        {
            if (!IsOnScreen() && !wasMoved)
            {
                wasMoved = true;
                float distToCam = transform.position.x - camTrans.position.x;
                float moveDist = screenWidth + objRenderer.bounds.extents.x;

                if (distToCam > 0)
                    startPosition -= moveDist;
                else if (distToCam < 0)
                    startPosition += moveDist;
            }
            else if (IsOnScreen() && wasMoved)
                wasMoved = false;
        }
    }

    private bool IsOnScreen()
    {
        if (objRenderer == null || !objRenderer.enabled)
            return false;

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        return GeometryUtility.TestPlanesAABB(planes, objRenderer.bounds);
    }
}
