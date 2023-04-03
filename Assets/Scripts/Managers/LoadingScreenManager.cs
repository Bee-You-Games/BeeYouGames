using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
    [SerializeField]
    private string pStartSceneName = "MainMenu";
    [SerializeField]
    private GameObject loadingScreenObj;
    private List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    private Scene lastLoadedScene;

    public static LoadingScreenManager Instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (Instance == null)
            Instance = this;
        else
        {
            Debug.LogWarning("There were multiple instances of LoadingScreenManager", this);
            Destroy(gameObject);
        }

        SceneManager.LoadSceneAsync(pStartSceneName, LoadSceneMode.Additive);
        lastLoadedScene = SceneManager.GetSceneByName(pStartSceneName);
    }

    public void LoadScene(string pSceneName)
    {
        loadingScreenObj.SetActive(true);
        scenesLoading.Add(SceneManager.UnloadSceneAsync(lastLoadedScene));
        scenesLoading.Add(SceneManager.LoadSceneAsync(pSceneName, LoadSceneMode.Additive));

        lastLoadedScene = SceneManager.GetSceneByName(pSceneName);

        StartCoroutine(HandleSceneLoadProgress());
    }

    public void LoadScene(int pSceneIndex)
    {
        loadingScreenObj.SetActive(true);
        scenesLoading.Add(SceneManager.UnloadSceneAsync(lastLoadedScene));
        scenesLoading.Add(SceneManager.LoadSceneAsync(pSceneIndex, LoadSceneMode.Additive));

        lastLoadedScene = SceneManager.GetSceneByBuildIndex(pSceneIndex);

        StartCoroutine(HandleSceneLoadProgress());
    }

    public IEnumerator HandleSceneLoadProgress()
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                yield return null;
            }
        }

        loadingScreenObj.SetActive(false);
    }
}
