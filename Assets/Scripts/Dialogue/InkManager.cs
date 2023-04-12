using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;

public class InkManager : MonoBehaviour
{
    [SerializeField]
    private Dialogue dialogue;
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private Button choiceButtonPrefab;
    [SerializeField]
    private Transform choiceButtonParent;
    [SerializeField]
    private Image playerImage, npcImage;

    private Story story;
    private DialogueVariables dialogueVariables;
    private bool isDialogueActive = false;

    private const string TEST_TAG = "testTag";
    private const string SPEAKER_TAG = "speaker";

    private const string LOCKED_BTNTAG = "locked";

    public static InkManager Instance { get; private set; }

    public event Action OnDialogueStart;
    public event Action OnDialogueEnd;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("Multiple instances of InkManager have been found", this);

        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (story == null) return;
        if (!isDialogueActive) return;

        if (Input.GetMouseButtonDown(0))
            UpdateDialogueText();
    }

    private void UpdateDialogueText()
    {
        Debug.Log("Updating text");
        EraseUI();

        string text = GetDialogueText();

        Debug.Log("Calling HandleTextTags method");
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
        }else if(story.currentChoices.Count == 0)
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
        if (tags.Count <= 0) return;

        foreach (string tag in tags)
        {
            //Check tagtype
            string tagType = GetTagType(tag);

            //You can implement more tags here
            switch (tagType)
            {
                case TEST_TAG:
                    Debug.Log("testing Tag");
                    break;
                case SPEAKER_TAG:
                    //implement text file with names and corresponding image locations
                    Debug.Log("Checking speaker tag");
                    SetCharacterSprite(GetSpeakerTagValue(tag));
                    break;
            }
        }
    }

    private string GetTagType(string pTag)
    {
        string[] tagContent = pTag.Split(':');

        if (tagContent.Length <= 0)
        {
            Debug.LogError("Given tag is empty", this);
            return "ERROR";
        }
        else
            return tagContent[0];

    }

    private string GetSpeakerTagValue(string pTag)
    {
        if (pTag.Contains("speaker"))
        {
            string[] speakerTagContent = pTag.Split(':');

            if (speakerTagContent.Length != 2) Debug.LogError("Speaker tag can't be read", this);

            return speakerTagContent[1];
        }
        else
        {
            Debug.LogError("Given tag isn't a speaker tag", this);
            return "Given tag isn't a speaker tag";
        } 
    }

    private void SetCharacterSprite(string pCharacterName)
    {
        /*
        foreach (Dialogue dialogue in characterSprites)
        {
            if (pCharacterName.ToLower() != dialogue.CharacterName.ToLower()) continue;

            npcImage.sprite = dialogue.CharacterSprite;
        }
        */
        playerImage.sprite = dialogue.CharacterASprite;
    }

    private string HandleButtonTag(string pTag, Button pButton, Choice pChoice)
    {
        string choiceText = pTag;
        int stringIndex = pTag.IndexOf('$', 0);

        if (stringIndex >= 0)
        {
            string tagText = choiceText.Substring(stringIndex).Replace("$", "");
            tagText.ToLower();

            choiceText = choiceText.Replace("$" + tagText, "");
            Debug.Log(tagText);

            //You can implement more tags here
            //Would like to sometime make a system to use a txt or json file to handle the logic for button tags
            switch (tagText)
            {
                case LOCKED_BTNTAG:
                    Debug.Log("ChoiceText: " + choiceText);
                    return choiceText;
            }
        }

        Debug.Log("No tag was found " + choiceText);
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

    public void StartDialogue(Dialogue pDialogueFile)
    {
        dialogue = pDialogueFile;
        story = new Story(pDialogueFile.DialogueFile.text);

        bool test = true;
        story.variablesState.SetGlobal("progress", new BoolValue(test));

        gameObject.SetActive(true);
        isDialogueActive = true;
        UpdateDialogueText();
        story.BindExternalFunction("ProgressionCheck", (int pID) =>
        {
            ProgressionCheck(pID);
        });
        story.BindExternalFunction("ProgressionEvent", (int pID) =>
        {
            ProgressionCheck(pID);
        });
        OnDialogueStart?.Invoke();
        Time.timeScale = 0;
    }

    public void EndDialogue()
    {
        dialogue = null;
        Debug.Log("Ending dialogue");
        EraseUI();
        gameObject.SetActive(false);
        isDialogueActive = false;
        story.UnbindExternalFunction("ProgressionCheck");
        story.UnbindExternalFunction("ProgressionEvent");
        OnDialogueEnd?.Invoke();
        Time.timeScale = 1;
    }

    public bool ProgressionCheck(int pID)
    {
        return EventManager.Instance.ProgressionCheck(pID);
    }

    public void ProgressionEvent(int pID)
    {
        EventManager.Instance.TriggerProgression(pID);
    }
}
