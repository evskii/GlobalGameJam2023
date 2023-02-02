using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YggrdasilController : MonoBehaviour, IDamageable
{
    public int maxHealth;
    public int currentHealth;
    public GameObject loseText;
    public MeshRenderer mesh;
    public bool isDead;
    public GameObject healthSlider;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthSlider.GetComponent<Slider>().maxValue = maxHealth;
    }

    public void Update()
    {
        healthSlider.GetComponent<Slider>().value = currentHealth;
    }

    
    public void TakeDamage(int amount)
    {
        // currentHealth -= amount;
        currentHealth--;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        healthSlider.SetActive(false);
        isDead = true;
        loseText.SetActive(true);
        mesh.enabled = false;
    }
}
