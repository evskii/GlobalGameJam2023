using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YggrdasilController : MonoBehaviour, IDamageable
{
    public int maxHealth;
    public int currentHealth;
    public GameObject loseText;
    public bool isDead;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        loseText.SetActive(true);
    }
}
