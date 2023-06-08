using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EventIndicator))]
public class DialogueSwitch : MonoBehaviour
{
    [SerializeField]
    private SODialogue switchDialogue;
    
    public void SwitchDialogue()
    {
        if (switchDialogue != null)
        {
            switchDialogue.parentAgent = GetComponent<AEventAgent>();
            switchDialogue.XPTriggered = false;
            GetComponent<AEventAgent>().SetDialogue(switchDialogue);
        }
    }
}
