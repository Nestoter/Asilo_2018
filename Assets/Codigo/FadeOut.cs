using System.Collections;
using System;
using UnityEngine;

public class FadeOut : MonoBehaviour
{

    public void startFadeOut(Action action, float tiempo)
    {
        StartCoroutine(DoFade(true, action, tiempo));
    }

    public void startFadeIn(Action action, float tiempo)
    {
        StartCoroutine(DoFade(false, action, tiempo));
    }

    IEnumerator DoFade(bool dofade, Action action, float tiempo)
    {
        CanvasGroup canvasG = GetComponent<CanvasGroup>();
        if (dofade)
        {
            canvasG.interactable = false;
        }
        float constante;
        if (dofade)
        {
            constante = -1f;
        }
        else
        {
            constante = 1f;
        }
        canvasG.alpha += constante * Time.deltaTime / 0.8f;
        while ((canvasG.alpha > 0 && canvasG.alpha != 1) || (canvasG.alpha < 1 && canvasG.alpha != 0))
        {
            canvasG.alpha += constante * Time.deltaTime / 0.8f;
            yield return null;
        }
        if (!dofade)
        {
            canvasG.interactable = true;
            yield return new WaitForSeconds(tiempo);
        }
        if (action!=null){
            action();
        }
    }
}
