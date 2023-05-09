using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ConvertToSprite : EditorWindow
{
    private const string textureType = "t:Texture2D";
    private string path = "Assets/Resources/Sprites";

    [MenuItem("Tools/Image To Sprite")]
    public static void ShowWindow()
    {
        GetWindow<ConvertToSprite>("Image to Sprite Converter");
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        GUILayout.Label("Texture2D to Sprite Converter");

        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        GUILayout.Space(5);

        GUILayout.Label("Current folder path:\n" + path);

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        if (GUILayout.Button(new GUIContent("Change Folder", "Change the folder where the images will get converted to sprites"), GUILayout.Width(100), GUILayout.Height(30)))
            SetFolderPath();

        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
        GUILayout.Space(5);

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button(new GUIContent("Convert", "Force convert images to sprites in folder: '" + path +
            "'\nOnly use this if something went wrong. It can take a very long time before it's done converting everything"),
            GUILayout.Width(100), GUILayout.Height(30)))
        {
            HandleConvertion();
        }
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
    }

    private void OnProjectChange()
    {
        if (Directory.Exists(path))
            HandleConvertion();
        else
            Debug.LogError($"Path '{path}' doesn't exist. You probably need to change the path", this);
    }

    private void SetFolderPath()
    {
        string tempPath = EditorUtility.OpenFolderPanel("Load texture", path, "");
        Debug.Log(tempPath);
        path = tempPath.Substring(tempPath.IndexOf("Assets"));
        Debug.Log(path);
    }

    private void HandleConvertion()
    {
        string[] filesPNG = Directory.GetFiles(path, "*.png");
        string[] filesJPG = Directory.GetFiles(path, "*.jpg");
        string[] filesJPEG = Directory.GetFiles(path, "*.jpeg");
        
        if (filesPNG.Length > 0)
        {
            for (int i = 0; i < filesPNG.Length; i++)
                ChangeTextureType(filesPNG[i]);
        }
        if (filesJPG.Length > 0)
        {
            for (int i = 0; i < filesJPG.Length; i++)
                ChangeTextureType(filesJPG[i]);
        }
        if (filesJPEG.Length > 0)
        {
            for (int i = 0; i < filesJPEG.Length; i++)
                ChangeTextureType(filesJPEG[i]);
        }
        AssetDatabase.Refresh();
    }

    private void ChangeTextureType(string pPath)
    {
        AssetDatabase.ImportAsset(pPath);
        TextureImporter importer = AssetImporter.GetAtPath(pPath) as TextureImporter;
        importer.textureType = TextureImporterType.Sprite;
        AssetDatabase.WriteImportSettingsIfDirty(pPath);
        AssetDatabase.Refresh();
    }
}
