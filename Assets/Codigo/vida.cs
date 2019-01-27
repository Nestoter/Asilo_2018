using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vida : MonoBehaviour
{
    public int vidas;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        vidas -= 1;
        Debug.Log("vidas = " + vidas.ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vidas == 0)
        {
            SceneManager.LoadScene("DeathScene");      
        }
    }
    

}
