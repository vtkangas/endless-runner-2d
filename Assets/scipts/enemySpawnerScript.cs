using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerScript : MonoBehaviour
{
    //luotava peliobjekti. T‰h‰n raahataan objektin prefab
    public GameObject enemy = null;
    //rajataan luontialue
    public float maxX = 11.5f;
    public float minX = 11f;
    public float maxY = 4.5f;
    public float minY = -4.5f;
    //m‰‰ritet‰‰n luontitiheys
    public float timeBetweenSpawn = 0.2f;
    //t‰h‰n lasketaan kauanko edellisest‰ luonnista on
    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        //luodaan uusi peliobjekti tietyn aikav‰lein
        if (Time.time > spawnTime)
        {
            spawnEnemy();
            spawnTime = Time.time + timeBetweenSpawn;
        }
        

    }

    //luontifunktio
    private void spawnEnemy()
    {
        //arvotaan luotavan peliobjektin alku sijainti
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        //lis‰t‰‰n peliobjekti skeneen
        GameObject a = Instantiate(this.enemy, new Vector2(randomX, randomY), Quaternion.identity);
    }
}
