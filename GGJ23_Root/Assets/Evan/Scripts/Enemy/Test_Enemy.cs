using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Enemy : MonoBehaviour, IDamageable
{
    public int health;
    public int maxHealth;

    private void Start() {
        health = maxHealth;
    }


    public void TakeDamage(int amount) {
        health -= amount;

        if (health <= 0) {
            Die();
        }
    }

    public void Die() {
        Destroy(gameObject);
    }
}
