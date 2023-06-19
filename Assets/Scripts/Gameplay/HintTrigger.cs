using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintTrigger : AreaTrigger
{
    [SerializeField]
    private Image hintImage;
    [SerializeField]
    private float fadeTime = 0.5f;
    private bool isDisplayed = false;

    void Start()
    {
        Setup();

        if(hintImage == null)
            Debug.Log("No image set for " + gameObject.name);
    }

    protected override void Activate()
    {
        if(isDisplayed)
            return;
        
        hintImage.gameObject.SetActive(true);
        hintImage.color = new Color(hintImage.color.r, hintImage.color.g, hintImage.color.b, 0f);
        LeanTween.alpha(hintImage.rectTransform, 1f, fadeTime);
        isDisplayed = true;
    }
    
    public void HideHint()
    {
        hintImage.color = new Color(hintImage.color.r, hintImage.color.g, hintImage.color.b, 1f);
        LeanTween.alpha(hintImage.rectTransform, 0f, fadeTime).setOnComplete(() => Destroy(hintImage.gameObject));
        Destroy(gameObject);
    }
}
