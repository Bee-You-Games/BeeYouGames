using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StringUtils
{
    public static string GetCurrentLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string[] words = sceneName.Split('_');
        string level = words[0].ToLower();
        Debug.Log(level);
        return level;
    }

    public static string GetCurrentLevel(string pSceneName)
    {
        string sceneName = pSceneName;
        string[] words = sceneName.Split('_');
        string level = words[0].ToLower();
        Debug.Log(level);
        return level;
    }
}
