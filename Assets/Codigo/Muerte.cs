using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour
{

    public float restartDelay = 1.45f;
    private float speed, restartTimer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        restartTimer += Time.deltaTime;

        // .. if it reaches the restart delay...
        if (restartTimer >= restartDelay)
        {
            SceneManager.LoadScene("Cosu");
        }
    }
}
