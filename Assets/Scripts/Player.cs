using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform camara, flashLight;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CharacterController cc;
    [SerializeField] private float energy = 10, maxEnergy = 10, timeToRecover = 5;
    [SerializeField] private FPSController fPSController;

    private float distanceRaycast = 3.5f;
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

        //sistema de energia y baja la linterna al correr
        if (Input.GetKey(KeyCode.LeftShift) && cc.velocity.magnitude >= 1 && energy >= 0)
        {
            flashLight.localEulerAngles = Vector3.Lerp(flashLight.localEulerAngles, new Vector3(25, 0, 0), Time.deltaTime * 2.5f);

            energy -= Time.deltaTime;

            //penalizacion por consumir todo el timepo de correr
            if (energy <= 0.1f)
            {
                energy = -Mathf.Abs(timeToRecover);
                fPSController.walkSpeed = 3;
                fPSController.runSpeed = 3;
            }
        }
        else
        {
            flashLight.localEulerAngles = Vector3.Lerp(flashLight.localEulerAngles, new Vector3(0, 0, 0), Time.deltaTime * 2.5f);

            if (energy >= 0)
            {
                fPSController.walkSpeed = 6;
                fPSController.runSpeed = 10;
            }

            if (energy <= Mathf.Abs(maxEnergy))
                energy += Time.deltaTime;
        }

        
    }
}
