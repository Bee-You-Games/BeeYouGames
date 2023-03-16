using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    public bool IsDisplayed = false;
    private Camera mainCamera;
    private Transform playerPosition;
    private CanvasGroup panelGroup;
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private TextMeshProUGUI promptText;
    [Range(0f, 10f)]
    [SerializeField] private float promptHeight;
    [Range(0, 1.5f)]
    [SerializeField] private float fadeTime = 0.5f;
    
    void Start()
    {
        mainCamera = Camera.main;
        playerPosition = transform.parent.transform;
        panelGroup = uiPanel.GetComponent<CanvasGroup>();
        uiPanel.transform.parent = null;
        uiPanel.SetActive(false);

    }

    void LateUpdate()
    {
        TurnToCamera();
    }

    public void SetUp(string pPrompt, Vector3 pPosition)
    {
        
        Vector3 interactablePos = pPosition;
        interactablePos.y += promptHeight;
        transform.position = interactablePos;

        promptText.text = pPrompt;

        uiPanel.SetActive(true);
        panelGroup.alpha = 0;
        panelGroup.LeanAlpha(1, 0.5f);
        IsDisplayed = true;
    }

    public void Close()
    {
        IsDisplayed = false;
        panelGroup.alpha = 1;
        panelGroup.LeanAlpha(0, fadeTime);
        StartCoroutine(DelayedDisable(uiPanel, fadeTime));
    }

    IEnumerator DelayedDisable(GameObject pObject, float pTime)
    {
        yield return new WaitForSeconds(pTime);
        pObject.SetActive(false);
    }

    private void TurnToCamera()
    {
        Quaternion rotation = mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }
}
