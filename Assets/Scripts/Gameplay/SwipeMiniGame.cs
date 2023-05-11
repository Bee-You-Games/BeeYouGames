using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMiniGame : ASwipe, IInteractable
{
    [SerializeField]
    private ParticleSystem trailPrefab;
    [SerializeField]
    private string prompt;

    private int swipeCount;
    private ParticleSystem trail;

    public string Prompt => prompt;

    public bool Available { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Available = true;
    }

    private void OnDisable()
    {
        //Destroy(trail.gameObject);
    }

    public bool Interact(PlayerInteractor interactor)
    {
        GameObject obj = Instantiate(trailPrefab.gameObject);
        trail = obj.GetComponent<ParticleSystem>();
        trail.gameObject.SetActive(false);
        return true;
    }


    // Update is called once per frame
    void Update()
    {
        if (trail != null)
        {
            if (!trail.gameObject.activeInHierarchy && isFingerDown)
                trail.gameObject.SetActive(true);
            if (trail.gameObject.activeInHierarchy && !isFingerDown)
                trail.gameObject.SetActive(false);
#if UNITY_STANDALONE
            TrailFollowMouse();

            if (GetSwipeOnPC().magnitude >= pixelDistToDetect)
            {
                swipeCount++;
                Debug.Log(swipeCount);
            }
#endif
#if UNITY_ANDROID
            TrailFollowTouch();

            if(GetSwipeOnPhone().magnitude >= pixelDistToDetect)
            {
                swipeCount++;
                Debug.Log(swipeCount);
            }
#endif
        }
    }

    private void TrailFollowTouch()
    {
        trail.transform.position = GetTouchPosition();
    }

    private void TrailFollowMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Debug.Log("MousePos" + mousePos);
        trail.transform.position = mousePos;
    }
}
