using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public bool disabled;
    public GameObject menu;
    public GameObject crew;
    public GameObject UI;    
    public GameObject loading;
    private bool secuencia;

    // Use this for initialization
    void Start()
    {
        secuencia = false;
        disabled = true;
        menu.GetComponent<FadeOut>().startFadeIn(menuFadeInFinish, 0f);
    }

    public void salir()
    {
        Application.Quit();
    }

    public void verCrew()
    {
        if (!disabled)
        {
            disabled = true;
            secuencia = true;
            menu.GetComponent<FadeOut>().startFadeOut(menuFadeOutFinish, 0f);
        }
    }

    public void startGame()
    {
        if (!disabled)
        {
           disabled = true;
            menu.GetComponent<FadeOut>().startFadeOut(menuFadeOutFinish, 1f);
        }
    }

    public void menuFadeOutFinish()
    {
        if (secuencia)
        {
            crew.GetComponent<FadeOut>().startFadeIn(crewFadeInFinish, 4f);
        }
        else
        {
            menu.GetComponent<FadeOut>().startFadeOut(UIFadeInStart, 1f);
        }

    }

    public void UIFadeInStart()
    {
        UI.GetComponent<FadeOut>().startFadeIn(loadLevel, 0.7f);
        startFadeIn();
    }

    public void loadLevel()
    {
        loading.GetComponent<CanvasGroup>().alpha = 1;
        SceneManager.LoadScene("Cosu");
    }


    public void crewFadeInFinish()
    {
        crew.GetComponent<FadeOut>().startFadeOut(crewFadeOutFinish, 3f);
    }

    public void crewFadeOutFinish()
    {
        menu.GetComponent<FadeOut>().startFadeIn(menuFadeInFinish, 0f);
    }

    public void menuFadeInFinish()
    {
        secuencia = false;
        disabled = false;
    }
}