using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.Timeline;

public class Tree_Hel : Tree
{
	
	public float fireRange;
	public float damageRange;
	private GameObject currentTarget;

	public int damage;
	public float damageRate;
	private Coroutine damageCoroutine;
	
	public ParticleSystem fireParticle;

	public bool showDebug = true;

	
	public override void Fire() {
		base.Fire();
	}

	public override void Think() {
		base.Think();
		
		if (!currentTarget) {
			fireParticle.Stop();
			if (damageCoroutine != null) {
				StopCoroutine(damageCoroutine);
				damageCoroutine = null;
			}
			
			var enemiesInRange = FindObjectsOfType<Transform>().Where(obj => obj.CompareTag("Enemy") && Vector3.Distance(transform.position, obj.position) <= fireRange).ToList();
			if (enemiesInRange.Count > 0 && !currentTarget) {
				currentTarget = enemiesInRange[0].gameObject;
			}
		} else {
			if (Vector3.Distance(transform.position, currentTarget.transform.position) >= fireRange) {
				currentTarget = null;
				return;
			}
			
			fireParticle.Play();
			fireParticle.transform.LookAt(currentTarget.transform.position);
			
			
			if (damageCoroutine == null) {
				damageCoroutine = StartCoroutine(Damage());
			}
		}
		
	}
	
	private IEnumerator Damage() {
		yield return new WaitForSeconds(damageRate);

		if (currentTarget != null) {
			var enemiesNearby = FindObjectsOfType<Transform>().Where(obj => obj.CompareTag("Enemy") 
				                                                         && Vector3.Distance(currentTarget.transform.position, obj.position) <= damageRange).ToList();
			foreach (var enemy in enemiesNearby) {
				enemy.GetComponent<IDamageable>().TakeDamage(damage);
			}
			
		}
		
		damageCoroutine = StartCoroutine(Damage());
	}

	
	
	private void OnDrawGizmos() {
		if (showDebug) {
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, fireRange);

			if (currentTarget) {
				Gizmos.color = Color.magenta;
				Gizmos.DrawWireSphere(currentTarget.transform.position, damageRange);
			}
		}
	}
}
