using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int objective = 0, objectiveAmount;
    public GameObject objetivos;

    private void Start()
    {
        objectiveAmount = objetivos.transform.childCount;
    }
    //public int Objective { get => objective; set => objective = value; }
}
