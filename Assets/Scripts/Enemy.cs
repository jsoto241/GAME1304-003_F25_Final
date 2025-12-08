using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int Health = 100;
    [SerializeField] private ProgressBar HealthBar;
    [Range(0,50)]  [SerializeField] float attackRange = 5, sightRange = 20, timeBetweenAttacks = 3;

    [Range(0, 20)][SerializeField] int power; // The amount of damamge that the enemy does

    private float MaxHealth;
    private NavMeshAgent thisEnemy;
    public Transform playerPos;

    private bool isAttacking; // if enemy is currently attacking

    private void Start()
    {
        thisEnemy = GetComponent<NavMeshAgent>();
        playerPos = FindObjectOfType<PlayerHealth>().transform;
        MaxHealth = Health;
    }

    private void Update()
    {
        float distanceFromPlayer = Vector3.Distance(playerPos.position, this.transform.position); // The distance between the player and the enemy

        if (distanceFromPlayer <= sightRange && distanceFromPlayer > attackRange && !PlayerHealth.isDead)
        {
            isAttacking = false;
            thisEnemy.isStopped = false;
            StopAllCoroutines();

            ChasePlayer();
        }

        if (distanceFromPlayer <= attackRange && !isAttacking && !PlayerHealth.isDead)
        {
            thisEnemy.isStopped = true; // Stop the enemy from moving
            StartCoroutine(AttackPlayer()); // Start attacking the player.
        }

        //if (PlayerHealth.isDead)
        //{
           // Destroy(gameObject);
               
       // }

    }

    private void ChasePlayer()
    {
        thisEnemy.SetDestination(playerPos.position); // Set the enemy's destination to the player.
    }

    private IEnumerator AttackPlayer()
    {
        isAttacking = true;

        yield return new WaitForSeconds(timeBetweenAttacks); // Wait for the time between attacks.

        FindObjectOfType<PlayerHealth>().TakeDamage(power); // Damamge the player with 'power' damamge.

        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position, sightRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }

    public void OnTakeDamage(int Damage)
    {
        Health -= Damage;
        Debug.Log(Health);
        

        HealthBar.SetProgress(Health / MaxHealth, 3);

        if (Health <= 0)
        {
            OnDied();
            thisEnemy.enabled = false;
        }
    }

    private void OnDied()
    {
        float destoryDelay = UnityEngine.Random.value;
        gameObject.SetActive(false);
        Destroy(HealthBar.gameObject, destoryDelay);
    }

    public void SetupHealthBar(Canvas Canvas, Camera Camera)
    {
        HealthBar.transform.SetParent(Canvas.transform);
        if (HealthBar.TryGetComponent<FaceCamera>(out FaceCamera faceCamera))
        {
            faceCamera.Camera = Camera;
        }
    }
}
