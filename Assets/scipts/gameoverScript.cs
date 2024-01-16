using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
//scenemanager
using UnityEngine.SceneManagement;

public class gameoverScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //haetaan tallennetut pisteet ja tulostetaan ne tekstikentt‰‰n
        float score = PlayerPrefs.GetFloat("points");
        GameObject.Find("ScoreText").GetComponent<Text>().text = "YOUR SCORE: " + score.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        //uusipeli space-n‰pp‰imest‰
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Skene1");
        }
    }
}
