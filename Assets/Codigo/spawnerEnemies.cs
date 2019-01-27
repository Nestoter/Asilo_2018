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
    public float campoVisual;
    private float avanceRandom;
    Vector3 posicionObstaculo;
    int randomInt;
    private float xInicial;
    private float xActual;
    private float xPasada;
    public float intervaloRandom;


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
        avanceRandom = Random.Range(-intervaloRandom, intervaloRandom);
        xActual = scriptDistancia.distanciaRecorrida + xInicial;
        if (Mathf.Abs(xActual - xPasada) >= constAvance + avanceRandom)
        {
            posicionObstaculo.x = xActual + campoVisual + Random.Range(0, 10);
            posicionObstaculo.z = -1;

            randomInt = Random.Range(1, 4);
            switch (randomInt)
            {
                case 1:
                    posicionObstaculo.y = scriptInput.targetyabajo;
                    Instantiate(obstaculo, posicionObstaculo, Quaternion.identity);
                    break;
                case 2:
                    posicionObstaculo.y = scriptInput.targetymedio;
                    Instantiate(obstaculo, posicionObstaculo, Quaternion.identity);
                    break;
                case 3:
                    posicionObstaculo.y = scriptInput.targetyarriba;
                    Instantiate(obstaculo, posicionObstaculo, Quaternion.identity);
                    break;
            }
                                   
            xPasada = xActual;
        }
    }
}
