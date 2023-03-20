using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public Flashlight linterna;
    public AudioSource aSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.CompareTag("Player"))
        {
            aSource.Play();
            linterna.battery += 7.0f;
            Destroy(gameObject);
        }
    }
}
