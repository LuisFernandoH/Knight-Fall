using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject menuGameOver;

    public GameObject col;
    public Renderer fondo;
    public Renderer Entorno;
    public Renderer EntornoC;
    public Renderer fondo2;
    public Renderer Arboles;
    public bool gameOver = false;
    public bool start = false;

    public GameObject Skelleton;
    public GameObject Goblin;
    public GameObject Ojo;

    public float velocidad = 3;
    public float velocidad2 = 4;
    public float velocidad3 = 5;

    public List<GameObject> cols;
    public List<GameObject> Enemigos;
    public List<GameObject> Goblin2;
    public List<GameObject> Ojo2;

    // Start is called before the first frame update
    void Start()
    {
     //Crear Mapa
     for(int i=0; i<21; i++)
     {
           cols.Add(Instantiate(col, new Vector2(-10 + i, -6), Quaternion.identity));
     }
     //Crear Enemigos
     Enemigos.Add(Instantiate(Skelleton, new Vector2(14, -4), Quaternion.identity));
     Goblin2.Add(Instantiate(Goblin, new Vector2(18, -4), Quaternion.identity));
     Ojo2.Add(Instantiate(Ojo, new Vector2(18, 0), Quaternion.identity));

    }

    // Update is called once per frame
    void Update()
    {
        //Le damos movimiento
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.2f, 0) * Time.deltaTime;
        Entorno.material.mainTextureOffset = Entorno.material.mainTextureOffset + new Vector2(0.1f, 0) * Time.deltaTime;
        EntornoC.material.mainTextureOffset = EntornoC.material.mainTextureOffset + new Vector2(0.08f, 0) * Time.deltaTime;
        fondo2.material.mainTextureOffset = fondo2.material.mainTextureOffset + new Vector2(0.1f, 0) * Time.deltaTime;
        Arboles.material.mainTextureOffset = Arboles.material.mainTextureOffset + new Vector2(0.2f, 0) * Time.deltaTime;

        //Mover mapa
        for (int i = 0; i < cols.Count; i++)
        {
            if (cols[i].transform.position.x <= -10)
            {
                cols[i].transform.position = new Vector3(10, -6, 0);
            }
            cols[i].transform.position = cols[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
        }

        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }

        if (start == true && gameOver == true)
        {
            menuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (start == true && gameOver == false)
        {
            menuPrincipal.SetActive(false);

            //Mover Enemigos
            for (int i = 0; i < Enemigos.Count; i++)
            {
                if (Enemigos[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(11, 18);
                    Enemigos[i].transform.position = new Vector3(randomObs, -4, 0);
                }
                Enemigos[i].transform.position = Enemigos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

            for (int i = 0; i < Goblin2.Count; i++)
            {
                if (Goblin2[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(11, 18);
                    Goblin2[i].transform.position = new Vector3(randomObs, -4, -1);
                }
                Goblin2[i].transform.position = Goblin2[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad2;
            }

            for (int i = 0; i < Ojo2.Count; i++)
            {
                if (Ojo2[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(11, 18);
                    float randomEYE = Random.Range(-4, 2);
                    Ojo2[i].transform.position = new Vector3(randomObs, randomEYE, 0);
                }
                Ojo2[i].transform.position = Ojo2[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad3;
            }
        }
    
    }
}
