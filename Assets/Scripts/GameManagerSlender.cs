using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerSlender : MonoBehaviour
{
    [SerializeField] GameObject slender;
    [SerializeField] GameObject personaje;
    [SerializeField] Transform[] arrayPuntosSalida;
    [SerializeField] GameObject panelFinal;
    [SerializeField] private TextMeshProUGUI textoFinal;

    private int puntoSalida;

    // Start is called before the first frame update
    void Start()
    {
        EstablecerPunto(personaje);
        CrearNuevoSlender();
    }

    private void EstablecerPunto(GameObject obj)
    {
        puntoSalida = Random.Range(0, arrayPuntosSalida.Length);
        obj.transform.position = arrayPuntosSalida[puntoSalida].position;
    }

    public void CrearNuevoSlender()
    {
        Instantiate(slender);
        EstablecerPunto(slender);
    }

    public void ApareceFinal(string txt)
    {
        panelFinal.SetActive(true);
        textoFinal.text = txt;
    }
}
