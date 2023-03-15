using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public float battery = 20.0f;
    public GameObject luz;

    void Update()
    {
        if (luz.activeSelf)
        {
            battery -= Time.deltaTime;
        }
        if (battery <= 0)
        {
            luz.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F) && battery > 0)
        {
            GetComponent<AudioSource>().Play();
            luz.SetActive(!luz.activeSelf);
        }
    }
}
