using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Tree_Thor : Tree
{
	
	public float fireRange;
	public Transform firePosition;
	private GameObject currentTarget;

	public float damageRate;
	public int damage;
	private Coroutine damageCoroutine;
	
	//Line Renderer Stuff
	private Transform startPos;
	private Transform endPos;
	public int totalSteps;
	private LineRenderer lineRenderer;
	private bool active;
	

	public bool showDebug;
	
	private void Awake() {
		lineRenderer = GetComponent<LineRenderer>();
		currentHealth = maxHealth;
	}
	
	public override void Fire() {
		base.Fire();
	}

	public override void Think() {
		base.Think();
		if (!currentTarget) {
			if (damageCoroutine != null) {
				StopCoroutine(damageCoroutine);
				damageCoroutine = null;
			}

			lineRenderer.enabled = false;
			var enemiesInRange = FindObjectsOfType<Transform>().Where(obj => obj.CompareTag("Enemy") && Vector3.Distance(transform.position, obj.position) <= fireRange).ToList();
			if (enemiesInRange.Count > 0 && !currentTarget) {
				currentTarget = enemiesInRange[0].gameObject;
			}
		} else {
			if (currentTarget) {

				if (Vector3.Distance(transform.position, currentTarget.transform.position) >= fireRange || !currentTarget.transform.CompareTag("Enemy")) {
					currentTarget = null;
					return;
				}
				
				startPos = firePosition;
				endPos = currentTarget.transform;

				lineRenderer.enabled = true;
				lineRenderer.SetVertexCount(totalSteps + 1);

				//Make points in the middle
				for (int i = 0; i < totalSteps; i++) {
					var linePointVector = Vector3.Lerp(startPos.position, endPos.position, (float)i / totalSteps);

					Vector3 finalVector = i > 0 ? new Vector3(linePointVector.x, linePointVector.y * Random.Range(0.5f, 1.5f), linePointVector.z) : linePointVector;

					lineRenderer.SetPosition(i, finalVector);
				}

				lineRenderer.SetPosition(totalSteps, endPos.position);

				if (damageCoroutine == null) {
					damageCoroutine = StartCoroutine(Damage());
				}
			}
		}
	}

	private IEnumerator Damage() {
		yield return new WaitForSeconds(damageRate);

		if (currentTarget != null) {
			currentTarget.GetComponent<IDamageable>().TakeDamage(damage);
		}
		
		damageCoroutine = StartCoroutine(Damage());
	}
	
	private void OnDrawGizmos() {
		if (showDebug) {
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, fireRange);
		}
	}
}
