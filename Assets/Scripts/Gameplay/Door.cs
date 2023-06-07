using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SceneLoading))]
public class Door : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string prompt;
    [SerializeField][Tooltip("Name of the scene to load")]
    private string sceneName;
    [SerializeField][Range(0f, 2f)]
    private float WaitTimeInSeconds = 0.5f;

    private SceneLoading sceneLoading;

    public string Prompt => prompt;

    public bool Available { get; set; }

    public bool Interact(PlayerInteractor interactor)
    {
        Debug.Log("Switching Scene");
        sceneLoading.LoadScene(sceneName);
        Available = false;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Available = false;
        StartCoroutine(WaitTime());
        sceneLoading = GetComponent<SceneLoading>();
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(WaitTimeInSeconds);
        Available = true;
    }
}
