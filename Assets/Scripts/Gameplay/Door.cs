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

    private SceneLoading sceneLoading;

    public string Prompt => prompt;

    public bool Available { get; set; }

    public bool Interact(PlayerInteractor interactor)
    {
        Debug.Log("Gets here");
        sceneLoading.LoadScene(sceneName);
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Available = true;
        sceneLoading = GetComponent<SceneLoading>();
    }
}
