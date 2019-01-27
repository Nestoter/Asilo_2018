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


    // Start is called before the first frame update
    void Start()
    {
        scriptDistancia = personaje.GetComponent<distancia>();
        scriptInput = personaje.GetComponent<input>();
    }

    // Update is called once per frame
    void Update()
    {

        avanceRandom = Random.Range(0, 10);
        if (scriptDistancia.distanciaRecorrida >= constAvance + avanceRandom)
        {
          
            randomInt = Random.Range(1, 3);
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
            scriptDistancia.distanciaRecorrida = 0;
        }


    }
}
