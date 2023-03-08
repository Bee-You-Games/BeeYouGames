using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;

public class InkManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset inkJSON;
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private Button choiceButtonPrefab;
    [SerializeField]
    private Transform choiceButtonParent;

    private Story story;
    private bool isDialogueActive = false;

    public event Action OnDialogueStart;
    public event Action OnDialogueEnd;

    private void Start()
    {
        StartDialogue();
        story = new Story(inkJSON.text);
        UpdateDialogueText();
    }

    private void Update()
    {
        if (story == null) return;
        if (!isDialogueActive) return;

        if (Input.GetMouseButtonDown(1))
            UpdateDialogueText();
    }

    private void UpdateDialogueText()
    {
        Debug.Log("Updating text");
        EraseUI();

        string text = GetDialogueText();

        //TODO: implement system to go through tags in JSON file
        List<string> tags = story.currentTags;
        if(tags.Count > 0)
            text = tags[0] + " - " + text;

        dialogueText.text = text;

        if (story != null && story.currentChoices.Count > 0)
            InstantiateChoiceButtons();
    }

    private void EraseUI()
    {
        for (int i = 0; i < choiceButtonParent.childCount; i++)
        {
            choiceButtonParent.GetChild(i).GetComponent<Button>().onClick.RemoveAllListeners();
            Destroy(choiceButtonParent.GetChild(i).gameObject);
        }
    }

    private string GetDialogueText()
    {
        string text = "";

        if (!story.canContinue)
        {
            EndDialogue();
            return "";
        }

        text = story.Continue();

        return text;
    }

    private void InstantiateChoiceButtons()
    {
        foreach (Choice choice in story.currentChoices)
        {
            Button button = Instantiate(choiceButtonPrefab) as Button;
            TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
            text.text = choice.text;
            button.transform.SetParent(choiceButtonParent, false);

            button.onClick.AddListener(delegate { ChooseStoryChoice(choice); });
        }
    }

    private void ChooseStoryChoice(Choice pChoice)
    {
        Debug.Log("Choosing button index " + pChoice.index);
        story.ChooseChoiceIndex(pChoice.index);

        UpdateDialogueText();
    }

    public void StartDialogue()
    {
        Debug.Log("Starting Dialogue");
        gameObject.SetActive(true);
        isDialogueActive = true;
        OnDialogueStart?.Invoke();
    }

    public void EndDialogue()
    {
        Debug.Log("Ending dialogue");
        gameObject.SetActive(false);
        isDialogueActive = false;
        OnDialogueEnd?.Invoke();
    }
}
