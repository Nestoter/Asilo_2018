using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum letrasPatron { A, S, D };

public class input : MonoBehaviour
{
    private KeyPattern patron;
    public float velocidadX;
    private float targetX;
    public float distanciaX;

    private enum posicionVertical { abajo, medio, arriba };
    private posicionVertical posVertical;
    private enum direccionMovimientoVertical { abajo, arriba };
    private direccionMovimientoVertical dirVertical;
    private bool movimientoVertical;
    public float targetyabajo;
    public float targetymedio;
    public float targetyarriba;
    private float posicionYFinal;
    public float velocidadY;
    public float umbral;
    public bool movimientoHorizontal;
    private Energia energia;
    private distancia distancia;

    //DEBUG
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        this.posVertical = posicionVertical.abajo;
        patron = new KeyPattern();
        patron.umbral = this.umbral;
        movimientoHorizontal = false;
        movimientoVertical = false;
        energia = this.GetComponent<Energia>();
        distancia= this.GetComponent<distancia>();

        //DEBUG
        speed = 6;
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
        if (Input.GetKeyDown(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            bool penalizado = true;
            if (!energia.estaCansado && !patron.patronValido(letrasPatron.A) && energia.sinEnergia(velocidadX / patron.factorVelocidad, penalizado))
            {
                Debug.Log("A: Me canse");
            }
        }
        //TOCO S
        if (Input.GetKeyDown(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            bool fueValido = patron.patronValido(letrasPatron.S);
            if (fueValido)
            {
                targetX = this.transform.position.x + distanciaX;
                movimientoHorizontal = true;
            }

            bool penalizado = true;
            if (!fueValido && energia.sinEnergia(velocidadX / patron.factorVelocidad, penalizado))
            {
                Debug.Log("S: Me canse");
            }
        }

        //TOCO D
        if (Input.GetKeyDown(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A))
        {
            bool penalizado = true;
            if (patron.patronValido(letrasPatron.D))
            {
                penalizado = false;
            }
            if (energia.sinEnergia(velocidadX / patron.factorVelocidad,penalizado))
            {
                Debug.Log("D: Me canse");
            }
        }

        if (movimientoHorizontal)
        {
            Vector3 targetVector = transform.position;
            float xAnterior = targetVector.x;
            targetVector.x = targetX;
            
            
            transform.position = Vector3.Lerp(transform.position, targetVector, velocidadX / patron.factorVelocidad);
            distancia.distanciaRecorrida += xAnterior - transform.position.x;
            if (Mathf.Abs(transform.position.x - targetX) < 0.1f)
            {
                movimientoHorizontal = false;
            }
        }
        //////////////////////////


        //HABILITA MOVIMIENTO HACIA ARRIBA
        if (Input.GetKey(KeyCode.UpArrow) && !movimientoVertical && !(this.posVertical == posicionVertical.arriba))
        {
            movimientoVertical = true;
            this.dirVertical = direccionMovimientoVertical.arriba;

            switch (posVertical)
            {
                case posicionVertical.abajo:
                    posicionYFinal = targetymedio;
                    break;
                case posicionVertical.medio:
                    posicionYFinal = targetyarriba;
                    break;
            }
        }

        //HABILITA MOVIMIENTO HACIA ABAJO
        if (Input.GetKey(KeyCode.DownArrow) && !movimientoVertical && !(this.posVertical == posicionVertical.abajo))
        {
            movimientoVertical = true;
            this.dirVertical = direccionMovimientoVertical.abajo;

            switch (posVertical)
            {
                case posicionVertical.medio:
                    posicionYFinal = targetyabajo;
                    break;
                case posicionVertical.arriba:
                    posicionYFinal = targetymedio;
                    break;
            }
        }

        //REALIZA MOVIMIENTO VERTICAL
        if (movimientoVertical)
        {
            Vector3 targetVector = this.transform.position;
            targetVector.y = posicionYFinal;
            transform.position = Vector3.Lerp(transform.position, targetVector, velocidadY);
            if (Mathf.Abs(transform.position.y - posicionYFinal) < 0.1f)
            {
                movimientoVertical = false;
                switch (posVertical)
                {
                    case posicionVertical.abajo:
                        posVertical = posicionVertical.medio;
                        break;
                    case posicionVertical.medio:
                        if (dirVertical == direccionMovimientoVertical.abajo)
                        {
                            posVertical = posicionVertical.abajo;
                        }
                        else
                        {
                            posVertical = posicionVertical.arriba;
                        }
                        break;
                    case posicionVertical.arriba:
                        posVertical = posicionVertical.medio;
                        break;
                }

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
