using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energia : MonoBehaviour
{
    public float energia;
    public float multiplicadorPenalizacion;
    public float constanteNormalizadora;

    private float maxEnergia;
    public Image barraEnergia;

    private float contadorTiempoRecarga;
    public float intervaloRecarga;
    public float cantidadRecarga;

    private float contadorTiempoCansancio;
    public float intervaloCansancio;
    public bool estaCansado;

    // Start is called before the first frame update
    void Start()
    {
        maxEnergia = energia;
        contadorTiempoRecarga = 0;
        estaCansado = false;
    }

    // Update is called once per frame
    void Update()
    {
        contadorTiempoRecarga = contadorTiempoRecarga + Time.deltaTime;
        if (contadorTiempoRecarga > intervaloRecarga)
        {
            contadorTiempoRecarga = 0;
            recargaEnergia();
        }

        contadorTiempoCansancio = contadorTiempoCansancio + Time.deltaTime;
        if (contadorTiempoCansancio > intervaloCansancio)
        {
            contadorTiempoCansancio = 0;
            estaCansado = false;
        }
    }

    public bool sinEnergia(float cantidad,bool penalizado)
    {
        float penalizacion = 1;
        if (penalizado)
        {
            penalizacion = multiplicadorPenalizacion;
        }
        energia = energia - constanteNormalizadora * cantidad * penalizacion;
        //barraEnergia.fillAmount = (float)energia / maxEnergia;
        if (energia<=0)
        {
            energia = 0;
            estaCansado = true;
            return true;
        }
        return false;
    }

    private void recargaEnergia()
    {
        energia += cantidadRecarga;
        if (energia>maxEnergia)
        {
            energia = maxEnergia;
        }
        //barraEnergia.fillAmount = (float)energia / maxEnergia;
    }
}
