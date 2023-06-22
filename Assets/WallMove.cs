using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour 
{
    [SerializeField]
    private int requiredXP = 10;
    void Update()
    {
        if( ExperienceManager.Instance.GetExperience() >= requiredXP){
            this.gameObject.SetActive(false);
        }

    }
}
