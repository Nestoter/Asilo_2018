using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.CameraEditor;

public class spawnerEnemies : MonoBehaviour
{
    private distancia scriptDistancia;
    public GameObject personaje;
    public float avanceRandom;
    public float posicionObstaculoRandom;
    


    // Start is called before the first frame update
    void Start()
    {
        scriptDistancia = personaje.GetComponent<distancia>();
    }

    // Update is called once per frame
    void Update()
    {

        /*scriptDistancia.distanciaRecorrida;
        if (timer < 0)
        {
            timer = SpawnerTime;
            Spawn();
        }

        void Spawn()
        {
               
            var xzPos = Random.insideUnitCircle;
            while (xzPos.magnitude < Settings.MinSpawnRange)
            {
                xzPos = Random.insideUnitCircle;
            }

            var generatedPos = new Vector3(xzPos.x * Settings.DistanceFactor, 0f, xzPos.y * Settings.DistanceFactor);

            Instantiate(thingsToSpawn.PickOne(), Player.transform.position + generatedPos, Quaternion.identity);
            
        }*/
    }
}
