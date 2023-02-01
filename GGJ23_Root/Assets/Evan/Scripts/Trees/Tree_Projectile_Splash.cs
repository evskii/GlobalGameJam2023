using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


using UnityEngine;

using Random = UnityEngine.Random;


public class Tree_Projectile_Splash : Tree
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
		
		var enemiesInRange = FindObjectsOfType<Transform>().Where(obj => obj.CompareTag("Enemy") && Vector3.Distance(transform.position, obj.position) <= fireRange).ToList();
		if (enemiesInRange.Count > 0) {
			int firstIndex = Random.Range(0, enemiesInRange.Count/2);
			int secondIndex = Random.Range(firstIndex, enemiesInRange.Count);
			Vector3 targetPos = Vector3.Lerp(enemiesInRange[firstIndex].position, enemiesInRange[secondIndex].position, 0.5f);
			targetPos = new Vector3(targetPos.x, 0, targetPos.z);

			if (Time.time >= lastShot + fireRate) {
				var spawnedProjectile = Instantiate(projectile, firePosition.position, Quaternion.identity);
				spawnedProjectile.GetComponent<Rigidbody>().AddForce((targetPos - firePosition.position) * projectileSpeed, ForceMode.Impulse);
				lastShot = Time.time;
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
