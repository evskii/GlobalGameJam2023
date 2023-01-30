using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshMovement : MonoBehaviour
{
    public Transform target;

    public int health = 3;

    public float enemySpeed = 3.5f;
    public float timeRemaining = 3f;
    private float startTime;

    public bool isAttacking, isAttackingBase;

    UnityEngine.AI.NavMeshAgent nav;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        if (nav == null)
        {
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }

        nav.SetDestination(target.position);
    }

    void Update()
    {
        if ((target.position - this.transform.position).sqrMagnitude < 2 * 2)
        {
            isAttacking = true;
            gameObject.GetComponent<Animator>().SetBool("Attack", true);
            canMove = false;
        }
        else
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);
            foreach (Collider col in colliders)
            {
                if (col.gameObject.CompareTag("Tree"))
                {
                    canMove = false;
                    isAttacking = true;
                    Vector3 targetDirection = col.transform.position - transform.position;
                    targetDirection.y = 0;
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * 5f);
                    gameObject.GetComponent<Animator>().SetBool("Attack", true);
                    break;
                }
                else
                {
                    gameObject.GetComponent<Animator>().SetBool("Attack", false);
                    isAttacking = false;
                    canMove = true;
                }
            }
        }

        if (canMove)
        {
            gameObject.GetComponent<NavMeshAgent>().speed = enemySpeed;
            nav.SetDestination(target.position);
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().speed = 0;
        }
    }

    public void Attack()
    {
        if (isAttacking)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else if (timeRemaining < 0)
            {
                timeRemaining = startTime;
            }
        }
        else
        {
            timeRemaining = startTime;
        }
    }
}
