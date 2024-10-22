using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class SpamTapping : MonoBehaviour, ITapping, IInteractable
{
    [SerializeField]
    [Range(1, 1000)]
    private int tapGoal = 10;
    [SerializeField]
    private GameObject UIPanel;
    [SerializeField]
    private string prompt;

    private int currentTaps = 0;

    private float mash;
    private bool hasStarted;

    public UnityEvent OnComplete;
    public UnityEvent OnFailure;

    public string Prompt => prompt;

    public bool Available { get; set; }
    public bool IsComplete { get; private set; }

    private void Start()
    {
        Available = true;
        UIPanel.SetActive(false);
        currentTaps = 0;
    }

    private void Update()
    {
        if (hasStarted)
            HandleTappping();
    }

    public void StartTapping()
    {
        UIPanel.SetActive(true);
        hasStarted = true;
    }

    public void HandleTappping()
    {
        if (IsComplete) return;

        if (Input.GetMouseButtonDown(0))
        {
            currentTaps++;
            CheckTaps();
        }
    }

    public bool CheckTaps()
    {
        if (currentTaps >= tapGoal)
        {
            currentTaps = tapGoal;
            OnComplete.Invoke();
            IsComplete = true;
            hasStarted = false;
            Destroy(this.gameObject);
            return true;
        }
        else
            return false;
    }

    public bool Interact(PlayerInteractor interactor)
    {
        if (!IsComplete)
        {
            StartTapping();
            return true;
        }
        else
            return false;
    }
}
