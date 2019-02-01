using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interaccionHUD : MonoBehaviour
{
    public GameObject muerte;

    private FadeOut black;
    private FadeOut hudFade;
    private FadeOut gameOver;
    // Start is called before the first frame update
    void Start()
    {
        GameObject activarBlack = this.transform.GetChild(this.transform.childCount - 1).gameObject;
        activarBlack.SetActive(true);
        black = activarBlack.GetComponent<FadeOut>();
        black.startFadeOut(null, 0f);
        gameOver = this.transform.GetChild(1).gameObject.GetComponent<FadeOut>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void volverMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void desencadenarFinal()
    {
        gameOver.startFadeIn(cerrar, 3f);
    }

    private void cerrar()
    {
        black.startFadeIn(volverMenu, 0f);
    }

}
