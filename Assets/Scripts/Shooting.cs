using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera cam;

    private RaycastHit rayHit;
    private Ray ray;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out rayHit))
            {
                if (rayHit.collider.tag.Equals("NPC"))
                {
                    ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
                    if (scoreManager != null)
                    {
                        scoreManager.IncreaseEnemiesKilled();
                    }

                    Destroy(rayHit.collider.gameObject);
                    Debug.Log("You are going to die");
                }
            }
        }
    }
}
