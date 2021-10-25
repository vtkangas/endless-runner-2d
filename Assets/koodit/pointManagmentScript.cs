using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI-elementit n‰kyviin
using UnityEngine.UI;
//scenemanagement
using UnityEngine.SceneManagement;

public class pointManagmentScript : MonoBehaviour
{
    //pistelaskuri
    public float scoreCounter = 0;

    //teksti
    private GameObject t1 = null;

    // Start is called before the first frame update
    void Start()
    {
        //haetaan tekstiobjekti
        this.t1 = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        //laskuri pys‰htyy kun pelaajan alus tuhoutuu
        if (GameObject.Find("Player") != null)
        {
            //kasvatetaan laskuria yhdell‰ joka sekunti
            scoreCounter += 1 * Time.deltaTime;
            //Tulostetaan laskurin arvoa tekstiobjektiin
            this.t1.GetComponent<Text>().text = "SCORE: " + this.scoreCounter.ToString("0");
        }

        //siirryt‰‰n gameover n‰kym‰‰n, kun pelaajan alus tuhoutuu
        if (GameObject.Find("Player") == null)
        {
            //tallennetaan pisteet
            PlayerPrefs.SetFloat("points", this.scoreCounter);
            //siirryt‰‰n gameover sceneen
            SceneManager.LoadScene("gameoverSkene");
        }

    }
}
