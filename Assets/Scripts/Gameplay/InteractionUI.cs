using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    public bool IsDisplayed = false;
    private Camera mainCamera;
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private TextMeshProUGUI promptText;
    [Range(0f, 10f)]
    [SerializeField] private float promptHeight;
    
    void Start()
    {
        mainCamera = Camera.main;
        uiPanel.SetActive(false);
    }

    void LateUpdate()
    {
        TurnToCamera();
    }

    public void SetUp(string pPrompt, Vector3 pPosition)
    {
        /*
         * Code to put interaction UI above target head, currently not possible as interaction UI is child of player
        Vector3 interactablePos = pPosition;
        interactablePos.y += promptHeight;
        transform.position = interactablePos;
        */
        promptText.text = pPrompt;
        uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        uiPanel.SetActive(false);
        IsDisplayed = false;

    }

    private void TurnToCamera()
    {
        Quaternion rotation = mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }
}
