using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int objective = 0, objectiveAmount;
    public GameObject objetivos;
    public Text txtObjectives;

    private void Start()
    {
        objectiveAmount = objetivos.transform.childCount;
    }
    //public int Objective { get => objective; set => objective = value; }

    void Update()
    {
        txtObjectives.text = "Objectives: " + objective.ToString() + "/" + objectiveAmount.ToString();
    }
}
