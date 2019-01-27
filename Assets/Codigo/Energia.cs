using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energia : MonoBehaviour
{
    public float energia;
    public float multiplicadorPenalizacion;
    public float constanteNormalizadora;
    public GameObject barraEnergia;
    private Image imagenBarraEnergia;
    // Start is called before the first frame update
    void Start()
    {
        //barraEnergia=
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool sinEnergia(float cantidad,bool penalizado)
    {
        float penalizacion = 1;
        if (penalizado)
        {
            penalizacion = multiplicadorPenalizacion;
        }
        energia = energia - constanteNormalizadora * cantidad * penalizacion;
        Debug.Log("Energia: " + energia);
        if (energia<=0)
        {
            energia = 0;
            return true;
        }
        return false;
    }
}
