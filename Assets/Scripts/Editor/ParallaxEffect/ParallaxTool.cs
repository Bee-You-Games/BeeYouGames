using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using System.Linq;
using UnityEditor.UIElements;
using System;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using PopupWindow = UnityEditor.PopupWindow;

public class ParallaxTool : EditorWindow
{
    private SerializedObject so;
    private SerializedProperty spritesProperty;
    private SerializedProperty propLayerList;

    private List<ParallaxEffect> parallaxLayers = new List<ParallaxEffect>();

    private Transform spawnPos;
    private GUIContent content = new GUIContent("editSpace");
    private TwoPaneSplitView topBotSplit;
    private ListView leftPane;
    private VisualElement rightPane;
    private ParallaxEffect currentSelection;
    private GameObject layerParent = null;

    private const string LAYER_TAG = "ParallaxLayer";

    [MenuItem("Tools/Parallax Effect")]
    public static void ShowWindow()
    {
        GetWindow<ParallaxTool>("Parallax Effect");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
        so = new SerializedObject(this);
        propLayerList = so.FindProperty("parallaxLayers");

        EditorApplication.playModeStateChanged += ModeChanged;
        SetUpControls();
        EditorSceneManager.activeSceneChangedInEditMode += ChangeLayerList;
        LoadLayers();
        
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
        EditorApplication.playModeStateChanged -= ModeChanged;
        EditorSceneManager.activeSceneChangedInEditMode -= ChangeLayerList;
    }

    public void CreateGUI()
    {
        Debug.Log("Creating GUI");
        InitGUI();
    }

    private void ChangeLayerList(Scene pCurrent, Scene pNext)
    {
        Debug.Log("Changing scene from " + pCurrent.name + " to " + pNext.name);
        LoadLayers();
    }

    private void InitGUI()
    {
        Debug.Log("InitGUI");
        topBotSplit = new TwoPaneSplitView(0, 250, TwoPaneSplitViewOrientation.Horizontal);
        leftPane = new ListView();
        rightPane = new VisualElement();

        topBotSplit.Add(leftPane);
        topBotSplit.Add(rightPane);

        rootVisualElement.Add(topBotSplit);

        leftPane.onSelectionChange += OnItemSelectionChange;
        
        UpdateListView();
    }

    private void ReloadGUI()
    {
        Debug.Log("Reloading GUI");
        leftPane.onSelectionChange -= OnItemSelectionChange;
        rootVisualElement.Remove(topBotSplit);
    }

    private void ModeChanged(PlayModeStateChange pState)
    {
        Debug.Log("ModeChanged");
        switch (pState)
        {
            case PlayModeStateChange.EnteredEditMode:
                LoadLayers();
                break;
            case PlayModeStateChange.EnteredPlayMode:
                LoadLayers();
                break;
            case PlayModeStateChange.ExitingEditMode:
                break;
            case PlayModeStateChange.ExitingPlayMode:
                break;
        }
    }

    private void LoadLayers()
    {
        Debug.Log("Loading Layers");
        if (leftPane != null)
            leftPane.onSelectionChange -= OnItemSelectionChange;

        GameObject[] layers = GameObject.FindGameObjectsWithTag(LAYER_TAG);

        if (layers == null) return;
        if (layers.Length == 0)
        {
            Debug.Log("No layers were found", this);
            parallaxLayers.Clear();
            parallaxLayers.TrimExcess();
            so.Update();
            UpdateListView();
            return;
        }

        Debug.Log("Gets here " + layers.Length);

        ParallaxEffect[] parLayers = new ParallaxEffect[layers.Length];

        parallaxLayers.Clear();
        parallaxLayers.TrimExcess();

        for (int i = 0; i < layers.Length; i++)
        {
            Debug.Log("Has Parallax Effect: " + layers[i].GetComponent<ParallaxEffect>());
            ParallaxEffect effect = layers[i].GetComponent<ParallaxEffect>();

            if (effect == null)
                Debug.LogError("Parallax effect is NULL, index of effect is: " + i, this);
            else
                parLayers[i] = effect;
        }

        parallaxLayers = parLayers.ToList();
        parallaxLayers.Reverse();
        so.Update();

        if (leftPane != null)
        {
            UpdateListView();
            leftPane.onSelectionChange += OnItemSelectionChange;
            Debug.Log("Updated listview after loading layers");
        }
    }

    private void SetUpControls()
    {
        Debug.Log("Set up controls");
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>
               ("Assets/Scripts/Editor/ParallaxEffect/parallaxEffectTool.uxml");
        VisualElement rootFromUXML = visualTree.Instantiate();
        rootVisualElement.Add(rootFromUXML);

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>
            ("Assets/Scripts/Editor/ParallaxEffect/parallaxEffectTool.uss");
        rootVisualElement.styleSheets.Add(styleSheet);

        SetUpButtons();
    }

    private void SetUpButtons()
    {
        Debug.Log("SetUpButtons");
        Button AddButton = rootVisualElement.Q<Button>("AddButton");
        Button RemoveButton = rootVisualElement.Q<Button>("RemoveButton");
        Button DeleteListButton = rootVisualElement.Q<Button>("ListDeleteBtn");
        Button LoadLayersButton = rootVisualElement.Q<Button>("LoadLayerBtn");

        AddButton.clickable.clicked += AddToList;
        RemoveButton.clickable.clicked += HandleRemoveButton;
        LoadLayersButton.clickable.clicked += LoadLayers;

        Debug.Log("Subscribe to delete list button");
        DeleteListButton.clickable.clicked += delegate { SubscribePopupEvents(DeleteListButton); };
    }

    private void SubscribePopupEvents(Button pButton)
    {
        Debug.Log("Opening window");
        var popupWindow = new ConfirmDelete();
        popupWindow.OnConfirm += DeleteEntireList;
        popupWindow.OnCancel += CloseWindow;
        popupWindow.OnCloseWindow += UnSubscribePopupEvents;
        
        PopupWindow.Show(pButton.worldBound, popupWindow);
    }

    private void UnSubscribePopupEvents(ConfirmDelete pWindow)
    {
        pWindow.OnConfirm -= DeleteEntireList;
        pWindow.OnCancel -= CloseWindow;
        pWindow.OnCloseWindow -= UnSubscribePopupEvents;
    }

    private void CloseWindow(ConfirmDelete pWindow)
    {
        Debug.Log("Closing Window");
        pWindow.editorWindow.Close();
    }

    private void AddToList()
    {
        Debug.Log("Add to list");
        ObjectField objField = rootVisualElement.Q<ObjectField>("SpriteField");
        IntegerField layerField = rootVisualElement.Q<IntegerField>("LayerField");
        Slider speedField = rootVisualElement.Q<Slider>("SpeedField");
        Toggle repeatToggle = rootVisualElement.Q<Toggle>("RepeatableToggle");
        Toggle randomToggle = rootVisualElement.Q<Toggle>("RandomToggle");

        objField.objectType = typeof(Sprite);
        Sprite sprite = (Sprite)objField.value;

        int layer = layerField.value;

        float speed = speedField.value;

        bool isRepeatable = repeatToggle.value;
        
        bool isRandom = randomToggle.value;

        CreateObj(sprite, layer, speed, isRepeatable, isRandom);
        UpdateListView();
    }

    private void CreateObj(Sprite pSprite, int pLayer, float pSpeed, bool pRepeatable, bool pRandom)
    {
        if (layerParent == null)
            layerParent = new GameObject("Parallax Layers");

        Debug.Log("Creating object");
        GameObject obj = new GameObject();

        if (pSprite != null)
            obj.name = pSprite.name;
        else
            obj.name = "Parallax Layer " + parallaxLayers.Count;

        obj.transform.SetParent(layerParent.transform);
        obj.transform.tag = LAYER_TAG;
        SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>();
        ParallaxEffect parEffect = obj.AddComponent<ParallaxEffect>();

        parallaxLayers.Add(parEffect);
        parEffect.OnDestruction += LayerOnDestroy;

        renderer.sprite = pSprite;
        renderer.sortingOrder = pLayer;

        parEffect.Speed = pSpeed;
        parEffect.isRepeating = pRepeatable;
        parEffect.isRepeatingRandom = pRandom;

        so.Update();
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    private void DeleteEntireList(ConfirmDelete pWindow)
    {
        Debug.Log("Deleting List");
        if (parallaxLayers.Count <= 0) return;

        Debug.Log(layerParent == null);
        DestroyImmediate(layerParent);
        layerParent = null;

        foreach (ParallaxEffect effect in parallaxLayers)
        {
            Debug.Log(effect);
            if (effect != null)
            {
                effect.OnDestruction -= LayerOnDestroy;
                DestroyImmediate(effect.gameObject);
            }
        }


        parallaxLayers.Clear();
        parallaxLayers.TrimExcess();
        so.Update();
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        rightPane.Clear();
        pWindow.editorWindow.Close();
        UpdateListView();
    }

    private void HandleRemoveButton()
    {
        Debug.Log("Handle Remove Button");
        if (currentSelection == null) return;
        RemoveFromList(currentSelection);
    }

    private void RemoveFromList(ParallaxEffect pParEffect)
    {
        Debug.Log("Removing from list");
        parallaxLayers.Remove(pParEffect);
        parallaxLayers.TrimExcess();
        so.Update();
        pParEffect.OnDestruction -= LayerOnDestroy;

        DestroyImmediate(pParEffect.gameObject);

        UpdateListView();
        rightPane.Clear();
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    private void LayerOnDestroy(ParallaxEffect pParEffect)
    {
        Debug.Log("Removing from list");
        parallaxLayers.Remove(pParEffect);
        parallaxLayers.TrimExcess();
        so.Update();
        pParEffect.OnDestruction -= LayerOnDestroy;
        
        UpdateListView();
        rightPane.Clear();
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    private void UpdateListView()
    {
        Debug.Log("Updating List view");
        ParallaxEffect[] listObjects = parallaxLayers.ToArray();

        if (listObjects.Length > 0)
        {
            leftPane.makeItem = () => new Label();
            leftPane.bindItem = (item, index) => 
            {
                if((index <= listObjects.Length - 1) && listObjects[index] != null)
                    (item as Label).text = listObjects[index].name;
            };
            leftPane.itemsSource = listObjects;
        }
        else
        {
            Debug.Log("listObjects is empty");
            if(rightPane != null)
                rightPane.Clear();

            if(leftPane != null)
                leftPane.itemsSource = listObjects;
        }
    }

    private void OnItemSelectionChange(IEnumerable<object> pSelection)
    {
        Debug.Log("Showing selection");
        Debug.Log("Selection Layers thing: " + (pSelection.First() as ParallaxEffect));

        rightPane.Clear();

        ParallaxEffect selectedItem = pSelection.First() as ParallaxEffect;
        Debug.Log("Selected Item = " + selectedItem);
        currentSelection = selectedItem;
        if (selectedItem == null) return;

        InitVariables(selectedItem);
    }

    private void InitVariables(ParallaxEffect pEffect)
    {
        Debug.Log("Initializing variables");
        ObjectField spriteField = new ObjectField();
        spriteField.label = "Sprite";
        spriteField.objectType = typeof(Sprite);
        spriteField.value = pEffect.GetComponent<SpriteRenderer>().sprite;

        IntegerField layerField = new IntegerField();
        layerField.label = "Layer";
        layerField.value = pEffect.GetComponent<SpriteRenderer>().sortingOrder;

        Slider speedField = new Slider();
        speedField.label = "Speed";
        speedField.showInputField = true;
        speedField.value = pEffect.Speed;

        Toggle repeatToggle = new Toggle();
        repeatToggle.label = "Repeatable";
        repeatToggle.value = pEffect.isRepeating;

        Toggle randomToggle = new Toggle();
        randomToggle.label = "Repeat Random";
        randomToggle.value = pEffect.isRepeatingRandom;
        if(randomToggle.value)
            Debug.LogWarning("Repeat Random doesn't work yet. Enabling or disabling doesn't change anything", this);

        Button updateButton = new Button();
        updateButton.text = "Update Values";
        updateButton.clickable.clicked += delegate { UpdateVariables(pEffect, spriteField, layerField, speedField, repeatToggle, randomToggle); };

        rightPane.Add(spriteField);
        rightPane.Add(layerField);
        rightPane.Add(speedField);
        rightPane.Add(repeatToggle);
        rightPane.Add(randomToggle);
        rightPane.Add(updateButton);
    }

    private void UpdateVariables(ParallaxEffect pEffect, ObjectField pObjField, IntegerField pLayer, Slider pSpeed, Toggle pRepeat, Toggle pRandom)
    {
        Debug.Log("Updating variable");
        SpriteRenderer renderer = pEffect.transform.GetComponent<SpriteRenderer>();
        if (renderer == null) Debug.LogError("SpriteRenderer component not found, are you sure the Transform contains a SpriteRenderer component", this);

        renderer.sprite = pObjField.value as Sprite;
        renderer.sortingOrder = pLayer.value;

        pEffect.Speed = pSpeed.value;
        pEffect.isRepeating = pRepeat.value;
        pEffect.isRepeatingRandom = pRandom.value;
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
}
