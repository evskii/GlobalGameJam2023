using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.Timeline;

public class Tree_Hel : Tree
{
	
	public float fireRange;
	private GameObject currentTarget;

	public ParticleSystem fireParticle;

	public bool showDebug = true;

	
	public override void Fire() {
		base.Fire();
	}

	public override void Think() {
		base.Think();
		
		if (!currentTarget) {
			fireParticle.Stop();
			
			var enemiesInRange = FindObjectsOfType<Transform>().Where(obj => obj.CompareTag("Enemy") && Vector3.Distance(transform.position, obj.position) <= fireRange).ToList();
			if (enemiesInRange.Count > 0 && !currentTarget) {
				currentTarget = enemiesInRange[0].gameObject;
			}
		} else {
			fireParticle.Play();
			fireParticle.transform.LookAt(currentTarget.transform.position);
		}
		
	}

	
	
	private void OnDrawGizmos() {
		if (showDebug) {
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, fireRange);
		}
	}
}
