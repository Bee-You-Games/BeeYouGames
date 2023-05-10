using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamTarget : MonoBehaviour
{
    public Transform targetTransform;

	private void Awake()
	{
        CharacterController2D player = FindObjectOfType<CharacterController2D>();
        if (player == null) Debug.LogError("Couldn't find a player object", this);
        else targetTransform = player.transform;
    }
	void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = targetTransform.position.x;
        transform.position = currentPosition;
    }
}
