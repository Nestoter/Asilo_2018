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
    public GameObject hud;

    private interaccionHUD interaccionHUD;
    public GameObject musicaJuego;
    public GameObject musicaGameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool muerto = false;
        if ((collision.gameObject.tag == "Obstaculo") || (collision.gameObject.tag == "Taxi"))
        {
            int inicio = 1;
            int tope = audioSources.Length - 1;
            vidas -= 1;
            if (vidas == 0)
            {
                inicio = 0;
                tope = 1;
                muerto = true;
            }
            audioSources[Random.Range(inicio, tope)].Play();
            arrayCorazones.transform.GetChild(vidas).GetComponent<Image>().sprite = emptyhearth;
            animador.SetTrigger("reciboDaño");
        }
        else if (collision.gameObject.tag == "Enemigo"){
            audioSources[0].Play();
            animador.SetTrigger("reciboDaño");
            muerto = true;
        }

        if (muerto)
        {
            StartCoroutine(desencadenarFinal(3f));
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        interaccionHUD = hud.GetComponent<interaccionHUD>();
        controles = this.GetComponent<input>();
        energia = this.GetComponent<Energia>();
        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update(){}

    IEnumerator desencadenarFinal(float time){
        musicaJuego.GetComponent<AudioSource>().Stop();
        musicaGameOver.GetComponent<AudioSource>().Play();
        Destroy(controles);
        energia.cantidadRecarga = 0;
        animador.SetBool("dañoLetal", true);
        yield return new WaitForSeconds(time);
        interaccionHUD.desencadenarFinal();
        Destroy(this);
    }
}
