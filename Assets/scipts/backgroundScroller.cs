using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScroller : MonoBehaviour
{
    public BoxCollider2D bc2d;
    public Rigidbody2D rb2d;

    //kuvan leveys
    private float width;
    //nopeus taustalle. Laitetaan public, jotta voidaan muuttaa nopeutta unityn puolella.
    //Näin voidaan asettaa taustalle useita tähti kerroksia, jotka liikkuvat eri tahtiin
    public float scrollspeed = -2f;

    // Start is called before the first frame update
    void Start()
    {
        //haetaan
        bc2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();

        //asetetaan muuttujan arvoksi kuvan leveys colliderin avulla
        width = bc2d.size.x;
        //tämän jälkeen voimme passivoida colliderin
        bc2d.enabled = false;
        //liikutetaan taustaa vasemmalle
        rb2d.velocity = new Vector2(scrollspeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //resetoidaan tausta aloitus pisteeseen, kun se on siirtynyt kokonaan pois ruudusta
        if (transform.position.x < -width)
        {
            Vector2 resetposition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetposition;
        }
    }
}
