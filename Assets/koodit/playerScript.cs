using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    //pelaajan nopeus
    public float playerSpeed = 4.2f;
    //viittaus rigidbodyyn, johon viittaamalla pelaajaa liikutetaan
    public Rigidbody2D rb;
    //pelaajan liike
    public Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        //haetaan Rigidbody komponentti
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //suunta pelaajan liikkeelle. Jos pelaaja painaa yl�sp�in nuolin�pp�int� arvo = 1, taas alasp�in nuolin�pp�int� painaessa arvo = -1
        float directionY = Input.GetAxisRaw("Vertical");
        //koska pelaaja voi liikuttaa alusta vain y-akselin suuntaisesti x-akselin arvo on vakiona 0. Y-akselin arvo directionY-muuttujan arvo.
        movement = new Vector2(0, directionY).normalized;

        //aluksen animaatiot
        //kun yl�snappi on pohjassa
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.GetComponent<Animator>().SetInteger("PlayerState", 1);
        }
        //kun yl�snappi p��stet��n pois pohjasta
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            this.GetComponent<Animator>().SetInteger("PlayerState", 0);
        }

        //alasnappi
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.GetComponent<Animator>().SetInteger("PlayerState", 2);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.GetComponent<Animator>().SetInteger("PlayerState", 0);
        }
    }


    void FixedUpdate()
    {
        //k�ytet��n rigidbodya pelaajan objektin liikuttamista varten. Saa liikkeen suunnan movement-muuttujalta ja nopeuden speed-muuttujalta.
        rb.MovePosition((Vector2)transform.position + (movement * playerSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Alus tuhoutuu, kun pelaaja t�rm�� toiseen objektiin, jolle on annettu "tagi" "Enemy"
        if (collision.tag.Equals("Enemy"))
        {
            //asetetaan aluksen poistamiseen pieni viive, jotta r�j�hdys animaatio ehtii n�ky�
            Destroy(this.gameObject, 3f * Time.deltaTime);

        }

        
    }

}
