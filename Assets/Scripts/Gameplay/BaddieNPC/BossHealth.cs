using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossHealth : MonoBehaviour, IHealth
{
    public float Health { get; set; }

    public UnityEvent OnDeath; 
    public UnityEvent OnDamage; 
    public UnityEvent OnHeal; 

    public void DealDamage(int pDamage)
    {
        if (pDamage < 0)
            Debug.LogError("Dealing negative damage is not allowed", this);

        Health -= pDamage;
        OnDamage?.Invoke();

        if (Health <= 0)
        {
            Health = 0;
            OnDeath?.Invoke();
        }
    }

    public void Heal(int pHealAmount)
    {
        if (pHealAmount < 0)
            Debug.LogError("Healing negative amount is not allowed", this);

        Health += pHealAmount;
        OnHeal?.Invoke();
    }
    public float GetDamage() => Health;
}
