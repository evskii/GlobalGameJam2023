using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Direct : MonoBehaviour
{

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Tree")) {
			return;
		}
		
		if (other.CompareTag("Enemy")) {
			other.GetComponent<IDamageable>().TakeDamage(10);
		}
		Destroy(gameObject);
	}
}
