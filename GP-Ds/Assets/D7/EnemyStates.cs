using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStates : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public PlayerHealth enemyHurtsPlayer;

    public bool playerCanAttack;

    public ParticleSystem fireAttack;



    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttackes;
    bool alreadyAttacked = false;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
            //Debug.Log("Patrolling");
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
            //Debug.Log("Chasing Player");
        }

        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
            //Debug.Log("Attacking player");
        }

    }

    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
           

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
          
            
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
   
        if (Physics.Raycast(walkPoint, -transform.up, 2.5f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    public void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        //Player is within range of enemy
        playerCanAttack = true;

        if (!alreadyAttacked)
        {

            enemyHurtsPlayer.playerTakesDamage = true;
            alreadyAttacked = true;
            fireAttack.Play();
            enemyHurtsPlayer.TakeDamage(20);
            Invoke(nameof(RestAttack), timeBetweenAttackes);
        }
    }

    public void RestAttack()
    {
        alreadyAttacked = false;
        fireAttack.Stop();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
