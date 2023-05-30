using UnityEngine;

public class Collectible : MonoBehaviour, IInteractable
{
    [SerializeField]
    private int experienceValue;
    [SerializeField] private string prompt;
    public string Prompt => prompt;
    public bool Available { get; set; }

    private void Awake()
    {
        Available = true;
    }

    public bool Interact(PlayerInteractor playerInteractor)
    {
        ExperienceManager.Instance.AddExperience(experienceValue);
        Destroy(gameObject);
        return true;
    }
}
