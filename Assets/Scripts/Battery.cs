using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public Flashlight linterna;
    public AudioSource clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.CompareTag("Player"))
        {
            clip.Play();
            linterna.battery += 7.0f;
            Destroy(gameObject);
        }
    }
}
