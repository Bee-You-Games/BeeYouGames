using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    public NPC parentNPC;
    public TextAsset DialogueFile;
    public string CharacterAName;
    public Sprite CharacterASprite;
    public string CharacterBName;
    public Sprite CharacterBSprite;
}
