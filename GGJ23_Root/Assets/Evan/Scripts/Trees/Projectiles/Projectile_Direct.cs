using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Direct : MonoBehaviour
{
	public int damage = 5;

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Tree")) {
			return;
		}
		
		if (other.CompareTag("Enemy")) {
			other.GetComponent<IDamageable>().TakeDamage(damage);
		}
		Destroy(gameObject);
	}
}
