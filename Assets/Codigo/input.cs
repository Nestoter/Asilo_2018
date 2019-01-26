using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{
    public float speed;
    public float distancia;
    private enum posicionVertical { abajo, medio, arriba };
    private posicionVertical posVertical;
    private enum direccionMovimientoVertical { abajo,  arriba };
    private direccionMovimientoVertical dirVertical; 
    private bool movimientoVertical;
    public float targetyabajo;
    public float targetymedio;
    public float targetyarriba;
    private float posicionYFinal;
    public float velocidadY;  

    // Start is called before the first frame update
    void Start()
    {


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
                        } else
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

