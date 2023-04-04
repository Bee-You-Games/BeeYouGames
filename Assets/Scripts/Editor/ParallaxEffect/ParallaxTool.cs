using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using System.Linq;
using UnityEditor.UIElements;

public class ParallaxTool : EditorWindow
{
    private SerializedObject so;
    private SerializedProperty spritesProperty;
    private SerializedProperty propLayerList;

    private Transform spawnPos;
    private List<GameObject> parallaxLayers = new List<GameObject>();

    private GUIContent content = new GUIContent("editSpace");
    private ListView leftPane;
    private VisualElement rightPane;

    private float layoutHeight;

    public Sprite[] sprites;

    

    [MenuItem("Tools/Parallax Effect")]
    public static void ShowWindow()
    {
        GetWindow<ParallaxTool>("Parallax Effect");
    }

    private void OnEnable()
    {
        so = new SerializedObject(this);
        spritesProperty = so.FindProperty("sprites");
        propLayerList = so.FindProperty("parallaxLayers");
        SetUpControls();
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
        parallaxLayers.Add(obj);
        obj.name = "Parallax Layer " + parallaxLayers.Count;
        SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>();
        ParallaxEffect parEffect = obj.AddComponent<ParallaxEffect>();

        parEffect.OnDestruction += RemoveFromList;

        renderer.sprite = pSprite;
        renderer.sortingOrder = pLayer;

        parEffect.Speed = pSpeed;
        parEffect.isRepeating = pRepeatable;
        parEffect.isRepeatingRandom = pRandom;

        so.Update();
    }

    private void DeleteEntireList()
    {
        Debug.Log("Deleting Layers");
        parallaxLayers.Clear();
        parallaxLayers.TrimExcess();
        UpdateListView();
    }

    private void HandleRemoveButton()
    {
        
    }

    private void RemoveFromList(ParallaxEffect pParEffect)
    {
        parallaxLayers.Remove(pParEffect.gameObject);
        so.Update();
        pParEffect.OnDestruction -= RemoveFromList;
        UpdateListView();
    }

    private void UpdateListView()
    {
        Debug.Log("Updating List view");
        GameObject[] listObjects = parallaxLayers.ToArray();

        if (listObjects.Length > 0)
        {
            leftPane.makeItem = () => new Label();
            leftPane.bindItem = (item, index) => { (item as Label).text = listObjects[index].name; };
            leftPane.itemsSource = listObjects;
        }
        else
            leftPane.itemsSource = listObjects;
    }

    
}
