using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    public bool IsDisplayed = false;
    public IInteractable Target { get; private set; }
    private CanvasGroup panelGroup;
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private TextMeshProUGUI promptText;
    [Range(0f, 10f)]
    [SerializeField] private float promptHeight;
    [Range(0, 1.5f)]
    [SerializeField] private float fadeTime = 0.5f;
    
    void Start()
    {
        panelGroup = uiPanel.GetComponent<CanvasGroup>();
        uiPanel.transform.SetParent(null);
        panelGroup.alpha = 0;
    }

    public void SetUp(string pPrompt, Vector3 pPosition, IInteractable pTarget)
    {
        Target = pTarget;
        Vector3 interactablePos = pPosition;
        interactablePos.y += promptHeight;
        transform.position = interactablePos;

        promptText.text = pPrompt;

        panelGroup.alpha = 0;
        panelGroup.LeanAlpha(1, 0.5f);
        IsDisplayed = true;
    }

    public void Close()
    {
        Target = null;
        IsDisplayed = false;
        panelGroup.alpha = 1;
        panelGroup.LeanAlpha(0, fadeTime);
    }
}
