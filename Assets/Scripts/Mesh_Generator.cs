using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]

public class Mesh_Generator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();

        GetComponent<MeshCollider>().sharedMesh = mesh;
        GetComponent<MeshCollider>().convex = true;
    }

    void CreateShape()
    {
        vertices = new Vector3[]
        {
            new Vector3 (0.0f, 0.0f, 0.0f), // 0 bottom left
            new Vector3 (0.0f, 0.0f, 1.0f), // 1 top left
            new Vector3 (1.0f, 0.0f, 0.0f), // 2 top right
            new Vector3 (1.0f, 0.0f, 1.0f), // 3 bottom right
            new Vector3 (0.5f, 1.0f, 0.5f) // 4 top coördinate
        };

        triangles = new int[]
        {
        2,1,0,
        1,2,3,
        0,1,4,
        1,3,4,
        3,2,4,
        2,0,4

        };
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
