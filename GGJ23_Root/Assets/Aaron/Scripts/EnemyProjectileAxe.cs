using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileAxe : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            Destroy(gameObject);
        }
    }
}
