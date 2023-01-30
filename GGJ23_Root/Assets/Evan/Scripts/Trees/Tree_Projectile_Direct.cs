using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

using UnityEngine;

public class Tree_Projectile_Direct : Tree
{
	//Tree Settings
	public float fireRange;
	public GameObject projectile;
	public Transform firePosition;
	public float fireRate;
	public float projectileSpeed = 10;
	private float lastShot = 0;

	//Extra Shite
	public bool showDebug;
	
	public override void Fire() {
		base.Fire();
	}

	public override void Think() {
		base.Think();
		
		// Debug.Log("I AM TREE: " + name);

		var enemiesInRange = FindObjectsOfType<Transform>().Where(obj => obj.CompareTag("Enemy") && Vector3.Distance(transform.position, obj.position) <= fireRange).ToList();
		if (enemiesInRange.Count > 0) {
			foreach (var enemy in enemiesInRange) {
				if (Time.time >= lastShot + fireRate) {
					var spawnedProjectile = Instantiate(projectile, firePosition.position, quaternion.identity);
					spawnedProjectile.GetComponent<Rigidbody>().AddForce((enemy.position - firePosition.position) * projectileSpeed, ForceMode.Impulse);
					lastShot = Time.time;
				}
				
			}
		}
	}

	private void OnDrawGizmos() {
		if (showDebug) {
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, fireRange);
		}
	}
}
