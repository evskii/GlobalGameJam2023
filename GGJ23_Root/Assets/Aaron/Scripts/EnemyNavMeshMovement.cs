using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshMovement : MonoBehaviour
{
    public enum enemyType { normal, big, projectile }
    public enemyType currentEnemyType;

    public Transform target;
    public int health = 3;
    public float enemySpeed = 3.5f;
    public float enemyDamage = 1f;
    public GameObject projectileAxe;

    private float timeRemaining = 1.5f;
    private bool isAttacking;
    private Vector3 targetObject;
    public Transform hand;
    private float enemyBaseSpeed;

    UnityEngine.AI.NavMeshAgent nav;

    [HideInInspector]
    public bool canMove = true;
    public Vector3 originSpawn;

    void Start()
    {
        enemyBaseSpeed = enemySpeed;
        originSpawn = transform.position;

        if (nav == null)
        {
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }

        if (target == null)
        {
            target = GameObject.Find("Yggdrasill").GetComponent<Transform>();
        }

        if (currentEnemyType == enemyType.big)
        {
            health = health * 2;
            enemySpeed = enemySpeed / 2;
            enemyDamage = enemyDamage * 2;
            transform.localScale = transform.localScale * 1.5f;
        }

        nav.SetDestination(target.position);
    }

    void Update()
    {
        if (currentEnemyType == enemyType.normal || currentEnemyType == enemyType.big)
        {
            if ((target.position - this.transform.position).sqrMagnitude < 1 * 2)
            {
                isAttacking = true;
                gameObject.GetComponent<Animator>().SetBool("Attack", true);
                canMove = false;
            }
            else
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
                foreach (Collider col in colliders)
                {
                    if (col.gameObject.CompareTag("Tree"))
                    {
                        targetObject = col.transform.position;
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
                        targetObject = Vector3.zero;
                        gameObject.GetComponent<Animator>().SetBool("Attack", false);
                        isAttacking = false;
                        canMove = true;
                    }
                }
            }
        }

        if (currentEnemyType == enemyType.projectile)
        {
            if ((target.position - this.transform.position).sqrMagnitude < 4 * 2)
            {
                isAttacking = true;
                gameObject.GetComponent<Animator>().SetBool("Attack", true);
                canMove = false;
            }
            else
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
                foreach (Collider col in colliders)
                {
                    if (col.gameObject.CompareTag("Tree"))
                    {
                        targetObject = col.transform.position;
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
                        targetObject = Vector3.zero;
                        gameObject.GetComponent<Animator>().SetBool("Attack", false);
                        isAttacking = false;
                        canMove = true;
                    }
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

        if (isAttacking)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                if (currentEnemyType == enemyType.projectile)
                {
                    GameObject projectile = Instantiate(projectileAxe, hand.position, Quaternion.identity);
                    projectile.GetComponent<Rigidbody>().AddForce((targetObject - transform.position) * 3, ForceMode.Impulse);
                }
                timeRemaining = 1.5f;
            }
        }
        else
        {
            timeRemaining = 1.5f;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Slowing"))
        {
            enemySpeed /= 3;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        enemySpeed = enemyBaseSpeed;
    }
}