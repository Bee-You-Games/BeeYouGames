using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    float Health { get; set; }


    public void DealDamage(int pDamage);
    public void Heal(int pHealAmount);
    public float GetDamage();
}
