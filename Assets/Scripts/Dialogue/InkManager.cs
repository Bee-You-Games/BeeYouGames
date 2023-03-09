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
    [SerializeField]
    private Image playerImage, npcImage;

    private Story story;
    private bool isDialogueActive = false;

    private const string testTag = "testTag";

    private const string lockedBtnTag = "locked";

    public static InkManager Instance { get; private set; }

    public event Action OnDialogueStart;
    public event Action OnDialogueEnd;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("Multiple instances of InkManager have been found", this);
    }

    private void Start()
    {
        StartDialogue(inkJSON);
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

        HandleTextTags(text);

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
            TextMeshProUGUI tmProText = button.GetComponentInChildren<TextMeshProUGUI>();

            string text = HandleButtonTag(choice.text, button, choice);

            tmProText.text = text;
            button.transform.SetParent(choiceButtonParent, false);

        }
    }

    private void HandleTextTags(string pText)
    {
        List<string> tags = story.currentTags;
        if (tags.Count > 0)
            pText = tags[0] + " - " + pText;
        
        foreach (string tag in tags)
        {
            //You can implement more tags here
            //Would like to sometime make a system to use a txt or json file to handle the logic for button tags
            switch (tag)
            {
                case testTag:
                    Debug.Log("testing Tag");
                    break;
            }
        }
    }

    private string HandleButtonTag(string pTag, Button pButton, Choice pChoice)
    {
        string choiceText = pTag;
        int stringIndex = pTag.IndexOf('$', 0);

        if (stringIndex >= 0)
        {
            string tagText = choiceText.Substring(stringIndex).Replace("$", "");
            tagText.ToLower();

            choiceText.Replace(" $locked", "");
            Debug.Log(choiceText);

            //You can implement more tags here
            //Would like to sometime make a system to use a txt or json file to handle the logic for button tags
            switch (pTag)
            {
                case lockedBtnTag:
                    return choiceText;
            }
        }

        Debug.Log("No tag was found");
        pButton.onClick.AddListener(delegate { ChooseStoryChoice(pChoice); });
        return choiceText;
    }

    private void ChangeInkVariable(string pVariableName, string pValue) => story.variablesState[pVariableName] = pValue;
    private void ChangeInkVariable(string pVariableName, int pValue) => story.variablesState[pVariableName] = pValue;
    private void ChangeInkVariable(string pVariableName, bool pValue) => story.variablesState[pVariableName] = pValue;
    private void ChangeInkVariable(string pVariableName, float pValue) => story.variablesState[pVariableName] = pValue;

    private VariablesState GetInkVariable(string pVariableName) => story.variablesState[pVariableName] as VariablesState;

    private void ChooseStoryChoice(Choice pChoice)
    {
        Debug.Log("Choosing button index " + pChoice.index);
        story.ChooseChoiceIndex(pChoice.index);

        UpdateDialogueText();
    }

    public void StartDialogue(TextAsset pDialogueFile)
    {
        Debug.Log("Starting Dialogue");
        story = new Story(pDialogueFile.text);
        gameObject.SetActive(true);
        isDialogueActive = true;
        OnDialogueStart?.Invoke();
    }

    public void EndDialogue()
    {
        Debug.Log("Ending dialogue");
        EraseUI();
        gameObject.SetActive(false);
        isDialogueActive = false;
        OnDialogueEnd?.Invoke();
    }
}
