using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Enemy enemyMovement;
    private Transform player;
    public float attackRange = 0.1f;
    public int damageAmount = 10;
    public float attackCooldown = 2f; // Time between attacks
    private float nextAttackTime;
    public Material defaultMaterial;
    public Material alertMaterial;
    public Renderer rend;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMovement = GetComponent<Enemy>();
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        Debug.Log("Distance to player: " + Vector3.Distance(transform.position, player.position));
        if (CanAttack())
        {
            AttackPlayer();
        }
    }

    private bool CanAttack()
    {
        return Vector3.Distance(transform.position, player.position) <= attackRange &&
           Vector3.Distance(transform.position, player.position) >= 0.1f;
    }

    private void AttackPlayer()
    {
        // Deal damage to the player (you can replace this with your own damage logic)
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }

        // Set the next attack time based on the cooldown
        nextAttackTime = Time.time + attackCooldown;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            rend.sharedMaterial = alertMaterial; // Change Material
            enemyMovement.EnemyAgent.SetDestination(player.position); // Set destination to player position
        }
        else
        {
            rend.sharedMaterial = defaultMaterial; // Set Material back to default
            enemyMovement.newLocation(); // Call new location function
        }
    }
}
