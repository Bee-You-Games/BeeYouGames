using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour, ISceneLoading
{

    private void Start()
    {
        if (LoadingScreenManager.Instance == null)
            Debug.Log("No instance of LoadingScreenManager was found.\nWill load scenes with SceneManager instead.");
    }

    public void LoadScene(string pSceneName)
    {
        if (LoadingScreenManager.Instance != null)
            LoadingScreenManager.Instance.LoadScene(pSceneName);
        else
            SceneManager.LoadScene(pSceneName);
    }

    public void LoadScene(int pSceneIndexNumber)
    {
        if (LoadingScreenManager.Instance != null)
            LoadingScreenManager.Instance.LoadScene(pSceneIndexNumber);
        else
            SceneManager.LoadScene(pSceneIndexNumber);
    }

    public void ReloadScene()
    {
        if (LoadingScreenManager.Instance != null)
            LoadingScreenManager.Instance.LoadScene(SceneManager.GetActiveScene().name);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame() => Application.Quit();
}
