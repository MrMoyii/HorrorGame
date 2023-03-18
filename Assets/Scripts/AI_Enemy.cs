using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Enemy : MonoBehaviour
{
    public Transform Objetivo;
    public float velocidad = 3, distance = 2.5f, damage = 1;
    public NavMeshAgent IA;
    
    // Update is called once per frame
    void Update()
    {
        IA.speed = velocidad;
        IA.SetDestination(Objetivo.position);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = FindObjectOfType<Player>();
            player.TakeDamage(Mathf.Abs(damage * Time.deltaTime));
        }
    }
}
