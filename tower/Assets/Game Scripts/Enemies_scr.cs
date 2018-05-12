using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_scr : MonoBehaviour
{
    public string nome;
    public int health;
    public int damage;
    public int speed;
    

    Rigidbody2D m_Rigidbody2D;
    float Speed;


    // Use this for initialization
    void Start()
    {
        nome = PlayerPrefs.GetString("Enemy_Nombre");
        health = PlayerPrefs.GetInt("Enemy_Vida");
        damage = PlayerPrefs.GetInt("Enemy_Danio");
        speed = PlayerPrefs.GetInt("Enemy_Velocidad");
      
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    
        Speed = (float)speed;
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody2D.velocity = Vector2.left * Speed;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int cantidad;
        cantidad = PlayerPrefs.GetInt("Enemigos");
        if (health != 0)
        {
            health -= 5;
		    Object.Destroy(other.gameObject);
        }

        if (health == 0)
        {
            Object.Destroy(gameObject);
            cantidad--;
            PlayerPrefs.SetInt("Enemigos", cantidad);
        }

        
    }
    public void BuffCaos()
    {   // se llama desde el EnemyManager para el modo caos.
        Speed = 4.5f;
        health = 20;
    }
}

