using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileAxe : MonoBehaviour
{
    public int damage;

    public void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER");
        if (other.gameObject.CompareTag("Tree"))
        {
            Debug.Log("HIT TREE");
            other.GetComponentInParent<IDamageable>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
