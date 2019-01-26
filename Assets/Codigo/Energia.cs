using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energia : MonoBehaviour
{
    public float energia;
    public float multiplicadorEnergia;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool sinEnergia(float cantidad)
    {
        energia = energia - cantidad;
        Debug.Log("Energia" + energia);
        if (energia<=0)
        {
            energia = 0;
            return true;
        }
        return false;
    }
}
