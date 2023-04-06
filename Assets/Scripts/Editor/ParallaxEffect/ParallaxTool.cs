using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using System.Linq;
using UnityEditor.UIElements;
using System;

public class ParallaxTool : EditorWindow
{
    private SerializedObject so;
    private SerializedProperty spritesProperty;
    private SerializedProperty propLayerList;

    private List<ParallaxEffect> parallaxLayers = new List<ParallaxEffect>();

    private Transform spawnPos;
    private GUIContent content = new GUIContent("editSpace");
    private ListView leftPane;
    private VisualElement rightPane;
    private ParallaxEffect currentSelection;

    private const string LAYER_TAG = "ParallaxLayer";

    [MenuItem("Tools/Parallax Effect")]
    public static void ShowWindow()
    {
        GetWindow<ParallaxTool>("Parallax Effect");
    }

    private void OnEnable()
    {
        so = new SerializedObject(this);
        propLayerList = so.FindProperty("parallaxLayers");

        EditorApplication.playModeStateChanged += ModeChanged;

        SetUpControls();
    }

    private void OnDisable()
    {
        EditorApplication.playModeStateChanged -= ModeChanged;
    }

    public void CreateGUI()
    {
        TwoPaneSplitView topBotSplit = new TwoPaneSplitView(0, 250, TwoPaneSplitViewOrientation.Horizontal);
        leftPane = new ListView();
        rightPane = new VisualElement();

        topBotSplit.Add(leftPane);
        topBotSplit.Add(rightPane);

        rootVisualElement.Add(topBotSplit);

        UpdateListView();
    }

    private void ModeChanged(PlayModeStateChange pState)
    {
        switch (pState)
        {
            //case PlayModeStateChange.EnteredEditMode:
            //    //leftPane.ClearSelection();
            //    rightPane.Clear();
            //    UpdateListView();
            //    break;
            //case PlayModeStateChange.EnteredPlayMode:
            //    //leftPane.ClearSelection();
            //    rightPane.Clear();
            //    UpdateListView();
            //    break;
            //case PlayModeStateChange.ExitingEditMode:
            //    //leftPane.ClearSelection();
            //    rightPane.Clear();
            //    UpdateListView();
            //    break;
            case PlayModeStateChange.ExitingPlayMode:
                leftPane.Rebuild();
                //leftPane.Clear();
                //leftPane.ClearSelection();
                //rightPane.Clear();
                //UpdateListView();
                break;
        }
    }

    private void SetUpControls()
    {
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>
               ("Assets/Scripts/Editor/ParallaxEffect/parallaxEffectTool.uxml");
        VisualElement rootFromUXML = visualTree.Instantiate();
        rootVisualElement.Add(rootFromUXML);

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>
            ("Assets/Scripts/Editor/ParallaxEffect/parallaxEffectTool.uss");
        rootVisualElement.styleSheets.Add(styleSheet);

        Button AddButton = rootVisualElement.Q<Button>("AddButton");
        Button RemoveButton = rootVisualElement.Q<Button>("RemoveButton");
        Button DeleteListButton = rootVisualElement.Q<Button>("ListDeleteBtn");

        AddButton.clickable.clicked += AddToList;
        RemoveButton.clickable.clicked += HandleRemoveButton;
        DeleteListButton.clickable.clicked += DeleteEntireList;
    }

    private void AddToList()
    {
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
        GameObject obj = new GameObject();
        obj.name = "Parallax Layer " + parallaxLayers.Count;
        obj.transform.tag = LAYER_TAG;
        SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>();
        ParallaxEffect parEffect = obj.AddComponent<ParallaxEffect>();

        parallaxLayers.Add(parEffect);
        parEffect.OnDestruction += RemoveFromList;

        renderer.sprite = pSprite;
        renderer.sortingOrder = pLayer;

        parEffect.Speed = pSpeed;
        parEffect.isRepeating = pRepeatable;
        parEffect.isRepeatingRandom = pRandom;

        so.Update();
        leftPane.onSelectionChange += OnItemSelectionChange;
    }

    private void DeleteEntireList()
    {
        if (parallaxLayers.Count <= 0) return;

        foreach (ParallaxEffect effect in parallaxLayers)
        {
            effect.OnDestruction -= RemoveFromList;
            if(effect != null)
                DestroyImmediate(effect.gameObject);
        }

        parallaxLayers.Clear();
        parallaxLayers.TrimExcess();
        so.Update();
        
        rightPane.Clear();
        UpdateListView();
    }

    private void HandleRemoveButton()
    {
        if (currentSelection == null) return;
        RemoveFromList(currentSelection);
    }

    private void RemoveFromList(ParallaxEffect pParEffect)
    {
        parallaxLayers.Remove(pParEffect);
        parallaxLayers.TrimExcess();
        so.Update();
        pParEffect.OnDestruction -= RemoveFromList;
        DestroyImmediate(pParEffect.gameObject);
        UpdateListView();
        rightPane.Clear();
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
            rightPane.Clear();
            leftPane.itemsSource = listObjects;
        }
    }

    private void OnItemSelectionChange(IEnumerable<object> pSelection)
    {
        rightPane.Clear();

        ParallaxEffect selectedItem = pSelection.First() as ParallaxEffect;
        currentSelection = selectedItem;
        if (selectedItem == null) return;

        InitVariables(selectedItem);
    }

    private void InitVariables(ParallaxEffect pEffect)
    {
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
        SpriteRenderer renderer = pEffect.transform.GetComponent<SpriteRenderer>();
        if (renderer == null) Debug.LogError("SpriteRenderer component not found, are you sure the Transform contains a SpriteRenderer component", this);

        renderer.sprite = pObjField.value as Sprite;
        renderer.sortingOrder = pLayer.value;

        pEffect.Speed = pSpeed.value;
        pEffect.isRepeating = pRepeat.value;
        pEffect.isRepeatingRandom = pRandom.value;
    }
}
