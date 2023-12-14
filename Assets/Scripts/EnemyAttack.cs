using UnityEngine;
using TMPro;

public class EnemyAttack : MonoBehaviour
{
    private Enemy enemyMovement;
    private Transform player;
    public float attackRange = 3f;
    public int damageAmount = 10;
    public float attackCooldown = 2f;
    private float nextAttackTime;
    public Material defaultMaterial;
    public Material alertMaterial;
    public Renderer rend;
    private bool foundPlayer = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMovement = GetComponent<Enemy>();
        rend = GetComponent<Renderer>();
        foundPlayer = false;
        nextAttackTime = 0f;
    }

    private void Start()
    {
        enemyMovement.SetNewLocation();
    }

    private void Update()
    {
        Debug.Log("Distance to player: " + Vector3.Distance(transform.position, player.position));

        if (foundPlayer)
        {
            if (CanAttack())
            {
                AttackPlayer();
            }
            else
            {
                // Player is not in attack range, continue chasing
                rend.material = alertMaterial;
            }
        }
        else
        {
            // Player not found, check for player within attack range to start chasing
            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                foundPlayer = true;
                rend.material = alertMaterial;
            }
            else
            {
                // Player is not in attack range, revert to default material and maintain random movement
                rend.material = defaultMaterial;
                enemyMovement.SetNewLocation();
            }
        }
    }

    private bool CanAttack()
    {
        return Time.time >= nextAttackTime;
    }

    private void AttackPlayer()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }

        nextAttackTime = Time.time + attackCooldown;
    }

    private void FixedUpdate()
    {
        if (foundPlayer && Vector3.Distance(transform.position, player.position) > attackRange)
        {
            // Player is out of attack range, maintain random movement
            rend.material = defaultMaterial;
            enemyMovement.SetNewLocation();
            foundPlayer = false;
        }
        else if (foundPlayer)
        {
            // Player is in attack range, continue chasing
            enemyMovement.enemyAgent.SetDestination(player.position);
        }
    }
}