using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class vida : MonoBehaviour
{
    public int vidas;
    public Animator animador;
    private input controles;
    private Energia energia;
    public GameObject arrayCorazones;
    public Sprite emptyhearth;
    private AudioSource[] audioSources;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Obstaculo") || (collision.gameObject.tag == "Taxi"))
        {
            audioSources[Random.Range(0, audioSources.Length)].Play();
            vidas -= 1;
            arrayCorazones.transform.GetChild(vidas).GetComponent<Image>().sprite = emptyhearth;
            animador.SetTrigger("reciboDaño");
            if (vidas==0)
            {
                Destroy(controles);
                energia.cantidadRecarga = 0;
                animador.SetBool("dañoLetal", true);
                Destroy(this);
            }
        } else if (collision.gameObject.tag == "Enemigo")
        {
            vidas = 0;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        controles = this.GetComponent<input>();
        energia = this.GetComponent<Energia>();
        audioSources = GetComponents<AudioSource>();
        Debug.Log(audioSources.Length);
    }

    // Update is called once per frame
    void Update(){}
}
