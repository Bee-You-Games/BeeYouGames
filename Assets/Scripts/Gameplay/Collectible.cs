using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour, IInteractable
{
    [SerializeField]
    private int experienceValue;
    [SerializeField] private string prompt;

    // 0 = false, 1 = true
    private const string IsCollectedPrefKey = "Collected";

    public string Prompt => prompt;
    public bool Available { get; set; }
    
    public bool IsCollected { get; private set; }

    private void Start()
    {
        CheckIfAvailable();
    }

    private void CheckIfAvailable()
    {
        if (LoadingScreenManager.Instance != null)
        {
            if (!PlayerPrefs.HasKey(IsCollectedPrefKey))
                PlayerPrefs.SetInt(IsCollectedPrefKey, 0);

            if (LoadingScreenManager.Instance.PreviousLevel == StringUtils.GetCurrentLevel() && PlayerPrefs.GetInt(IsCollectedPrefKey) == 1)
            {
                Available = false;
                PlayerPrefs.SetInt(IsCollectedPrefKey, 1);
                Destroy(this.gameObject);
            }
            else
            {
                PlayerPrefs.SetInt(IsCollectedPrefKey, 0);
                Available = true;
            }
        }
        else
        {
            if (!PlayerPrefs.HasKey(IsCollectedPrefKey))
                PlayerPrefs.SetInt(IsCollectedPrefKey, 0);

            if (!PlayerPrefs.HasKey(SceneLoading.PREVIOUS_SCENE_KEY)) return;

            if (PlayerPrefs.GetString(SceneLoading.PREVIOUS_SCENE_KEY) == StringUtils.GetCurrentLevel() &&
                PlayerPrefs.GetInt(IsCollectedPrefKey) == 1)
            {

            }


        }
    }

    public void SetIsCollected(bool pIsCollected)
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
