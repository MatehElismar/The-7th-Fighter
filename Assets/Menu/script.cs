using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    // botonJugar es para entrar al escenario del juego
    [System.Obsolete]
    void botonJugar()
    {
        Application.LoadLevel("Main");
    }

    // botonSalir es para salir del juego
    void botonSalir()
    {
        Application.Quit();
    }

    // botonVolver es ir al menu principal
    [System.Obsolete]
    void botonVolver()
    {
        Application.LoadLevel("Menu");
    }
}
