using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class HintTrigger : MonoBehaviour
{
    Collider triggerCollider;
    [SerializeField]
    private Image hintImage;
    private bool IsDisplayed = false;
    [SerializeField]
    private float fadeTime = 0.5f;
    void Start()
    {
        triggerCollider = GetComponent<Collider>();
        triggerCollider.isTrigger = true;

        if(hintImage == null)
            Debug.Log("No image set for " + gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && IsDisplayed == false)
        {
            DisplayHint();
        }
    }

    private void DisplayHint()
    {
        hintImage.gameObject.SetActive(true);
        hintImage.color = new Color(hintImage.color.r, hintImage.color.g, hintImage.color.b, 0f);
        LeanTween.alpha(hintImage.rectTransform, 1f, fadeTime);
        IsDisplayed = true;
    }

    public void HideHint()
    {
        hintImage.color = new Color(hintImage.color.r, hintImage.color.g, hintImage.color.b, 1f);
        LeanTween.alpha(hintImage.rectTransform, 0f, fadeTime).setOnComplete(() => Destroy(hintImage.gameObject));
        Destroy(gameObject);
    }
}
