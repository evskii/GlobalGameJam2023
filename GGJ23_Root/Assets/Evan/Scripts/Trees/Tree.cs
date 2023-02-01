using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Tree : MonoBehaviour, IDamageable
{
    [Header("Base Class Variables")]
    public int maxHealth;
    public int currentHealth;
    public UnityEvent DeathEvent;

    private void Awake() {
        currentHealth = maxHealth;
    }

    public virtual void Fire() {
        
    }

    public virtual void Think() {
        
    }
    public void TakeDamage(int amount) {
        currentHealth -= amount;
        if (currentHealth <= 0) {
            Die();
        }
    }

    public void Die() {
        DeathEvent.Invoke();
    }
}
