using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASwipe : MonoBehaviour
{
    protected bool isActive;
    protected int pixelDistToDetect = 20;

    private bool isFingerDown = false;

#if UNITY_EDITOR
    protected virtual Vector2 GetSwipeOnPC()
    {
        Vector2 startPos = new Vector2();
        Vector2 endPos = new Vector2();
        Vector2 deltaVec = new Vector2();

        if (!isFingerDown && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            isFingerDown = true;
        }

        if (isFingerDown && Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            deltaVec = endPos - startPos;
        }

        if (deltaVec.magnitude >= pixelDistToDetect)
        {
            Debug.Log("Detected Swipe");
            Debug.Log("Swipe from: " + startPos + " to: " + endPos);
            Debug.Log("Swipe length: " + deltaVec.magnitude);
        }

        return deltaVec;
    }
#endif

    protected virtual Vector2 GetSwipeOnPhone()
    {
        Vector2 startPos = new Vector2();
        Vector2 endPos = new Vector2();
        Vector2 deltaVec = new Vector2();
        Touch touch = new Touch();

        if (Input.touchCount > 0)
            touch = Input.touches[0];

        if (!isFingerDown && touch.phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            isFingerDown = true;
        }

        if (isFingerDown && touch.phase == TouchPhase.Ended)
        {
            endPos = touch.position;
            deltaVec = endPos - startPos;
        }

        if (deltaVec.magnitude >= pixelDistToDetect)
        {
            Debug.Log("Detected Swipe");
            Debug.Log("Swipe from: " + startPos + " to: " + endPos);
            Debug.Log("Swipe length: " + deltaVec.magnitude);
        }

        return deltaVec;
    }
}
