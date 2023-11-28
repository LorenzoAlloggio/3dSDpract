using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttack : MonoBehaviour
{
    private enemy enemyMovement;
    private Transform player;
    public float attackRange = 10f;

    public Material defaultMaterial;
    public Material alertMaterial;
    public Renderer rend;

    private bool foundPlayer;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMovement = GetComponent<enemy>();
        rend = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            rend.sharedMaterial = alertMaterial; //change Material
            enemyMovement.Enemy.SetDestination(player.position); //set destination to player position
            foundPlayer = true; // enable bool for chasing

        }
        else if (foundPlayer)
        {
            rend.sharedMaterial = defaultMaterial; //set Material back to default
            enemyMovement.newLocation(); // call new location function
            foundPlayer = false; //set bool back to false
        }
    }
}