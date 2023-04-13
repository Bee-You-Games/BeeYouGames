using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using System;

public class ConfirmDelete : PopupWindowContent
{
    public event Action<ConfirmDelete> OnConfirm;
    public event Action<ConfirmDelete> OnCancel;
    public event Action<ConfirmDelete> OnCloseWindow;

    public override Vector2 GetWindowSize()
    {
        return new Vector2(200, 100);
    }

    public override void OnGUI(Rect rect)
    {
    }

    public override void OnOpen()
    {
        Debug.Log("Popup opened");

        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/Editor/ParallaxEffect/PopupWindow/PopupWindow.uxml");
        visualTree.CloneTree(editorWindow.rootVisualElement);

        Button confirmButton = editorWindow.rootVisualElement.Q<Button>("YesBtn");
        Button cancelButton = editorWindow.rootVisualElement.Q<Button>("NoBtn");

        confirmButton.clickable.clicked += () => OnConfirm?.Invoke(this);
        cancelButton.clickable.clicked += () => OnCancel?.Invoke(this);
    }

    public override void OnClose()
    {
        Debug.Log("Popup closed");
        OnCloseWindow?.Invoke(this);
    }
}
