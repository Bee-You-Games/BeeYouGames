using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;

public class InkManager : MonoBehaviour
{
    private SODialogue dialogue;
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private Button choiceButtonPrefab;
    [SerializeField]
    private Transform choiceButtonParent;
    [SerializeField]
    private Image playerImage, npcImage;

    private Story story;

    private GameObject npcObj;

    public bool IsDialogueActive = false;

    private const string TEST_TAG = "testTag";
    private const string SPEAKER_TAG = "speaker";
    private const string EMOTION_TAG = "emotion";
    private const string LOCKED_BTNTAG = "locked";
    private const string XP_TAG = "xp";

    private const string PLAYER_ID = "A";
    private const string NPC_ID = "B";


    public static InkManager Instance { get; private set; }

    private int currentSenderID = 0;
    private int currentReceiverID = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("Multiple instances of InkManager have been found", this);

        gameObject.SetActive(false);
    }

    public void DialogueClick()
    {
        if (story.currentChoices.Count == 0)
            UpdateDialogueText();
        else
            return;
    }

    public void UpdateDialogueText()
    {
        if (story == null) return;

        Debug.Log("Updating text");
        EraseUI();

        string text = GetDialogueText();
        if (text == "")
        {
            EndDialogue();
            return;
        }
        
        Debug.Log("Calling HandleTextTags method");
        HandleTextTags();

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
        else if (story.currentChoices.Count == 0)
        {
            text = story.Continue();
            if (text == "")
                EndDialogue();
        }
        return text;
    }

    private void InstantiateChoiceButtons()
    {
        if(story.currentChoices.Count == 0)
            return;

        foreach (Choice choice in story.currentChoices)
        {
            Button button = Instantiate(choiceButtonPrefab) as Button;
            TextMeshProUGUI tmProText = button.GetComponentInChildren<TextMeshProUGUI>();
            tmProText.text = HandleButtonTag(choice.text, button, choice);
            button.transform.SetParent(choiceButtonParent, false);
        }
    }

    private void HandleTextTags()
    {
        string speakerID = NPC_ID;
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
                    speakerID = GetSpeakerTagValue(tag);
                    SetName(speakerID);
                    break;
                case EMOTION_TAG:
                    SetEmotion(speakerID, GetEmotionTagValue(tag));
                    break;
                case XP_TAG:
                    if(dialogue.XPTriggered == false){
                        dialogue.XPTriggered = true;
                        ExperienceManager.Instance.AddExperience((GetXPTagValue(tag)));
                    }
                    else
                        Debug.Log("XP reward already triggered for this dialogue");
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
    
    private string GetEmotionTagValue(string pTag)
    {
        if (pTag.Contains("emotion"))
        {
            string[] speakerTagContent = pTag.Split(':');

            if (speakerTagContent.Length != 2) Debug.LogError("Emotion tag can't be read", this);

            return speakerTagContent[1];
        }
        else
        {
            Debug.LogError("Given tag isn't an emotion tag", this);
            return "Given tag isn't an emotion tag";
        } 
    }

    private int GetXPTagValue(string pTag)
    {
        if (pTag.Contains("xp"))
        {
            string[] xpTagContent = pTag.Split(':');

            if (xpTagContent.Length != 2) Debug.LogError("XP tag can't be read", this);

            return int.Parse(xpTagContent[1]);
        }
        else
        {
            Debug.LogError("Given tag isn't an XP tag", this);
            return 0;
        }
    }
    

    /// <summary>
    /// A is the player character, B is the character they're talking to
    /// </summary>
    /// <param name="pSpeakerID"></param>
    private void SetName(string pSpeakerID)
    {
        if (pSpeakerID == PLAYER_ID)
        {
            nameText.text = dialogue.CharacterAName;
        }
        else if (pSpeakerID == NPC_ID)
        {
            nameText.text = dialogue.CharacterBName;
        }
    }

    private void SetEmotion(string pSpeakerID, string emotion)
    {
        if (pSpeakerID == PLAYER_ID)
        {
            playerImage.sprite = dialogue.CharacterASprite.GetSprite(emotion);
        }
        else if (pSpeakerID == NPC_ID)
        {
            npcImage.sprite = dialogue.CharacterBSprite.GetSprite(emotion);
        }
    }

    private void PortraitSetup()
    {
        playerImage.sprite = dialogue.CharacterASprite.GetSprite("neutral");
        npcImage.sprite = dialogue.CharacterBSprite.GetSprite("neutral");
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

    public void StartDialogue(SODialogue pDialogueFile, GameObject pNPCObj, int receiverID = 0, int senderID = 0)
    {
        npcObj = pNPCObj;
        currentReceiverID = receiverID;
        currentSenderID = senderID;
        dialogue = pDialogueFile;
        story = new Story(pDialogueFile.DialogueFile.text);

        DialogueVariablesSetup();
        PortraitSetup();

        gameObject.SetActive(true);
        IsDialogueActive = true;
        UpdateDialogueText();

        GameStateManager.Instance.SetState(GameState.Dialogue);
    }

    public void EndDialogue()
    {
        
        Debug.Log("Ending dialogue");
        EraseUI();
        gameObject.SetActive(false);
        IsDialogueActive = false;
        
        UnbindExternalFunctions();

        currentReceiverID = 0;
        currentSenderID = 0;
        GameStateManager.Instance.SetState(GameState.Gameplay);
        dialogue = null;
    }

    private void UnbindExternalFunctions(){
        if (currentSenderID != 0)
            story.UnbindExternalFunction("ProgressionEvent");
        
        /*  For some ungodly reason, this if statement line is causing a null reference exception
        I debugged it, and dialogue isn't null here so I have no idea what's going on

        if (dialogue.triggerDialogueSuccess)
            story.UnbindExternalFunction("DialogueSuccess");
        */

        if (npcObj.GetComponent<BossHealth>() != null)
            story.UnbindExternalFunction("BossDamage");
    }

    public void SwitchDialogue(SODialogue pDialogueFile)
    {
        UnbindExternalFunctions();

        Debug.Log("Switching dialogue");
        dialogue = pDialogueFile;
        story = new Story(pDialogueFile.DialogueFile.text);
        DialogueVariablesSetup();
        PortraitSetup();
        //UpdateDialogueText();

    }
    

    private void DialogueVariablesSetup()
    {
        //TEMPORARY FIX
        dialogue.XPTriggered = false;

        if (dialogue.triggerDialogueSuccess)
            story.BindExternalFunction("DialogueSuccess", () => { dialogue.parentAgent.DialogueSuccess(); });

        if (currentReceiverID != 0)
        {
            ChangeInkVariable("progress", ProgressionCheck(currentReceiverID));
        }
        if (currentSenderID != 0)
        {
            story.BindExternalFunction("ProgressionEvent", () => { ProgressionEvent(); });
        }

        if(npcObj.GetComponent<BossHealth>() != null)
            story.BindExternalFunction("BossDamage", (int pDamage) => { BossDamage(pDamage); });
    }

    private void BossDamage(int pDamage)
    {
        if (npcObj == null)
        {
            Debug.LogError("npcObj is NULL", this);
            return;
        }

        BossHealth health = npcObj.GetComponent<BossHealth>();

        if (health == null)
        {
            Debug.LogError("bossHealth is NULL", this);
            return;
        }

        health.DealDamage(pDamage);
    }

    public bool ProgressionCheck(int pID)
    {
        return EventManager.Instance.ProgressionCheck(pID);
    }

    public void ProgressionEvent()
    {
        EventManager.Instance.TriggerProgression(currentSenderID);
    }
}
