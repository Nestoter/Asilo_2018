using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.CameraEditor;

public class spawnerEnemies : MonoBehaviour
{
    private distancia scriptDistancia;
    private input scriptInput;
    public GameObject personaje;
    public GameObject obstaculo;
    public float constAvance;
    private float avanceRandom;
    Vector3 posicionObstaculo;
    int randomInt;
    private float xInicial;
    private float xActual;
    private float xPasada;


    // Start is called before the first frame update
    void Start()
    {
        scriptDistancia = personaje.GetComponent<distancia>();
        scriptInput = personaje.GetComponent<input>();
        xInicial = personaje.transform.position.x;
        xPasada = xInicial;
    }

    // Update is called once per frame
    void Update()
    {

        avanceRandom = Random.Range(0, 10);
        xPasada = xActual;
        //xActual = scriptDistancia.distanciaRecorrida - xPasada;
        xActual = scriptDistancia.distanciaRecorrida + xInicial;
        //Debug.Log(" distancia " + scriptDistancia.distanciaRecorrida);
        //Debug.Log(" xInicial " + xInicial);
        Debug.Log(" xPasada " + xPasada);
        Debug.Log(" xActual " + xActual);
        if (Mathf.Abs(xActual - xPasada) >= constAvance)
        {
          
            randomInt = Random.Range(1, 4);
            switch (randomInt)
            {
                case 1:
                    posicionObstaculo.y = scriptInput.targetyabajo;                       
                    break;
                case 2:
                    posicionObstaculo.y = scriptInput.targetymedio;
                    break;
                case 3:
                    posicionObstaculo.y = scriptInput.targetyarriba;
                    break;
            }
                                   
            posicionObstaculo.x = Random.Range(0, 10);
            posicionObstaculo.z = -1;
            Instantiate(obstaculo, posicionObstaculo, Quaternion.identity);
            
        }


    }
}
