using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class SpamTapping : MonoBehaviour, ITapping, IInteractable
{
    //[SerializeField][Range(0f, 10f)]
    //private float mashDelay = 0.5f;
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
        //mash = mashDelay;
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
        //mash -= Time.deltaTime;
        if (IsComplete) return;

        if (Input.GetMouseButtonDown(0))
        {
            //mash = mashDelay;
            currentTaps++;
            CheckTaps();
        }

        if (mash <= 0)
        {
            //OnFailure.Invoke();
            //Debug.Log("Mashing failed");
            //currentTaps = 0;
        }
    }

    public bool CheckTaps()
    {
        if (currentTaps >= tapGoal)
        {
            Debug.Log("Reached tap goal");
            currentTaps = tapGoal;
            OnComplete.Invoke();
            IsComplete = true;
            hasStarted = false;
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
