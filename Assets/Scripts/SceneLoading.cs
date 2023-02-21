using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour, ISceneLoading
{
    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void LoadScene(string pSceneName) => SceneManager.LoadScene(pSceneName);

    public void LoadScene(int pSceneIndexNumber) => SceneManager.LoadScene(pSceneIndexNumber);

    public void ReloadScene() => SceneManager.LoadScene(currentScene.name);
}
