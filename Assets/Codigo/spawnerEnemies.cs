using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.CameraEditor;
using System.Timers;

public class spawnerEnemies : MonoBehaviour
{
    private distancia scriptDistancia;
    private input scriptInput;
    public GameObject personaje;
    public GameObject obstaculo;
    public GameObject taxi;
    public float constAvance;
    public float campoVisual;
    private float avanceRandom;
    Vector3 posicionObstaculo;
    int randomInt;
    private float xInicial;
    private float xActual;
    private float xPasada;
    public float intervaloRandom;
    public float intervaloPosRandom;
    public float umbralTimer;
    public float intervaloTimerRandom;
    private float timer = 0;
    private float timerRandom;

    // Start is called before the first frame update
    void Start()
    {
        scriptDistancia = personaje.GetComponent<distancia>();
        scriptInput = personaje.GetComponent<input>();
        xInicial = personaje.transform.position.x;
        xPasada = xInicial;
        timerRandom = Random.Range(-intervaloTimerRandom, -intervaloTimerRandom);

    }

    // Update is called once per frame
    void Update()
    {           
        timer += Time.deltaTime;
        Debug.Log("timer = " + timer);
        avanceRandom = Random.Range(-intervaloRandom, intervaloRandom);
        xActual = scriptDistancia.distanciaRecorrida + xInicial;
        if (Mathf.Abs(xActual - xPasada) >= constAvance + avanceRandom)
        {
            posicionObstaculo.x = xActual + campoVisual + Random.Range(-intervaloPosRandom, -intervaloPosRandom);
            posicionObstaculo.z = -1;

            randomInt = Random.Range(1, 3);
            switch (randomInt)
            {
                case 1:
                    posicionObstaculo.y = scriptInput.targetyabajo;
                    Instantiate(obstaculo, posicionObstaculo, Quaternion.identity);
                    break;
                case 2:
                    posicionObstaculo.y = scriptInput.targetyarriba;
                    Instantiate(obstaculo, posicionObstaculo, Quaternion.identity);
                    break;
               
            }
                                   
            xPasada = xActual;
        }
        if (timer >= umbralTimer + timerRandom)
        {
            posicionObstaculo.y = scriptInput.targetymedio;
            Instantiate(taxi, posicionObstaculo, Quaternion.identity);
            timer = 0;
            timerRandom = Random.Range(-intervaloTimerRandom, -intervaloTimerRandom);
        }
    }
}
