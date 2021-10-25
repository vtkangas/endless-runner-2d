using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    //nopeus
    public float enemySpeed = 16f;
    //rigidbody viittaus
    private Rigidbody2D rb;

    //t‰h‰n lis‰t‰‰n r‰j‰hdys
    public GameObject explosion = null;

    void Start()
    {
        //haetaan rigidbody
        rb = this.GetComponent<Rigidbody2D>();
        //objekti liikkuu oikealta vasemmalle speed-muuttujan arvon m‰‰ritt‰m‰ll‰ nopeudella
        rb.velocity = new Vector2(-enemySpeed, 0);
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //tuhotaan "enemy"-peliobjekti, kun se osuu johonkin reunapalkeista
        if (collision.tag.Equals("Border"))
        {
            Destroy(this.gameObject);
        }

        //jos tˆrm‰t‰‰n pelaajan kanssa
        if (collision.tag.Equals("Player"))
        {
            // soitetaan ‰‰niefekti
            GameObject.Find("sounds").GetComponents<AudioSource>()[1].Play();

            //ja luodaan r‰j‰hdysanimaatio
            GameObject boom = Instantiate(this.explosion, this.GetComponent<Transform>().position, Quaternion.identity);

            //sek‰ tuhotaan peliobjekti ja r‰j‰hdys
            //lis‰t‰‰n r‰j‰hdyksen tuhoutumiseen viive
            Destroy(boom, 3f * Time.deltaTime);
            Destroy(this.gameObject);
        }
    }
}
