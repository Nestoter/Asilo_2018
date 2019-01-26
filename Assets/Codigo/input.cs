using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum letrasPatron { A, S, D };

public class input : MonoBehaviour{
    
    private KeyPattern patron;
    public float speed;
    public float tolerancia;
    // Start is called before the first frame update
    void Start(){
        patron = new KeyPattern(tolerancia);
        patron.umbral = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.rotation = new Quaternion(0, 180, 0, 0);
            Vector3 pos = transform.position;
            pos.x -= speed * Time.deltaTime;
            this.transform.position = pos;
        }*/
        if (Input.GetKeyDown(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && patron.patronValido(letrasPatron.A))
        {

        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            //KeyPattern.registerS
            //}

            if (Input.GetKeyDown(KeyCode.D))
            {

            }
        }
    }
}


public class KeyPattern : MonoBehaviour
{
    public int algo;
    private letrasPatron siguienteLetra;
    private DateTime firstTime;
    private DateTime secondTime;
    private float diferencia;
    public float umbral;

    public KeyPattern(float tolerancia){
        siguienteLetra = letrasPatron.A;
    }

    public bool patronValido(letrasPatron letraIngresada)
    {
        if (letraIngresada == siguienteLetra)
        {
            switch (letraIngresada)
            {
                case letrasPatron.A:
                    firstTime = DateTime.Now;
                    siguienteLetra = letrasPatron.S;
                    break;
                case letrasPatron.S:
                    secondTime = DateTime.Now;
                    diferencia = (secondTime - firstTime).Milliseconds;
                    siguienteLetra = letrasPatron.D;
                    break;
                case letrasPatron.D:
                    if ((DateTime.Now- secondTime).Milliseconds/ diferencia > umbral){
                        siguienteLetra = letrasPatron.A;
                    }
                    break;
            }
            return true;
        }
        return false;
    }
}