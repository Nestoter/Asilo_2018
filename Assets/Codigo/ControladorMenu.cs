using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{
    private FadeOut canvasCreditos;
    private FadeOut canvasMenu;

    // Start is called before the first frame update
    void Start()
    {
        canvasMenu = this.transform.GetChild(1).gameObject.GetComponent<FadeOut>();
        canvasCreditos = this.transform.GetChild(2).gameObject.GetComponent<FadeOut>();
           
        canvasMenu.startFadeIn(null, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void startGame()
    {
        canvasMenu.startFadeOut(loadScene, 0f);
    }
    private void loadScene()
    {
        SceneManager.LoadScene("Nestoter");
    }

    public void cargarCreditos()
    {
        canvasMenu.startFadeOut(menuFadeOutFinish, 0f);
    }

    public void salir()
    {
        canvasMenu.startFadeOut(cerrar_programa, 0f);
    }

    public void cerrar_programa()
    {
        Application.Quit();
    }

    //MANEJADORES FADES
    public void menuFadeOutFinish(){
        canvasCreditos.startFadeIn(creditosFadeInFinish, 3f);
    }

    public void creditosFadeInFinish(){
        canvasCreditos.startFadeOut(creditosFadeOutFinish, 0f);
    }

    public void creditosFadeOutFinish(){
        canvasMenu.startFadeIn(null, 0f);
    }
}
