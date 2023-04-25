using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ExperienceBar : MonoBehaviour
{
    [SerializeField]
    private int maxValue = 100;
    [SerializeField]
    private float sliderAnimationSpeed = 100f;

    private Slider slider;
    private bool isUpdating = false;

    //I don't know what this exactly is, but I need it for the SmoothDamp
    private float currentVelocity;

    private int targetValue;

    private void Start()
    {
        ExperienceManager.Instance.OnExperienceChange += (value) => targetValue = value;
        slider = GetComponent<Slider>();
        slider.maxValue = maxValue;
        slider.value = 0;
    }

    private void UpdateSlider(int pTargetValue)
    {
        slider.value = Mathf.SmoothDamp(slider.value, pTargetValue, ref currentVelocity, sliderAnimationSpeed * Time.deltaTime);
    }

    private void Update()
    {
        if(slider.value != targetValue)
            UpdateSlider(targetValue);
    }

    private IEnumerator SliderAnimation(int pValue)
    {
        if (isUpdating) yield return null;

        int tempValue = (int)slider.value;

        isUpdating = true;

        while (slider.value != pValue)
        {
            slider.value = Mathf.SmoothDamp(slider.value, pValue, ref currentVelocity, sliderAnimationSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            //slider.value = Mathf.Lerp(tempValue, pValue, sliderAnimationSpeed * Time.deltaTime);
        }

        isUpdating = false;
    }
}
