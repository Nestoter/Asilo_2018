using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float speed = 6;
    public bool reproducioSonido;

    // Start is called before the first frame update
    void Start()
    {
        reproducioSonido = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        this.transform.position = pos;
       
    }
}
