using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitScrip : MonoBehaviour
{
    void Update()
    {
        //Peli lopetetaan ESC-n�pp�imell�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }
}
