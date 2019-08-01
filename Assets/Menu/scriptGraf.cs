using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptGraf : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Obsolete]
    void CalidadAlta() 
    {
        QualitySettings.currentLevel = QualityLevel.Beautiful;
    } 

    // Update is called once per frame
    [System.Obsolete]
    void CalidadMedia() 
    {
        QualitySettings.currentLevel = QualityLevel.Good;
    } 


    // Update is called once per frame
    [System.Obsolete]
    void CalidadBaja()  
    {
        QualitySettings.currentLevel = QualityLevel.Fastest;
    }

}
