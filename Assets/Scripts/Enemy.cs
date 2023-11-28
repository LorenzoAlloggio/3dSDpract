using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{

    public NavMeshAgent Enemy;

    public float squareOfMovement = 20f;

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    private float xPosition;
    private float yPosition;
    private float zPosition;

    public float closeEnough = 3f;


    // Start is called before the first frame update
    void Start()
    {
        xMin = -squareOfMovement;
        xMax = squareOfMovement;
        zMin = -squareOfMovement;
        zMax = squareOfMovement;

        newLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPosition, yPosition, zPosition)) <= closeEnough)
        {
            newLocation();
        }
    }

    public void newLocation()
    {
        xPosition = Random.Range(xMin, xMax);
        yPosition = transform.position.y;
        zPosition = Random.Range(zMin, zMax);
        Enemy.SetDestination(new Vector3(xPosition, yPosition, zPosition));
    }
}