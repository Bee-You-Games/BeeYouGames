using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour, IInteractable
{
    [SerializeField]
    private int experienceValue;
    [SerializeField] private string prompt;

    private SpamTapping spamTapping;

    /// <summary>
    /// 0 = false, 1 = true
    /// </summary>
    private const string IsCollectedPrefKey = "Collected";

    public string Prompt => prompt;
    public bool Available { get; set; }
    
    public bool IsCollected { get; private set; }

    private void Start()
    {
        spamTapping = GetComponent<SpamTapping>();
        spamTapping.OnComplete.AddListener(delegate { SetIsCollected(); });
        CheckIfAvailable();
    }

    private void CheckIfAvailable()
    {
        if (!PlayerPrefs.HasKey(IsCollectedPrefKey)) return;

        if (PlayerPrefs.GetInt(IsCollectedPrefKey) == 0) return;
        else if (PlayerPrefs.GetInt(IsCollectedPrefKey) == 1) Destroy(this.gameObject);
        else Debug.LogError("IsCollected player pref is " + PlayerPrefs.GetInt(IsCollectedPrefKey) + " Value needs to be either 0 or 1", this);
    }

    public void SetIsCollected(bool pIsCollected = true)
    {
        IsCollected = pIsCollected;

        if(IsCollected)
            PlayerPrefs.SetInt(IsCollectedPrefKey, 1);
        else
            PlayerPrefs.SetInt(IsCollectedPrefKey, 0);
    }

    public bool Interact(PlayerInteractor playerInteractor)
    {
        ExperienceManager.Instance.AddExperience(experienceValue);
        Destroy(gameObject);
        return true;
    }
}
