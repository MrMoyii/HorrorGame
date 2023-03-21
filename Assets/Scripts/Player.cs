using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform camara, flashLight;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CharacterController cc;
    [SerializeField] public float energy = 10, maxEnergy = 10, timeToRecover = 5;
    [SerializeField] public float life = 10;
    [SerializeField] private FPSController fPSController;
    public Text txtLife;

    private float distanceRaycast = 3.5f;
    void Update()
    {
        //txtLife.text = "Life: " + life.ToString("0") + "\nEnergy: " + energy.ToString("0");

        #region Recolectar objetos
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
                    if (gameManager.objective == gameManager.objectiveAmount)
                    {
                        Debug.Log("Ganaste!");
                        enemy.SetActive(false);
                    }
                    Destroy(raycast.collider.gameObject);
                }
            }
        }
        #endregion
        # region Sistema de energia y baja la linterna al correr
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
                fPSController.walkSpeed = 11.8f;
                fPSController.runSpeed = 18.8f;
            }

            if (energy <= Mathf.Abs(maxEnergy))
                energy += Time.deltaTime;
        }
        #endregion
    }

    #region Métodos
    public void TakeDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            gameObject.SetActive(false);
            Debug.Log("Perdiste!");
        }
    }
    public void Dead()
    {
        Debug.Log("Matar");
        Destroy(gameObject);
        Debug.Log("Morido");
    }
    #endregion
}
