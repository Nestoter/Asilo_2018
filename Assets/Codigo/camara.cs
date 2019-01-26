using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public GameObject Seguimiento;
    public Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Seguimiento != null)
        {
            Vector3 a = new Vector3(Seguimiento.transform.position.x, 0, -10);
            this.transform.position = a;
        }
    }
}
