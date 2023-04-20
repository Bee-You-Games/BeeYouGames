using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpamTapping : MonoBehaviour
{
    [SerializeField][Range(0, 100)]
    private int tapAmount = 10;
    [SerializeField][Range(0, 100)][Tooltip("Time in seconds")]
    private int tapTime = 10;
    [SerializeField]
    private Button buttonPrefab;

    private Canvas canvas;
    private GameObject canvasObj;

    private int currentTapAmount = 0;

    private void Start()
    {
        currentTapAmount = 0;
    }

    public void StartTapping()
    {
        HandleTapping();
    }

    public void EndTapping()
    {
        buttonPrefab.onClick.RemoveListener(AddTap);
        Destroy(canvasObj);
    }

    private void AddTap()
    {
        if (currentTapAmount < tapAmount)
            currentTapAmount++;
        else
            StopCoroutine(TapTimer());
    }

    private void InitObjects()
    {
        if (canvasObj != null) return;

        canvasObj = new GameObject("Canvas");
        canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObj.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasObj.AddComponent<GraphicRaycaster>();


        GameObject tapButton = Instantiate(buttonPrefab.gameObject) as GameObject;
        buttonPrefab.onClick.AddListener(AddTap);
        tapButton.transform.SetParent(canvas.transform);
    }

    private void HandleTapping()
    {
        InitObjects();
        StartCoroutine(TapTimer());
    }

    private IEnumerator TapTimer()
    {
        while (currentTapAmount < tapAmount)
        {
            yield return new WaitForSeconds(1);
        }
    }
}
