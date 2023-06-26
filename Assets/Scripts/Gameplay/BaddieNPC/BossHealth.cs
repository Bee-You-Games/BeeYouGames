using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BossHealth : MonoBehaviour, IHealth
{
    public float Health { get; set; }

    public UnityEvent OnDeath; 
    public UnityEvent OnDamage; 
    public UnityEvent OnHeal; 
    [SerializeField]
    private float fadeTime = 1f;

    [SerializeField]
    private Image winUI;
    public void DealDamage(int pDamage)
    {
        if (pDamage < 0)
            Debug.LogError("Dealing negative damage is not allowed", this);

        Health -= pDamage;
        OnDamage?.Invoke();

        Debug.Log($"Dealth {pDamage} damage. {Health} hp remaining");

        if (Health <= 0)
        {
            Debug.Log("No health left, baddie dead");
            Health = 0;
            OnDeath?.Invoke();
            winUI.gameObject.SetActive(true);
            winUI.color = new Color(winUI.color.r, winUI.color.g, winUI.color.b, 0f);
            LeanTween.alpha(winUI.rectTransform, 1f, fadeTime);
            GameStateManager.Instance.SetState(GameState.Dialogue);
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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
            DealDamage(10);
    }
}
