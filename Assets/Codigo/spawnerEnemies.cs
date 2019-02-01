using System.Collections.Generic;
using UnityEngine;

public class spawnerEnemies : MonoBehaviour
{
    private distancia scriptDistancia;
    private input scriptInput;
    public GameObject personaje;
    public GameObject obstaculo;
    public GameObject taxi;
    public GameObject enemigo;
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
    public float constDestruccion;
    private float timer;
    private float timerRandom;
    private GameObject instanciaEnfermero;

    private GameObject spritesObstaculos;
    private List<GameObject> listaObstaculosCreados;
    private List<GameObject> listaTaxisCreados;

    private vida scriptVida;

    // Start is called before the first frame update
    void Start()
    {
        //SPRITES OBSTACULOS
        spritesObstaculos = this.transform.GetChild(0).gameObject;

        //VARIABLES TAXI
        timer = 0;
        timerRandom = Random.Range(-intervaloTimerRandom, -intervaloTimerRandom);
        listaTaxisCreados = new List<GameObject>();

        //VARIABLES OBSTACULO
        xInicial = personaje.transform.position.x;
        xPasada = xInicial;
        listaObstaculosCreados = new List<GameObject>();

        //VARIABLES GLOBALES
        scriptDistancia = personaje.GetComponent<distancia>();
        scriptInput = personaje.GetComponent<input>();
        scriptVida = personaje.GetComponent<vida>();

        //CREO ENEMIGOS INICIALES
        posicionObstaculo.x = personaje.transform.position.x - campoVisual/2;
        posicionObstaculo.y = scriptInput.targetyabajo;
        posicionObstaculo.z = -5;
        instanciaEnfermero=Instantiate(enemigo, posicionObstaculo, Quaternion.identity);
        posicionObstaculo.y = scriptInput.targetyarriba;
        Instantiate(enemigo, posicionObstaculo, Quaternion.identity);


    }

    // Update is called once per frame
    void Update()
    {
        //CREO ENEMIGOS
        if (instanciaEnfermero.transform.position.x > personaje.transform.position.x)
        {
            posicionObstaculo.x = personaje.transform.position.x - campoVisual;
            posicionObstaculo.y = scriptInput.targetyabajo;
            posicionObstaculo.z = -5;
            instanciaEnfermero = Instantiate(enemigo, posicionObstaculo, Quaternion.identity);
            posicionObstaculo.y = scriptInput.targetyarriba;
            Instantiate(enemigo, posicionObstaculo, Quaternion.identity);
        }

        //CREO OBSTACULOS
        avanceRandom = Random.Range(-intervaloRandom, intervaloRandom);
        xActual = scriptDistancia.distanciaRecorrida + xInicial;
        if (Mathf.Abs(xActual - xPasada) >= constAvance + avanceRandom){
            posicionObstaculo.x = xActual + campoVisual + Random.Range(-intervaloPosRandom, -intervaloPosRandom);

            randomInt = Random.Range(1, 3);
            obstaculo = spritesObstaculos.gameObject.transform.GetChild(Random.Range(0, 3)).gameObject;

            switch (randomInt)
            {
                case 1:
                    posicionObstaculo.y = scriptInput.targetyabajo;
                    posicionObstaculo.z = -5;
                    listaObstaculosCreados.Add(Instantiate(obstaculo, posicionObstaculo, Quaternion.identity));
                    break;
                case 2:
                    posicionObstaculo.y = scriptInput.targetyarriba;
                    posicionObstaculo.z = -1;
                    listaObstaculosCreados.Add(Instantiate(obstaculo, posicionObstaculo, Quaternion.identity));
                    break;
               
            }
            xPasada = xActual;
        }

        //CREO TAXIS
        timer += Time.deltaTime;
        if (timer >= umbralTimer + timerRandom)
        {
            posicionObstaculo.x = xActual + campoVisual + Random.Range(-intervaloPosRandom, -intervaloPosRandom);
            posicionObstaculo.z = -3;
            posicionObstaculo.y = scriptInput.targetymedio;
            listaTaxisCreados.Add(Instantiate(taxi, posicionObstaculo, Quaternion.identity));
            timer = 0;
            timerRandom = Random.Range(-intervaloTimerRandom, -intervaloTimerRandom);
        }


        //DESTRUYO OBSTACULOS
        for (int i = 0;i <= listaObstaculosCreados.Count - 1; i++)
        {

            if ((Mathf.Abs(personaje.transform.position.x - listaObstaculosCreados[i].transform.position.x) >= constDestruccion))
            {
                GameObject obj = listaObstaculosCreados[i];
                listaObstaculosCreados.RemoveAt(i);                
                Destroy(obj);
            }
        }

        //DESTRUYO TAXIS
        for (int i = 0; i <= listaTaxisCreados.Count - 1; i++)
        {
            AudioSource audioSourceTaxi = listaTaxisCreados[i].GetComponents<AudioSource>()[0];
            movimiento mov = listaTaxisCreados[i].GetComponent<movimiento>();
            if (audioSourceTaxi.enabled && listaTaxisCreados[i].transform.position.x - personaje.transform.position.x < campoVisual)
            {
                if (!mov.reproducioSonido && scriptVida.vidas!=0)
                {
                    audioSourceTaxi.Play();
                    mov.reproducioSonido = true;
                }
            }
            //audioSourceTaxi.volume= (-1*Mathf.Abs(personaje.transform.position.x - listaTaxisCreados[i].transform.position.x)/30)+1;
            if ((Mathf.Abs(personaje.transform.position.x - listaTaxisCreados[i].transform.position.x) >= constDestruccion))
            {
                GameObject obj = listaTaxisCreados[i];
                listaTaxisCreados.RemoveAt(i);
                Destroy(obj);
            }
        }
    }
}
