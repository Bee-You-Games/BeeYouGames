using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class EventIndicator : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private bool showLines = true;
    private AEventAgent eventAgent;
    private AEventAgent[] agents;

    private void Start()
    {
        eventAgent = GetComponent<AEventAgent>();

        if (eventAgent == null)
            Debug.LogError("eventAgent is NULL", this);

        agents = (AEventAgent[]) GameObject.FindObjectsOfType(typeof(AEventAgent));
    }

    private void OnDrawGizmosSelected()
    {
        if (!showLines) return;

        Gizmos.color = Color.red;

        if (agents.Length <= 0) return;

        List<AEventAgent> agentObjs = new List<AEventAgent>();

        for (int i = 0; i < agents.Length; i++)
        {
            AEventAgent agent = agents[i];
            if (agent.GetSenderID() == eventAgent.GetReceiverID() ||
                agent.GetReceiverID() == eventAgent.GetSenderID())
                agentObjs.Add(agent);
        }

        if (agentObjs.Count <= 0) return;

        foreach (AEventAgent agent in agentObjs)
        {
            Gizmos.DrawLine(transform.position, agent.transform.position);
        }
    }
#endif
}
