using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NPC))]
public class EventAgentInspector : Editor
{
    private SerializedProperty propDialogueSuccessEvent;
    private SerializedProperty propNPCDialogue;
    private SerializedProperty propActorRole;
    private SerializedProperty propSenderID;
    private SerializedProperty propReceiverID;
    private SerializedProperty propPromt;

    private void OnEnable()
    {
        propDialogueSuccessEvent = serializedObject.FindProperty("dialogueSuccessEvent");
        propNPCDialogue = serializedObject.FindProperty("NPCDialogue");
        propActorRole = serializedObject.FindProperty("actorRole");
        propSenderID = serializedObject.FindProperty("senderID");
        propReceiverID = serializedObject.FindProperty("receiverID");
        propPromt = serializedObject.FindProperty("prompt");
    }

    public override void OnInspectorGUI()
    {
        NPC npc = (NPC) target;
        serializedObject.Update();
        
        GUILayout.Label("Event Agent Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(propActorRole);
        
        switch ((AEventAgent.Role)propActorRole.enumValueIndex)
        {
            case AEventAgent.Role.Both:
                EditorGUILayout.PropertyField(propReceiverID);
                EditorGUILayout.PropertyField(propSenderID);
                break;
            case AEventAgent.Role.Receiver:
                EditorGUILayout.PropertyField(propReceiverID);
                propSenderID.intValue = 0;
                break;
            case AEventAgent.Role.Sender:
                EditorGUILayout.PropertyField(propSenderID);
                propReceiverID.intValue = 0;
                break;
            case AEventAgent.Role.Neither:
                propReceiverID.intValue = 0;
                propSenderID.intValue = 0;

                break;
        }
        
        EditorGUILayout.PropertyField(propDialogueSuccessEvent);

        GUILayout.Space(20f);
        GUILayout.Label("NPC Settings", EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(propPromt);
        EditorGUILayout.PropertyField(propNPCDialogue);

        serializedObject.ApplyModifiedProperties();
    }
}
