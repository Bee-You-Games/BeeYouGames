using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))][RequireComponent(typeof(Image))]
public class Ability : MonoBehaviour, IAbility
{
    [SerializeField]
    private float animationSpeed;
    [SerializeField]
    private float scaleModifier = 1.5f;
    [SerializeField]
    private int experienceNeeded;
    [SerializeField][Range(0f, 1f)]
    private float startAlpha = 0.65f;

    private Button button;
    private Image image;

    private Color unlockedColor;

    public int ExperienceNeeded { get => experienceNeeded; set => experienceNeeded = value; }

    public bool isUnlocked { get; set; } = false;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnSelect);

        image = GetComponent<Image>();
        unlockedColor = image.color;
        image.color = new Color(image.color.r, image.color.g, image.color.b, startAlpha);

        gameObject.SetActive(false);
    }

    public void OnSelect()
    {
        //Do shit here
        Debug.Log("Used Ability");
    }

    public void Unlock()
    {
        Debug.Log(transform.name + " unlocked");
        isUnlocked = true;
        gameObject.SetActive(true);
        LeanTween.cancel(gameObject);

        LeanTween.scale(gameObject, Vector3.one * scaleModifier, animationSpeed).setEasePunch();
        image.color = unlockedColor;
    }
}
