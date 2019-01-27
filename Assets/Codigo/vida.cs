using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vida : MonoBehaviour
{
    public int vidas;
    public Animator animador;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Obstaculo") || (collision.gameObject.tag == "Taxi"))
        {
            vidas -= 1;
            animador.SetTrigger("reciboDaño");
            if (vidas==0)
            {
                animador.SetBool("dañoLetal", true);
            }
        } else if (collision.gameObject.tag == "Enemigo")
        {
            vidas = 0;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (vidas == 0)
        {
            SceneManager.LoadScene("DeathScene");      
        }*/
    }
    

}
