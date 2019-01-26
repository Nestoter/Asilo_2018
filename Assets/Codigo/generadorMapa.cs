using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorMapa : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject personaje;    
    public float constanteGeneracion;
    public float constanteDestruccion;
    public Vector3 posicionRelativa;
    private bool paseMitad = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if ((personaje.transform.position.x - this.transform.position.x >= 0) && (!paseMitad))
       {            
            Instantiate(floorPrefab, new Vector3(transform.position.x + constanteGeneracion, 0, 0), Quaternion.identity);
            paseMitad = true;
       }

       if ((Mathf.Abs(personaje.transform.position.x - this.transform.position.x ) >= constanteDestruccion))
       {
            Destroy(this.gameObject);
       }

    }
}
