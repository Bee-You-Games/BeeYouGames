using UnityEngine;

public class ProgressReset : MonoBehaviour
{
    void Start()
    {
        //Since all levels have their own XP value set to the name of the level, this is the easiest way to clear save data
        PlayerPrefs.DeleteAll();
    }
}
