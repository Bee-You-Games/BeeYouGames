using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    Color fadeColor;

    private void Start()
    {
        fadeColor = GetComponent<Image>().color;
        StartCoroutine(FadeIn());
    }

    public void OutFade() => StartCoroutine(FadeOut());
    public void InFade() => StartCoroutine(FadeIn());

    private IEnumerator FadeIn()
    {
        fadeColor.a = 1f;
        GetComponent<Image>().color = fadeColor;

        while (fadeColor.a > 0f)
        {
            fadeColor.a -= 1f * Time.deltaTime;
            GetComponent<Image>().color = fadeColor;
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        fadeColor.a = 0f;
        GetComponent<Image>().color = fadeColor;

        while (fadeColor.a < 1f)
        {
            fadeColor.a += 1f * Time.deltaTime;
            GetComponent<Image>().color = fadeColor;
            yield return null;
        }
    }
}
