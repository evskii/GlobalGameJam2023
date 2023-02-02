using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

using UnityEngine;
using UnityEngine.AI;

public class Tree_Heimdall : Tree
{
	public float attackRange;
	private GameObject currentTarget;

	public float attackRate;
	private float lastAttack = 0;
	

	public bool showDebug = true;
	

	public override void Think() {
		base.Think();
		if (Time.time >= lastAttack + attackRate) {
			var enemiesInRange = FindObjectsOfType<Transform>().Where(obj => obj.CompareTag("Enemy") && Vector3.Distance(transform.position, obj.position) <= attackRange).ToList();
			if (enemiesInRange.Count > 0 && !currentTarget) {
				
				currentTarget = enemiesInRange[0].gameObject;
				currentTarget.gameObject.SetActive(false);
				Debug.Log("TELEPORT: " + currentTarget.name);
				var spawnPos = currentTarget.GetComponent<EnemyNavMeshMovement>().originSpawn;
				currentTarget.transform.position = spawnPos;
				lastAttack = Time.time;
				currentTarget.gameObject.SetActive(true);
				currentTarget = null;
			}
		}
	}
	

	
	
	private void OnDrawGizmos() {
		if (showDebug) {
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, attackRange);

		}
	}
}
