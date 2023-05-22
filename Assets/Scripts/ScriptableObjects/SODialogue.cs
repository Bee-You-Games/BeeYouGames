using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class SODialogue : ScriptableObject
{
    [HideInInspector]
    public AEventAgent parentAgent;
    [Tooltip("Enable this if DialogueSuccess from EventAgent should be called in the agent's dialogue")]
    public bool triggerDialogueSuccess = false;
    public TextAsset DialogueFile;
    public string CharacterAName;
    public SpriteAtlas CharacterASprite;
    public string CharacterBName;
    public SpriteAtlas CharacterBSprite;
}
