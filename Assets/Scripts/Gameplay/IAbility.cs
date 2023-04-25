using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IAbility
{
    int ExperienceNeeded { get; set; }

    void OnSelect();
    void Unlock();
}
