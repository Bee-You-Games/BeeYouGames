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

    [SerializeField]
    private float fadeSpeed = 5f;
    [SerializeField]
    private Image blackImage;

    private SceneLoading sceneLoading;

    public string Prompt => prompt;

    public bool Available { get; set; }

    public bool Interact(PlayerInteractor interactor)
    {
        Debug.Log("Gets here");
        StartCoroutine(FadeScreenToBlack());
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Available = true;
        sceneLoading = GetComponent<SceneLoading>();
    }

    private IEnumerator FadeScreenToBlack()
    {
        Color color = blackImage.color;
        float fadeAmount = 0;

        while (blackImage.color.a < 1)
        {
            fadeAmount = color.a + (fadeSpeed * Time.deltaTime);

            color = new Color(color.r, color.g, color.b, fadeAmount);
            blackImage.color = color;
            yield return null;
        }
        sceneLoading.LoadScene(sceneName);
        
    }
}
