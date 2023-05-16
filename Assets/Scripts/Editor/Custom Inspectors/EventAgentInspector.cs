using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NPC))]
public class EventAgentInspector : Editor
{
    private SerializedProperty propRole;

    private AEventAgent.Role actorRole;
    private int senderID = 0;
    private int receiverID = 0;
    private bool progressedState = false;
    private string prompt;
    private SODialogue NPCDialogue;

    private void OnEnable()
    {
        propRole = serializedObject.FindProperty("actorRole");
    }

    public override void OnInspectorGUI()
    {
        NPC npc = (NPC) target;
        
        GUILayout.Label("Event Agent Settings", EditorStyles.boldLabel);
        actorRole = EditorGUILayout.PropertyField(propRole);

    }
}
