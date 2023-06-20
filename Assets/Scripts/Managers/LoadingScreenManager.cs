using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
    [SerializeField]
    private string StartSceneName = "MainMenu";
    [SerializeField]
    private GameObject loadingScreenObj;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Animator anim;
    private List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    private Scene lastLoadedScene;

    public string PreviousLevel { get; private set; }

    public static LoadingScreenManager Instance { get; private set; }

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

        SceneManager.LoadSceneAsync(StartSceneName, LoadSceneMode.Additive);
        lastLoadedScene = SceneManager.GetSceneByName(StartSceneName);
    }

    private IEnumerator ILoadScene(string pSceneName)
    {
        PreviousLevel = StringUtils.GetCurrentLevel(pSceneName);
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
        
        scenesLoading.Add(SceneManager.UnloadSceneAsync(lastLoadedScene));
        scenesLoading.Add(SceneManager.LoadSceneAsync(pSceneName, LoadSceneMode.Additive));

        lastLoadedScene = SceneManager.GetSceneByName(pSceneName);

        StartCoroutine(HandleSceneLoadProgress());
    }

    private IEnumerator ILoadScene(int pSceneIndex)
    {
        PreviousLevel = StringUtils.GetCurrentLevel(SceneManager.GetSceneByBuildIndex(pSceneIndex).name);
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
        
        scenesLoading.Add(SceneManager.UnloadSceneAsync(lastLoadedScene));
        scenesLoading.Add(SceneManager.LoadSceneAsync(pSceneIndex, LoadSceneMode.Additive));

        lastLoadedScene = SceneManager.GetSceneByBuildIndex(pSceneIndex);

        StartCoroutine(HandleSceneLoadProgress());
    }

    public void LoadScene(string pSceneName)
    {
        StartCoroutine(ILoadScene(pSceneName));
    }

    public void LoadScene(int pSceneIndex)
    {
        StartCoroutine(ILoadScene(pSceneIndex));
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
        
        anim.SetTrigger("End");
        yield return new WaitForSeconds(1f);
    }
}
