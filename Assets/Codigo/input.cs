using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{
    public float speed;
    public float distancia;
    private enum posicionVertical { abajo, medio, arriba };
    private posicionVertical a;

    private int unNumero;

    // Start is called before the first frame update
    void Start()
    {
        this.a = posicionVertical.medio;

    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("Enum string is "+ a.ToString());
        if (Input.GetKey(KeyCode.RightArrow))
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
        }

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