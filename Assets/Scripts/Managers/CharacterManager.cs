using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;


public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private SpriteAtlas atlas;
    private string spriteName;
    public static CharacterManager Instance;
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("Multiple instances of CharacterManager have been found", this);
    }

    void Update()
    {
        
    }

    public Sprite GetSprite(string name, string emotion)
    {
        return atlas.GetSprite(name + "_" + emotion);
    }
}
