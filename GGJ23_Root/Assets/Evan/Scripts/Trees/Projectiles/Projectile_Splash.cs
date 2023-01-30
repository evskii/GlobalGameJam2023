using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Projectile_Splash : MonoBehaviour
{
	public int damageMin;
	public int damageMax;
	public float damageRadius;
	
	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Tree")) {
			return;
		}
		var enemiesInRange = FindObjectsOfType<Transform>().Where(obj => obj.CompareTag("Enemy") && Vector3.Distance(transform.position, obj.position) <= damageRadius).ToList();
		foreach (var enemy in enemiesInRange) {
			var distance = Vector3.Distance(enemy.position, transform.position);
			var falloffDamage = Map(distance, damageRadius, 0 , damageMin, damageMax);
			Debug.Log("Falloff Damage: " + falloffDamage);
			enemy.GetComponent<IDamageable>().TakeDamage((int)falloffDamage);
		}
		
		Destroy(gameObject);
	}
	
	public static float Map(float x, float a, float b, float c, float d) {
		return (x - a) / (b - a) * (d - c) + c;
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere(transform.position, damageRadius);
	}
}
