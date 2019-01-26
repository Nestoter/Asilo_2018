using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum letrasPatron { A, S, D };

public class input : MonoBehaviour{
    private enum posicionVertical { abajo, medio, arriba };
    posicionVertical a;
    private KeyPattern patron;
    public float velocidadX;
    private float targetX;
    public float distanciaX;
    public float speed;
    public float umbral;
    public bool movimientoHorizontal;
    private Energia energia;

    // Start is called before the first frame update
    void Start(){
        this.a = posicionVertical.medio;
        patron = new KeyPattern();
        patron.umbral = this.umbral;
        movimientoHorizontal = false;
        energia = this.GetComponent<Energia>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.rotation = new Quaternion(0, 0, 0, 0);
            Vector3 pos = transform.position;
            pos.x += speed * Time.deltaTime;
            this.transform.position = pos;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.rotation = new Quaternion(0, 180, 0, 0);
            Vector3 pos = transform.position;
            pos.x -= speed * Time.deltaTime;
            this.transform.position = pos;
        }*/

        //MOVIMIENTO HORIZONTAL
        //TOCO A
        if (Input.GetKeyDown(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) )
        {
            float multiplicadorEnergia = energia.multiplicadorEnergia;
            if (patron.patronValido(letrasPatron.A))
            {
                multiplicadorEnergia = 0;
            }
            if (energia.sinEnergia(patron.factorVelocidad * multiplicadorEnergia))
            {
                Debug.Log("A: Me canse");
            }
        }
        //TOCO S
        if (Input.GetKeyDown(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            float multiplicadorEnergia = energia.multiplicadorEnergia;
            if (patron.patronValido(letrasPatron.S))
            {
                multiplicadorEnergia = 0;
                targetX = this.transform.position.x + distanciaX;
                movimientoHorizontal = true;
            }
            if (energia.sinEnergia(patron.factorVelocidad * multiplicadorEnergia))
            {
                Debug.Log("S: Me canse");
            }

        }

        //TOCO D
        if (Input.GetKeyDown(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A))
        {
            float multiplicadorEnergia = energia.multiplicadorEnergia;
            if (patron.patronValido(letrasPatron.D)){
                multiplicadorEnergia = 1;
            }
            if (energia.sinEnergia(patron.factorVelocidad * multiplicadorEnergia))
            {
                Debug.Log("D: Me canse");
            }
        }

        if (movimientoHorizontal)
        {
            Vector3 targetVector = transform.position;
            targetVector.x = targetX;
            transform.position = Vector3.Lerp(transform.position, targetVector, velocidadX/patron.factorVelocidad);
            if (Mathf.Abs(transform.position.x - targetX) < 0.1f)
            {
                movimientoHorizontal = false;
            }
        }
        //////////////////////////

        if (Input.GetKey(KeyCode.UpArrow))
        {
            switch (a)
            {
                case posicionVertical.abajo:
                    break;
                case posicionVertical.medio:
                    Vector3 pos = transform.position;
                    pos.y += speed * Time.deltaTime;
                    this.transform.position = pos;
                    this.a = posicionVertical.arriba;
                    Debug.Log("Fui a " + a.ToString());
                    break;
                case posicionVertical.arriba:
                    break;
            }

        }
    }
}


public class KeyPattern
{
    private letrasPatron siguienteLetra;
    private DateTime firstTime;
    private DateTime secondTime;
    private float diferencia;
    public float umbral;
    public float factorVelocidad;

    public KeyPattern(){
        siguienteLetra = letrasPatron.A;
        factorVelocidad = 200;
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
                    diferencia = (float)(secondTime - firstTime).TotalMilliseconds;
                    factorVelocidad = diferencia;
                    siguienteLetra = letrasPatron.D;
                    break;
                case letrasPatron.D:
                    siguienteLetra = letrasPatron.A;
                    float nuevaDiff= (float)(DateTime.Now - secondTime).TotalMilliseconds;
                    if (Math.Abs(nuevaDiff-diferencia) < umbral)
                    {
                        siguienteLetra = letrasPatron.A;
                    }
                    else{
                        return false;
                    }
                    break;
            }
            return true;
        }
        else
        {
            siguienteLetra = letrasPatron.A;
            return false;
        }
    }
}
