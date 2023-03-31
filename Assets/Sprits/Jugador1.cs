using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador1 : MonoBehaviour
{
    //Generar una fuerza cada vez que saltemos
    public float FSalto;
    public int maxSaltos = 2;
    public int saltosRealizados = 0;

    public GameManager gameManager;

    private Rigidbody2D rigidbody2D;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      if (saltosRealizados < maxSaltos && Input.GetKeyDown(KeyCode.Space))
        {
            //La variable Booleana que esta en Unit provamos que sea true
            animator.SetBool("estaSaltando", true);
            rigidbody2D.AddForce(new Vector2(0, FSalto));
            saltosRealizados++;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("estaSaltando", false);
            saltosRealizados = 0;
        }

        if (collision.gameObject.tag == "EnemigoSkelleton")
        {
            gameManager.gameOver = true;
        }

        if (collision.gameObject.tag == "EnemigoGoblin")
        {
            gameManager.gameOver = true;
        }

        if (collision.gameObject.tag == "EnemigoOjo")
        {
            gameManager.gameOver = true;
        }
    }
}
