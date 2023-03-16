using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private Transform camara;
    [SerializeField]private GameManager gameManager;

    private float distanceRaycast = 3.0f;
    void Update()
    {
        //para ver el Raycast
        //Debug.DrawRay(camara.position, camara.forward * distanceRaycast, Color.red);
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit raycast;
            if (Physics.Raycast(camara.position, camara.forward, out raycast, distanceRaycast))
            {
                if (raycast.collider.gameObject.CompareTag("Objective"))
                {
                    gameManager.objective++;
                    //TODO Win
                    Destroy(raycast.collider.gameObject);
                }
            }
        }
    }
}
