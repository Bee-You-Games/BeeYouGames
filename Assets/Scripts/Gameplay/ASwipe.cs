using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASwipe : MonoBehaviour
{
    [SerializeField]
    protected int pixelDistToDetect = 20;
    protected bool isActive = false;

    protected bool isFingerDown = false;

    Vector2 startPos = new Vector2();
    Vector2 endPos = new Vector2();

    protected virtual Vector2 GetSwipeOnPC()
    {
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
            isFingerDown = false;
        }

        return deltaVec;
    }

    /// <summary>
    /// Gets the position of a touch in world space
    /// </summary>
    /// <returns></returns>
    protected Vector3 GetTouchPosition()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            return Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
        }
        else
            return Vector3.zero;
    }

    protected virtual Vector2 GetSwipeOnPhone()
    {
        Vector2 startPos = new Vector2();
        Vector2 endPos = new Vector2();
        Vector2 deltaVec = new Vector2();
        Touch touch = new Touch();

        if (Input.touchCount > 0)
            touch = Input.touches[0];
        else
            return Vector2.zero;
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
