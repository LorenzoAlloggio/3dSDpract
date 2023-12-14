using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemyAgent;
    public int damageAmount = 10;

    public float xMinBorder = -16f;
    public float xMaxBorder = 16f;
    public float zMinBorder = -22.6f;
    public float zMaxBorder = 22.7f;

    private float closeEnough = 0.5f;

    private float nextLocationTime;

    void Start()
    {
        StartCoroutine(SetNewLocationRoutine());
    }

    System.Collections.IEnumerator SetNewLocationRoutine()
    {
        while (true)
        {
            // Wait for a random interval before setting a new location
            yield return new WaitForSeconds(1f);

            // Check if the enemy is not actively chasing the player
            if (!IsChasingPlayer())
            {
                SetNewLocation();
            }
        }
    }

    public void SetNewLocation()
    {
        // Check if the enemy is currently moving towards the previous destination
        if (!IsMovingTowardsPreviousDestination())
        {
            // Reset the path to clear any previous destination
            enemyAgent.ResetPath();

            float xPosition = Mathf.Clamp(Random.Range(xMinBorder, xMaxBorder), xMinBorder, xMaxBorder);
            float yPosition = transform.position.y;
            float zPosition = Mathf.Clamp(Random.Range(zMinBorder, zMaxBorder), zMinBorder, zMaxBorder);

            enemyAgent.SetDestination(new Vector3(xPosition, yPosition, zPosition));
            Debug.Log("Setting new location to: " + new Vector3(xPosition, yPosition, zPosition));
        }
    }

    private bool IsChasingPlayer()
    {
        // Add logic to determine if the enemy is actively chasing the player
        return enemyAgent.hasPath && enemyAgent.remainingDistance > closeEnough;
    }

    private bool IsMovingTowardsPreviousDestination()
    {
        // Check if the enemy is currently moving towards the previous destination
        return enemyAgent.hasPath && !enemyAgent.pathPending && enemyAgent.remainingDistance > 0.1f;
    }
}
