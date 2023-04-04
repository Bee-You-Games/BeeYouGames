using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ParallaxEffect))]
public class ParallaxEditor : Editor
{
    private ParallaxEffect pe;

    private void OnEnable()
    {
        pe = (ParallaxEffect)target;
    }

    private void OnDestroy()
    {
        if (Application.isEditor)
        {
            if ((ParallaxEffect)target == null)
            {
                
            }
                
        }
    }
}
