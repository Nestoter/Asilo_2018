using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class distancia : MonoBehaviour
{
    public float distanciaRecorrida;
    public Text textoDistancia;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementarDistancia(float distancia)
    {
        distanciaRecorrida += distancia;
        textoDistancia.text = Mathf.Round(distanciaRecorrida)+"m";
    }
}
