using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//scenemanager
using UnityEngine.SceneManagement;

public class introScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Pelin voi aloittaa painamalla jotain näppäintä
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Skene1");
        }
        
    }
}
