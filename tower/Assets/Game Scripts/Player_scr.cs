using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_scr : MonoBehaviour {
    public GameObject bala;
    public Vector2 inicio;
    public int puntos;
    public string nombre;
    public int vida;
    public Scrollbar barra_vida;
    // Use this for initialization
    void Start () {
        inicio.x = -6f;
        inicio.y = 0.7f;
        vida = PlayerPrefs.GetInt("Player_Vida");
        nombre = PlayerPrefs.GetString("Player_Nombre");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(bala, inicio, Quaternion.identity);

        }
        puntos = PlayerPrefs.GetInt("Puntos");
	}

    public void perdervida(bool tipo)
    {
        if (vida != 0)
        {
            if (tipo == true)
            {
                vida -= PlayerPrefs.GetInt("Boss_Danio");
                barra_vida.size = (float)vida / 100f;
            }
            else
            {
                vida -= PlayerPrefs.GetInt("Enemy_Danio");
                barra_vida.size = (float)vida / 100f;
            }
        }
        else
        {
            SceneManager.LoadScene(3);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Boss")
        {
            perdervida(true);
            Object.Destroy(collision.gameObject);
        }
        else if (collision.collider.tag == "Enemy")
        {
            perdervida(false);
            Object.Destroy(collision.gameObject);
        }
    }
}
