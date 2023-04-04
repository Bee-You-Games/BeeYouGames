using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Parallax Tool", menuName = "ParallaxTool/SaveFile")]
public class ParallaxToolSO : ScriptableObject
{
    public List<Sprite> sprites = new List<Sprite>();
}
